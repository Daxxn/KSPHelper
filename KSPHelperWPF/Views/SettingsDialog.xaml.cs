using KSPHelperWPF.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KSPHelperWPF.Views
{
   /// <summary>
   /// Interaction logic for SettingsDialog.xaml
   /// </summary>
   public partial class SettingsDialog : Window
   {
      public SettingsDialogViewModel VM { get; }
      public SettingsDialog( SettingsDialogViewModel vm )
      {
         InitializeComponent();
         DataContext = vm;
         VM = vm;
         InitEvents(vm);
      }

      private void InitEvents(SettingsDialogViewModel vm )
      {
         Closing += vm.WindowCloseEvent;
      }

      private void SettingsWindow_Closing( object sender, CancelEventArgs e )
      {

      }

      private void Add_Button_Click(object sender, RoutedEventArgs e)
      {
         VM.AddEvent(sender, e);
      }

      private void Button_Click(object sender, RoutedEventArgs e)
      {
         VM.ListDeleteEvent(sender, e);
      }
   }
}
