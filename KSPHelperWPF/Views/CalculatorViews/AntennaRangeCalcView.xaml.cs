using KSPHelperWPF.ViewModels.CalculatorViewModels;
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
      }

      private void InitEvents(AntennaRangeCalcViewModel vm)
      {
         AllPartsListView.MouseDoubleClick += vm.AddPartEvent;
         AddPartButton.Click += vm.AddPartEvent;
         AddCountUpButton.Click += vm.AddCountUpEvent;
         AddCountDownButton.Click += vm.AddCountDownEvent;
      }
   }
}
