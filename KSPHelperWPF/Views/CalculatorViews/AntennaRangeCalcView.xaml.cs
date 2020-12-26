using KSPHelperWPF.ViewModels.CalculatorViewModels;
using KSPModelLibrary.Data.WorldDataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSPHelperWPF.Views.CalculatorViews
{
   /// <summary>
   /// Interaction logic for AntennaRangeCalcView.xaml
   /// </summary>
   public partial class AntennaRangeCalcView : UserControl
   {
      public AntennaRangeCalcView(AntennaRangeCalcViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
         InitEvents(vm);

         TrackingStationLevel.ItemsSource = KerbalSpaceCenter.DSNRanges.Keys;
      }

      private void InitEvents(AntennaRangeCalcViewModel vm)
      {
         AllPartsListView.MouseDoubleClick += vm.AddPartEvent;
         AllPartsListView.MouseDoubleClick += vm.CalcVesselRangeEvent;
         CalcPartsListView.MouseDoubleClick += vm.RemovePartEvent;
         CalcPartsListView.MouseDoubleClick += vm.CalcVesselRangeEvent;
         
         AddPartButton.Click += vm.AddPartButtonEvent;
         AddPartButton.Click += vm.CalcVesselRangeEvent;
         AddCountUpButton.Click += vm.AddCountUpEvent;
         AddCountDownButton.Click += vm.AddCountDownEvent;
         ManualCalcButton.Click += vm.CalcVesselRangeEvent;
      }
   }
}
