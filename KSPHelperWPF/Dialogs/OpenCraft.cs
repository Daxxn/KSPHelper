using KSPModelLibrary;
using KSPModelLibrary.CraftParser;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.Dialogs
{
   public static class OpenCraft
   {
      #region - Fields & Properties

      #endregion

      #region - Methods
      public static void OpenDialog()
      {
         OpenFileDialog dialog = new OpenFileDialog()
         {
            Multiselect = false,
            InitialDirectory = PathSettings.SettingsModel.CraftFolder,
            Filter = PathSettings.SettingsModel.CraftDialogFilter,
            DefaultExt = ".craft",
            Title = "Open a craft file."
         };
         if (dialog.ShowDialog() == true)
         {
            CraftDataReader.ParseCraftFile(dialog.FileName);
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
