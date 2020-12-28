using KSPModelLibrary.CraftParser;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class ElectricalViewModel : ViewModel
   {
      #region - Fields & Properties
      private CraftModel _craft;
      private CraftModel _craftBatteries;
      private CraftModel _craftLoads;
      private Stage _selectedStage;
      //private ObservableCollection<Stage> _electricalParts;
      #endregion

      #region - Constructors
      public ElectricalViewModel()
      {
         MainViewModel.OpenNewCraftEvent += OpenNewCraftEvent;
      }

      private void OpenNewCraftEvent(object sender, Events.OpenCraftEventArgs e)
      {
         Craft = e.Craft;
         BuildElectricalParts();
      }
      #endregion

      #region - Methods
      private void BuildElectricalParts()
      {
         CraftBatteries = new CraftModel();
         CraftLoads = new CraftModel();
         GetBatteries();
         GetLoads();
      }

      private void GetBatteries()
      {
         foreach (var stage in Craft.Stages)
         {
            if (!CraftBatteries.Stages.ContainsKey(stage.Key))
            {
               CraftBatteries.Stages.Add(stage.Key, FilterBatteryParts(stage.Value));
            }
         }
      }

      private void GetLoads()
      {
         foreach (var stage in Craft.Stages)
         {
            if (!CraftLoads.Stages.ContainsKey(stage.Key))
            {
               CraftLoads.Stages.Add(stage.Key, FilterLoadParts(stage.Value));
            }
         }
      }

      private Stage FilterBatteryParts(Stage stage)
      {
         var newStage = new Stage(stage.StageNumber);
         foreach (var part in stage.Parts)
         {
            //if (part.Part.Resources.Contains( == "Electrical")
            //{
            //   newStage.Parts.Add(part);
            //}
            foreach (var resource in part.Part.Resources)
            {
               if (resource is ElectricalResource)
               {
                  newStage.Parts.Add(part);
               }
            }
         }
         return newStage;
      }

      private Stage FilterLoadParts(Stage stage)
      {
         var newStage = new Stage(stage.StageNumber);
         foreach (var part in stage.Parts)
         {
            //if (part.Part.Resources.Contains( == "Electrical")
            //{
            //   newStage.Parts.Add(part);
            //}
            foreach (var module in part.Part.Modules)
            {
               if (module is ElectricalLoadModule || module is ReactionWheelModule)
               {
                  newStage.Parts.Add(part);
               }
            }
         }
         return newStage;
      }
      #endregion

      #region - Full Properties
      public CraftModel Craft
      {
         get { return _craft; }
         set
         {
            _craft = value;
            //BuildElectricalParts();
            OnPropertyChanged(nameof(Craft));
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

      public Stage SelectedStage
      {
         get { return _selectedStage; }
         set
         {
            _selectedStage = value;
            OnPropertyChanged(nameof(SelectedStage));
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
      #endregion
   }
}
