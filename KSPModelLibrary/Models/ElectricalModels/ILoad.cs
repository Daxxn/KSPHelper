using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public interface ILoad : IPart
   {
      #region - Properties
      double DrainRate { get; set; }
      TimeDivision TimeDiv { get; set; }
      #endregion

      #region - Methods

      #endregion
   }
}
