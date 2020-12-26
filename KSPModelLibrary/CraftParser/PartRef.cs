using KSPModelLibrary.Data.PartDataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CraftParser
{
   public class PartRef
   {
      #region - Fields & Properties
      public string Name { get; set; }
      public Part Part { get; set; }
      #endregion

      #region - Constructors
      public PartRef() { }
      #endregion

      #region - Methods
      public override string ToString()
      {
         return $"{Name} {Part}";
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
