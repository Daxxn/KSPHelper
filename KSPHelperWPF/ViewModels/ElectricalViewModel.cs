using KSPHelperWPF.Events;
using KSPModelLibrary.CalculatorModels.ElectricalCalcModels;
using KSPModelLibrary.CraftParser;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KSPHelperWPF.ViewModels
{
   public enum CalcProp
   {
      Batteries,
      Loads,
      Generators,
      Alternators,
   };

   public class ElectricalViewModel : ViewModel
   {
      #region - Fields & Properties
      private CraftModel _craft;
      private CraftModel _craftBatteries;
      private CraftModel _craftLoads;
      private CraftModel _craftGenerators;
      private CraftModel _craftAlternators;
      private Stage _selectedStage;
      private PartRef _selectedPart;

      private double _batteryTotal;
      private double _loadTotal;
      private double _genTotal;
      private double _altTotal;

      private double _passivechargeRateTotal;
      //private double _throttleChargeRateTotal;
      private TimeSpan _chargeTime;

      private ObservableCollection<StageTotal> _individualStageTotals;
      private ObservableCollection<StageTotal> _linearStageTotals;

      private double _throttleSetting;
      #endregion

      #region - Constructors
      public ElectricalViewModel()
      {
         MainViewModel.OpenNewCraftEvent += OpenNewCraftEvent;
      }

      private void OpenNewCraftEvent(object sender, OpenCraftEventArgs e)
      {
         Craft = e.Craft;
         BuildElectricalParts();
         CalcTestEvent(this, e);
      }
      #endregion

      #region - Methods

      #region Sum Methods
      public void CalcTestEvent(object sender, EventArgs e)
      {
         CalcIndividualStages();
         CalcLinearStages();
         CalcCraftTotals();
      }

      private void CalcCraftTotals()
      {
         BatteryTotal = IndividualStageTotals.Sum(stage => stage.Batteries);
         LoadTotal = IndividualStageTotals.Sum(stage => stage.Loads);
         GenTotal = IndividualStageTotals.Sum(stage => stage.Generators);
         AltTotal = IndividualStageTotals.Sum(stage => stage.Alternators);
         PassiveChargeRateTotal = ElectricalCalcMethods.ChargeRate(GenTotal, LoadTotal);
         //ThrottleChargeRateTotal = ElectricalCalcMethods.ThrottleChargeRate(AltTotal, LoadTotal, ThrottleSetting);
      }
      #endregion

      #region Stage Sum Methods
      private void CalcIndividualStages()
      {
         List<StageTotal> stageTotals = new List<StageTotal>();
         foreach (var stage in Craft.Stages.Values)
         {
            stageTotals.Add(CalcIndividualStage(stage));
         }
         IndividualStageTotals = new ObservableCollection<StageTotal>(stageTotals);
      }

      private StageTotal CalcIndividualStage(Stage stage)
      {
         StageTotal newStage = new StageTotal(stage.StageNumber)
         {
            Batteries = SumValue(CalcProp.Batteries, stage),
            Generators = SumValue(CalcProp.Generators, stage),
            Loads = SumValue(CalcProp.Loads, stage),
            Alternators = SumValue(CalcProp.Alternators, stage),
         };
         return newStage;
      }

      private double SumValue(CalcProp prop, Stage stage)
      {
         double result = 0;
         switch (prop)
         {
            case CalcProp.Batteries:
               foreach (var part in stage.Parts)
               {
                  var resources = part.Part.GetResources<ElectricalResource>();
                  if (resources.Count > 0)
                  {
                     resources.ForEach(res => result += res.Amount);
                  }
               }
               return result;
            case CalcProp.Loads:
               foreach (var part in stage.Parts)
               {
                  var modules = part.Part.GetModules<IELoadModule>();
                  foreach (var module in modules)
                  {
                     result += module.Load;
                  }
               }
               return result;
            case CalcProp.Generators:
               result = 0;
               foreach (var part in stage.Parts)
               {
                  var modules = part.Part.GetModules<IEGenModule>();
                  foreach (var module in modules)
                  {
                     result += module.Charge;
                  }
               }
               return result;
            case CalcProp.Alternators:
               result = 0;
               foreach (var part in stage.Parts)
               {
                  var modules = part.Part.GetModules<IEAltModule>();
                  foreach (var module in modules)
                  {
                     result += module.Charge;
                  }
               }
               return result;
            default:
               throw new ArgumentException($"No Matching prop equals {prop}");
         }
      }

      private void CalcLinearStages()
      {
         List<StageTotal> newStages = new List<StageTotal>();
         foreach (var stage in IndividualStageTotals)
         {
            newStages.Add(CalcLinearStage(stage));
         }
         LinearStageTotals = new ObservableCollection<StageTotal>(newStages);
      }

      private StageTotal CalcLinearStage(StageTotal stage)
      {
         var newStage = new StageTotal(stage.Stage)
         {
            Batteries = IndividualStageTotals[0].Batteries,
            Loads = IndividualStageTotals[0].Loads,
            Generators = IndividualStageTotals[0].Generators,
            Alternators = IndividualStageTotals[0].Alternators,
         };
         for (int i = stage.Stage; i > 0; i--)
         {
            newStage.Batteries += IndividualStageTotals[i].Batteries;
            newStage.Loads += IndividualStageTotals[i].Loads;
            newStage.Generators += IndividualStageTotals[i].Generators;
            newStage.Alternators += IndividualStageTotals[i].Alternators;
         }
         return newStage;
      }
      #endregion

      #region Part Methods
      private void BuildElectricalParts()
      {
         CraftBatteries = FilterStages<ElectricalResource>(true);
         CraftLoads = FilterStages<IELoadModule>();
         CraftGenerators = FilterStages<IEGenModule>();
         CraftAlternators = FilterStages<IEAltModule>();
      }

      private CraftModel FilterStages<TFilter>(bool isResource = false) where TFilter : IPartDataType
      {
         var newCraft = new CraftModel();
         if (typeof(TFilter).GetInterface(nameof(IModule)) != null)
         {
            foreach (var stage in Craft.Stages)
            {
               if (!newCraft.Stages.ContainsKey(stage.Key))
               {
                  newCraft.Stages.Add(stage.Key, FilterPartModules<TFilter>(stage.Value));
               }
            }
         }
         else if (typeof(TFilter).GetInterface(nameof(IResource)) != null)
         {
            foreach (var stage in Craft.Stages)
            {
               if (!newCraft.Stages.ContainsKey(stage.Key))
               {
                  newCraft.Stages.Add(stage.Key, FilterPartResources<TFilter>(stage.Value));
               }
            }
         }
         else
         {
            throw new ArgumentException("TFilter must be I");
         }
         return newCraft;
      }

      private Stage FilterPartModules<TFilter>(Stage stage)
      {
         var newStage = new Stage(stage.StageNumber);
         foreach (var part in stage.Parts)
         {
            foreach (var module in part.Part.Modules)
            {
               if (module is TFilter)
               {
                  newStage.Parts.Add(part);
                  break;
               }
            }
         }
         return newStage;
      }

      private Stage FilterPartResources<TFilter>(Stage stage)
      {
         var newStage = new Stage(stage.StageNumber);
         foreach (var part in stage.Parts)
         {
            foreach (var module in part.Part.Resources)
            {
               if (module is TFilter)
               {
                  newStage.Parts.Add(part);
                  break;
               }
            }
         }
         return newStage;
      }
      #endregion

      #endregion

      #region - Full Properties
      public CraftModel Craft
      {
         get { return _craft; }
         set
         {
            _craft = value;
            OnPropertyChanged(nameof(Craft));
         }
      }

      public Stage SelectedStage
      {
         get { return _selectedStage; }
         set
         {
            _selectedStage = value;
            OnPropertyChanged(nameof(SelectedStage));
         }
      }

      public PartRef SelectedPart
      {
         get { return _selectedPart; }
         set
         {
            _selectedPart = value;
            OnPropertyChanged(nameof(SelectedPart));
            OnPropertyChanged(nameof(SelectedPartLoad));
            OnPropertyChanged(nameof(SelectedPartBattery));
            OnPropertyChanged(nameof(SelectedPartGenerator));
            OnPropertyChanged(nameof(SelectedPartAlternator));
         }
      }

      public double SelectedPartLoad
      {
         get
         {
            double load = 0;
            if (SelectedPart != null)
            {
               foreach (var module in SelectedPart.Part.Modules)
               {
                  if (module is IELoadModule found)
                  {
                     load = found.Load;
                  }
               }
            }
            return load;
         }
      }

      public double SelectedPartBattery
      {
         get
         {
            double batt = 0;
            if (SelectedPart != null)
            {
               foreach (var resource in SelectedPart.Part.Resources)
               {
                  if (resource is ElectricalResource)
                  {
                     batt = resource.Amount;
                  }
               }
            }
            return batt;
         }
      }

      public double SelectedPartGenerator
      {
         get
         {
            double charge = 0;
            if (SelectedPart != null)
            {
               foreach (var module in SelectedPart.Part.Modules)
               {
                  if (module is IEGenModule found)
                  {
                     charge = found.Charge;
                  }
               }
            }
            return charge;
         }
      }

      public double SelectedPartAlternator
      {
         get
         {
            double charge = 0;
            if (SelectedPart != null)
            {
               foreach (var module in SelectedPart.Part.Modules)
               {
                  if (module is IEAltModule found)
                  {
                     charge = found.Charge;
                  }
               }
            }
            return charge;
         }
      }

      public CraftModel CraftBatteries
      {
         get { return _craftBatteries; }
         set
         {
            _craftBatteries = value;
            OnPropertyChanged(nameof(CraftBatteries));
         }
      }

      public CraftModel CraftLoads
      {
         get { return _craftLoads; }
         set
         {
            _craftLoads = value;
            OnPropertyChanged(nameof(CraftLoads));
         }
      }

      public CraftModel CraftGenerators
      {
         get { return _craftGenerators; }
         set
         {
            _craftGenerators = value;
            OnPropertyChanged(nameof(CraftGenerators));
         }
      }

      public CraftModel CraftAlternators
      {
         get { return _craftAlternators; }
         set
         {
            _craftAlternators = value;
            OnPropertyChanged(nameof(CraftAlternators));
         }
      }

      #region Calc Properties
      public double BatteryTotal
      {
         get { return _batteryTotal; }
         set
         {
            _batteryTotal = value;
            OnPropertyChanged(nameof(BatteryTotal));
         }
      }

      public double LoadTotal
      {
         get { return _loadTotal; }
         set
         {
            _loadTotal = value;
            OnPropertyChanged(nameof(LoadTotal));
         }
      }

      public double GenTotal
      {
         get { return _genTotal; }
         set
         {
            _genTotal = value;
            OnPropertyChanged(nameof(GenTotal));
         }
      }

      public double AltTotal
      {
         get { return _altTotal; }
         set
         {
            _altTotal = value;
            OnPropertyChanged(nameof(AltTotal));
         }
      }

      public double PassiveChargeRateTotal
      {
         get { return _passivechargeRateTotal; }
         set
         {
            _passivechargeRateTotal = value;
            OnPropertyChanged(nameof(PassiveChargeRateTotal));
            OnPropertyChanged(nameof(ThrottleChargeRateTotal));
            OnPropertyChanged(nameof(ChargeTimeTotal));
         }
      }

      public double ThrottleChargeRateTotal
      {
         get
         {
            return ElectricalCalcMethods.ThrottleChargeRate(AltTotal, LoadTotal, ThrottleSetting);
         }
      }

      public double CombinedChargeRate
      {
         get
         {
            return PassiveChargeRateTotal + ThrottleChargeRateTotal;
         }
      }

      public TimeSpan ChargeTimeTotal
      {
         get
         {
            return ElectricalCalcMethods.BatteryChargeTime(BatteryTotal, CombinedChargeRate);
         }
      }

      public ObservableCollection<StageTotal> IndividualStageTotals
      {
         get { return _individualStageTotals; }
         set
         {
            _individualStageTotals = value;
            OnPropertyChanged(nameof(IndividualStageTotals));
         }
      }

      public ObservableCollection<StageTotal> LinearStageTotals
      {
         get { return _linearStageTotals; }
         set
         {
            _linearStageTotals = value;
            OnPropertyChanged(nameof(LinearStageTotals));
         }
      }
      #endregion

      public double ThrottleSetting
      {
         get { return _throttleSetting; }
         set
         {
            _throttleSetting = value;
            OnPropertyChanged(nameof(ThrottleSetting));
            OnPropertyChanged(nameof(ThrottleChargeRateTotal));
         }
      }
      #endregion
   }
}
