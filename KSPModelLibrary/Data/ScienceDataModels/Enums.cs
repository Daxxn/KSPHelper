using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.ScienceDataModels
{
   public enum SituationType
   {
      SrfLanded = 1,
      SrfSplashed = 2,
      FlyingLow = 4,
      FlyingHigh = 8,
      InSpaceLow = 16,
      InSpaceHigh = 32,

      NULL = 0,
   }
}
