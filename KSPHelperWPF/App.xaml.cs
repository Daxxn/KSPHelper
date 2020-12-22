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
         GameDataReader.ReadGameData(@"B:\Games\steamapps\common\Kerbal Space Program\GameData\Squad\Parts\FuelTank");
         //GameDataReader.ReadGameDataAsync(@"B:\Games\steamapps\common\Kerbal Space Program\GameData\Squad\Parts\Wheel").Wait();
         //var mainView = new MainWindow(MainViewModel.Instance);
         //mainView.Show();
      }
   }
}
