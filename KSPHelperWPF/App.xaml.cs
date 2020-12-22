using ConfigReaderLibrary;
using KSPHelperWPF.ViewModels;
using KSPModelLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace KSPHelperWPF
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
      protected override void OnStartup(StartupEventArgs e)
      {
         PathSettings.OnStartup();
         var mainView = new MainWindow(MainViewModel.Instance);
         mainView.Show();
      }

      protected override void OnExit(ExitEventArgs e)
      {
         PathSettings.OnExit();
         base.OnExit(e);
      }
   }
}
