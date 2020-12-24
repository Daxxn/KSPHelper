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
   /// Interaction logic for CalculatorsView.xaml
   /// </summary>
   public partial class CalculatorsView : UserControl
   {
      public CalculatorsView(CalculatorsViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
         InitEvents(vm);

         AntennasTab.Content = new AntennaRangeCalcView(vm.AntennasVM);
      }

      private void InitEvents(CalculatorsViewModel vm)
      {

      }
   }
}
