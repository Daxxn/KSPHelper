using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CraftParser
{
   public class Stage
   {
      #region - Fields & Properties
      public int StageNumber { get; set; }
      public List<PartRef> Parts { get; set; } = new List<PartRef>();
      #endregion

      #region - Constructors
      public Stage(int stageNumber) => StageNumber = stageNumber;
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
