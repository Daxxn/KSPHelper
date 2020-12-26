using KSPModelLibrary;
using KSPModelLibrary.CalculatorModels.AntennaCalcModels;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using KSPModelLibrary.Data.WorldDataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KSPHelperWPF.ViewModels.CalculatorViewModels
{
   public class AntennaRangeCalcViewModel : ViewModel
   {
      #region - Fields & Properties
      private ObservableCollection<AntennaItem> _allAntennas;
      private AntennaItem _selectedAntenna;
      private ObservableCollection<AntennaItem> _calcAntennas;
      private AntennaItem _selectedCalcAntenna;
      private int _addPartCount = 1;

      private int _selectedTSLevel;
      private DSNModel _selectedTSLevelModel;

      #region Calc Data
      private double _vesselRange;
      private AntennaItem _strongestAntenna;
      private double _totalRange = 0;
      #endregion
      #endregion

      #region - Constructors
      public AntennaRangeCalcViewModel()
      {
         if (GameDataReader.AllPartData.Parts.Count > 0)
         {
            var parts = new ObservableCollection<Part>(GameDataReader.AllPartData.Parts.Where(part =>
            {
               return ModuleFactory.PartHasModule<CommsModule>(part);
            }));

            if (parts.Count > 0)
            {
               AllAntennas = new ObservableCollection<AntennaItem>();
               foreach (var part in parts)
               {
                  AllAntennas.Add(new AntennaItem(part));
               }
            }
         }
         CalcAntennas = new ObservableCollection<AntennaItem>();
      }
      #endregion

      #region - Methods
      public void AddPartEvent(object sender, EventArgs e)
      {
         if (CalcAntennas.Contains(SelectedAntenna))
         {
            SelectedAntenna.Count++;
         }
         else
         {
            CalcAntennas.Add(SelectedAntenna);
         }
      }

      public void AddPartButtonEvent(object sender, EventArgs e)
      {
         if (CalcAntennas.Contains(SelectedAntenna))
         {
            SelectedAntenna.Count += AddPartCount;
         }
         else
         {
            CalcAntennas.Add(SelectedAntenna);
         }
      }

      public void RemovePartEvent(object sender, EventArgs e)
      {
         if (CalcAntennas.Contains(SelectedCalcAntenna))
         {
            if (SelectedCalcAntenna.Count > 1)
            {
               SelectedCalcAntenna.Count--;
            }
            else
            {
               CalcAntennas.Remove(SelectedCalcAntenna);
            }
         }
      }

      public void AddCountUpEvent(object sender, EventArgs e)
      {
         AddPartCount++;
      }

      public void AddCountDownEvent(object sender, EventArgs e)
      {
         if (AddPartCount > 1)
         {
            AddPartCount--;
         }
      }

      public void CalcVesselRangeEvent(object sender, EventArgs e)
      {
         if (CalcAntennas.Count > 0)
         {
            StrongestAntenna = AntennaRangeCalc.StrongestAntenna(CalcAntennas.ToList());
            VesselRange = AntennaRangeCalc.CalcRangeUpdate(CalcAntennas.ToList(), StrongestAntenna);
            TotalRange = AntennaRangeCalc.CalcRangeUpdate(SelectedTSLevel, VesselRange);
         }
         else
         {
            StrongestAntenna = null;
            VesselRange = 0;
         }
      }
      #endregion

      #region - Full Properties
      public ObservableCollection<AntennaItem> AllAntennas
      {
         get { return _allAntennas; }
         set
         {
            _allAntennas = value;
            OnPropertyChanged(nameof(AllAntennas));
         }
      }
      public ObservableCollection<AntennaItem> CalcAntennas
      {
         get { return _calcAntennas; }
         set
         {
            _calcAntennas = value;
            OnPropertyChanged(nameof(CalcAntennas));
            OnPropertyChanged(nameof(StrongestAntenna));
            OnPropertyChanged(nameof(VesselRange));
         }
      }
      public AntennaItem SelectedAntenna
      {
         get { return _selectedAntenna; }
         set
         {
            _selectedAntenna = value;
            OnPropertyChanged(nameof(SelectedAntenna));
         }
      }

      public AntennaItem SelectedCalcAntenna
      {
         get { return _selectedCalcAntenna; }
         set
         {
            _selectedCalcAntenna = value;
            OnPropertyChanged(nameof(SelectedCalcAntenna));
         }
      }

      public int AddPartCount
      {
         get { return _addPartCount; }
         set
         {
            _addPartCount = value;
            OnPropertyChanged(nameof(AddPartCount));
         }
      }

      public int SelectedTSLevel
      {
         get { return _selectedTSLevel; }
         set
         {
            _selectedTSLevel = value;
            SelectedTSLevelModel = KerbalSpaceCenter.DSNRanges[value];
            OnPropertyChanged(nameof(SelectedTSLevel));
         }
      }

      public DSNModel SelectedTSLevelModel
      {
         get { return _selectedTSLevelModel; }
         set
         {
            _selectedTSLevelModel = value;
            OnPropertyChanged(nameof(SelectedTSLevelModel));
         }
      }

      #region Calc Data
      public double VesselRange
      {
         get
         {
            return _vesselRange;
         }
         set
         {
            _vesselRange = value;
            OnPropertyChanged(nameof(VesselRange));
         }
      }

      public AntennaItem StrongestAntenna
      {
         get
         {
            return _strongestAntenna;
         }
         set
         {
            _strongestAntenna = value;
            OnPropertyChanged(nameof(StrongestAntenna));
         }
      }

      public double TotalRange
      {
         get { return _totalRange; }
         set
         {
            _totalRange = value;
            OnPropertyChanged(nameof(TotalRange));
         }
      }
      #endregion
      #endregion
   }
}
