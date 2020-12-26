using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CraftParser
{
   public class CraftModel
   {
      #region - Fields & Properties
      public string CraftName { get; set; }
      public string CraftDesc { get; set; }
      public BuildingType Building { get; set; }
      public PartRef RootPart { get; set; }
      public Dictionary<int, Stage> Stages { get; set; } = new Dictionary<int, Stage>();
      #endregion

      #region - Constructors
      public CraftModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
