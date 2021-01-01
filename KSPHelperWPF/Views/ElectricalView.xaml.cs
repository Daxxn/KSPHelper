using KSPHelperWPF.ViewModels;
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

namespace KSPHelperWPF.Views
{
   /// <summary>
   /// Interaction logic for ElectricalView.xaml
   /// </summary>
   public partial class ElectricalView : UserControl
   {
      private static double ScrollSensitivity { get; } = 0.3;
      private static double FineScrollSensitivity { get; } = 0.1;
      public ElectricalView(ElectricalViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
         InitEvents(vm);
      }

      private void InitEvents(ElectricalViewModel vm)
      {
         //CalcTestButton.Click += vm.CalcTestEvent;
      }

      private void PartsListScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
      {
         if (PartsListScrollViewer.HorizontalScrollBarVisibility == ScrollBarVisibility.Visible)
         {
            //PartsListScrollViewer.ExtentHeight
         }
      }

      private void PartsList_MouseWheel(object sender, MouseWheelEventArgs e)
      {
         if (PartsListScrollViewer.HorizontalScrollBarVisibility == ScrollBarVisibility.Visible)
         {
            //PartsListScrollViewer.
         }
      }
      private void ListViewScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
      {
         //ScrollViewer scv = (ScrollViewer)sender;
         PartsListScrollViewer.ScrollToHorizontalOffset(
            PartsListScrollViewer.HorizontalOffset - (e.Delta * (e.RightButton == MouseButtonState.Pressed ? FineScrollSensitivity : ScrollSensitivity))
         );
         e.Handled = true;
      }
   }
}
