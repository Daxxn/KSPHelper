using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.WorldDataModels
{
   public class KerbalSpaceCenter
   {
      #region - Fields & Properties
      public static readonly Dictionary<int, DSNModel> DSNRanges = new Dictionary<int, DSNModel>()
      {
         { 1, new DSNModel{Range=2000000, UpgradeCost=0 } },
         { 2, new DSNModel{Range=50000000, UpgradeCost=150000, OtherPerks="Orbital Tracks Visible, Maneuver nodes" } },
         { 3, new DSNModel{Range=250000000, UpgradeCost=563000, OtherPerks="Track unknown objects" } }
      };

      #endregion

      #region - Constructors
      public KerbalSpaceCenter() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
