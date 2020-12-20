using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public interface IGenerator : IPart
   {
      #region - Fields & Properties
      double GenRate { get; set; }
      TimeDivision TimeDiv { get; set; }
      #endregion

      #region - Methods

      #endregion
   }
}
