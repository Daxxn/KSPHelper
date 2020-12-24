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
using System.Windows.Shapes;

namespace KSPHelperWPF.Views
{
   /// <summary>
   /// Interaction logic for ExceptionDialog.xaml
   /// </summary>
   public partial class ExceptionDialog : Window
   {
      public ExceptionDialog( Exception exe )
      {
         ExceptionDialogViewModel vm = new ExceptionDialogViewModel(exe);
         InitializeComponent();
         DataContext = vm;
      }
   }
}
