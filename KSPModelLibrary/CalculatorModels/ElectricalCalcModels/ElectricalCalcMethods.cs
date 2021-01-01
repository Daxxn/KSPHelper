using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CalculatorModels.ElectricalCalcModels
{
   public static class ElectricalCalcMethods
   {
      #region - Methods
      public static TimeSpan BatteryChargeTime(double battCap, double chargeRate)
      {
         if (battCap > 0)
         {
            if (chargeRate > 0)
            {
               return TimeSpan.FromSeconds(battCap / chargeRate);
            }
            else
            {
               return TimeSpan.Zero;
            }
         }
         else
         {
            return TimeSpan.Zero;
         }
      }

      public static double ChargeRate(double generators, double loads)
      {
         return generators - loads;
      }

      public static double ThrottleChargeRate(double alternators, double loads, double throttle = 1)
      {
         return (alternators - loads) * throttle;
      }
      #endregion
   }
}
