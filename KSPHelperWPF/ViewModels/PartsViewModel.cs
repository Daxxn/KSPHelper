﻿using KSPModelLibrary.CraftParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class PartsViewModel : ViewModel
   {
      #region - Fields & Properties
      private CraftModel _craft = CraftDataReader.Craft;
      private PartRef _selectedPart;
      #endregion

      #region - Constructors
      public PartsViewModel() { }
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

      public PartRef SelectedPart
      {
         get { return _selectedPart; }
         set
         {
            _selectedPart = value;
            OnPropertyChanged(nameof(SelectedPart));
         }
      }
      #endregion
   }
}
