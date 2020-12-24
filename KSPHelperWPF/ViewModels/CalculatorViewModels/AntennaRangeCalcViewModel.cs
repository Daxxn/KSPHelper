using KSPModelLibrary;
using KSPModelLibrary.CalculatorModels.AntennaCalcModels;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
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
      private int _addPartCount = 1;
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
            var index = CalcAntennas.IndexOf(SelectedAntenna);
            CalcAntennas[index].Count++;
         }
         else
         {
            CalcAntennas.Add(SelectedAntenna);
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

      public int AddPartCount
      {
         get { return _addPartCount; }
         set
         {
            _addPartCount = value;
            OnPropertyChanged(nameof(AddPartCount));
         }
      }
      #endregion
   }
}
