using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class MainViewModel : ViewModel
   {
      #region - Fields & Properties
      private static MainViewModel _instance = new MainViewModel();

      #region View Models
      public ElectricalViewModel ElectricalVM { get; set; } = new ElectricalViewModel();
      public CommsViewModel CommsVM { get; set; } = new CommsViewModel();
      #endregion
      #endregion

      #region - Constructors
      private MainViewModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties
      public static MainViewModel Instance
      {
         get
         {
            if (_instance is null)
            {
               _instance = new MainViewModel();
            }
            return _instance;
         }
      }
      #endregion
   }
}
