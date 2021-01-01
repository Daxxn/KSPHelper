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
      private static readonly double ScrollSensitivity = 0.3;
      private static readonly double FineScrollSensitivity = 0.1;

      private bool ShiftKeyPressed { get; set; } = false;
      private bool CtrlKeyPressed { get; set; } = false;
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

      private void PartsListScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
      {
         if (!CtrlKeyPressed)
         {
            PartsListScrollViewer.ScrollToHorizontalOffset(
               PartsListScrollViewer.HorizontalOffset - (e.Delta * (ShiftKeyPressed ? FineScrollSensitivity : ScrollSensitivity))
            );
         }
         else
         {
            PartsListScrollViewer.ScrollToVerticalOffset(
               PartsListScrollViewer.VerticalOffset - (e.Delta * (ShiftKeyPressed ? FineScrollSensitivity : ScrollSensitivity))
            );
         }
         e.Handled = true;
      }

      private void StagesListScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
      {
         if (CtrlKeyPressed)
         {
            StagesScrollViewer.ScrollToHorizontalOffset(
               StagesScrollViewer.HorizontalOffset - (e.Delta * (ShiftKeyPressed ? FineScrollSensitivity : ScrollSensitivity))
            );
         }
         else
         {
            StagesScrollViewer.ScrollToVerticalOffset(
               StagesScrollViewer.VerticalOffset - (e.Delta * (ShiftKeyPressed ? FineScrollSensitivity : ScrollSensitivity))
            );
         }
         e.Handled = true;
      }

      private void UserControl_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.LeftShift)
         {
            ShiftKeyPressed = true;
         }
         if (e.Key == Key.LeftCtrl)
         {
            CtrlKeyPressed = true;
         }
      }

      private void UserControl_KeyUp(object sender, KeyEventArgs e)
      {
         if (e.Key == Key.LeftShift)
         {
            ShiftKeyPressed = false;
         }
         if (e.Key == Key.LeftCtrl)
         {
            CtrlKeyPressed = false;
         }
      }
   }
}
