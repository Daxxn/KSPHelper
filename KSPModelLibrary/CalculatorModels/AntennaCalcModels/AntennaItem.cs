using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CalculatorModels.AntennaCalcModels
{
   public class AntennaItem
   {
      #region - Fields & Properties
      public Part Part { get; set; }
      public CommsModule AntennaModule { get; set; }
      public int Count { get; set; }
      #endregion

      #region - Constructors
      public AntennaItem(Part part)
      {
         Part = part;
         AntennaModule = part.GetModule<CommsModule>();
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
