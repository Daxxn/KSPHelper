using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public class ReactionWheel : ILoad
   {
      #region - Fields & Properties
      public double DrainRate { get; set; }
      public TimeDivision TimeDiv { get; set; }
      public int Torque { get; set; }
      public double Mass { get; set; }
      #endregion

      #region - Constructors
      public ReactionWheel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
