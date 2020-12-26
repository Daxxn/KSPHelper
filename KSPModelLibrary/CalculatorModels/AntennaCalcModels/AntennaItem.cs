using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CalculatorModels.AntennaCalcModels
{
   public class AntennaItem : BaseModel
   {
      #region - Fields & Properties
      public Part Part { get; set; }
      public CommsModule AntennaModule { get; set; }
      private int _count = 1;
      #endregion

      #region - Constructors
      public AntennaItem() { }
      public AntennaItem(Part part)
      {
         Part = part;
         AntennaModule = part.GetModule<CommsModule>();
      }
      #endregion

      #region - Methods
      #endregion

      #region - Full Properties
      public int Count
      {
         get { return _count; }
         set
         {
            _count = value;
            OnPropertyChanged(nameof(Count));
         }
      }
      #endregion
   }
}
