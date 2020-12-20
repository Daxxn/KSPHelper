using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models.ElectricalModels
{
   public class Electrical
   {
      #region - Fields & Properties
      public List<IBattery> Batteries { get; set; }
      public List<IGenerator> Sources { get; set; }
      public List<ILoad> Loads { get; set; }
      #endregion

      #region - Constructors
      public Electrical() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
