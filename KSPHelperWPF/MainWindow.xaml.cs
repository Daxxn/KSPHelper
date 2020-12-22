﻿using KSPHelperWPF.ViewModels;
using KSPHelperWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSPHelperWPF
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow(MainViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
         ElectricalTab.Content = new ElectricalView(vm.ElectricalVM);
         CommsTab.Content = new CommsView(vm.CommsVM);
         InitEvents(vm);
      }

      private void InitEvents(MainViewModel vm)
      {
         GameDataReaderButton.Click += vm.GameDataReadEvent;
      }
   }
}
