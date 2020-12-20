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
   /// Interaction logic for CommsView.xaml
   /// </summary>
   public partial class CommsView : UserControl
   {
      public CommsView(CommsViewModel vm)
      {
         InitializeComponent();
         DataContext = vm;
      }
   }
}
