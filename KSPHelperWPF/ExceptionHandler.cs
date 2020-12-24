using KSPHelperWPF.Views;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace KSPHelperWPF
{
   public static class ExceptionHandler
   {
      public static void ShowException(Exception ex)
      {
         ExceptionDialog dialog = new ExceptionDialog(ex);
         dialog.ShowDialog();
      }
   }
}
