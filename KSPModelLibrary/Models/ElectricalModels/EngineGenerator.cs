using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public class EngineGenerator : IGenerator
   {
      #region - Fields & Properties
      public double GenRate { get; set; }
      public TimeDivision TimeDiv { get; set; }
      public double Mass { get; set; }

      #endregion

      #region - Constructors
      public EngineGenerator() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
