using KSPModelLibrary.CraftParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class CommsViewModel : ViewModel
   {
      #region - Fields & Properties
      public CraftModel _craft;
      #endregion

      #region - Constructors
      public CommsViewModel()
      {
         MainViewModel.OpenNewCraftEvent += OpenNewCraftEvent;
      }

      private void OpenNewCraftEvent(object sender, Events.OpenCraftEventArgs e)
      {
         Craft = e.Craft;
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties
      public CraftModel Craft
      {
         get { return _craft; }
         set
         {
            _craft = value;
            OnPropertyChanged(nameof(Craft));
         }
      }
      #endregion
   }
}
