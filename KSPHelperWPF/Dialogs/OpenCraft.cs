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
      public static CraftModel OpenDialog()
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
            return CraftDataReader.ParseCraftFile(dialog.FileName);
         }
         else
         {
            return null;
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
