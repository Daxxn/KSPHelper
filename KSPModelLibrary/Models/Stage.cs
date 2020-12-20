using KSPModelLibrary.Models.ElectricalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Models
{
   public class Stage
   {
      #region - Fields & Properties
      public int StageIndex { get; set; }
      public Electrical ElectricalData { get; set; }
      public List<IPart> Parts { get; set; }
      #endregion

      #region - Constructors
      public Stage() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
