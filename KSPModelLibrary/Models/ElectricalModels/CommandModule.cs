using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public class CommandModule : IBattery, ILoad
   {
      #region - Fields & Properties
      public double Mass { get; set; }
      public uint Capacity { get; set; }
      public double DrainRate { get; set; }
      public TimeDivision TimeDiv { get; set; }
      #endregion

      #region - Constructors
      public CommandModule() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
