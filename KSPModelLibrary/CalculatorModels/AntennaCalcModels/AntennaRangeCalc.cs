using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using KSPModelLibrary.Data.WorldDataModels;

namespace KSPModelLibrary.CalculatorModels.AntennaCalcModels
{
   public class AntennaRangeCalc
   {
      #region - Fields & Properties
      public const double CombinabilityExp = 0.75;
      #endregion

      #region - Constructors
      public AntennaRangeCalc() { }
      #endregion

      #region - Methods
      public static (double strongest, double range) CalcRange(List<AntennaItem> antennas, AntennaItem strongest)
      {
         var strongestAntennaPower = strongest.AntennaModule.AntennaPower;
         var powerSums = antennas.Sum(ant => ant.AntennaModule.AntennaPower);
         return (strongestAntennaPower, CalcRangeFormula(powerSums, strongestAntennaPower));
      }

      public static double CalcRangeUpdate(List<AntennaItem> antennas, AntennaItem strongest)
      {
         if (antennas.Count > 1)
         {
            var strongestAntennaPower = strongest.AntennaModule.AntennaPower;
            var powerSums = antennas.Sum(ant => ant.AntennaModule.AntennaPower * ant.Count);
            return CalcRangeFormula(powerSums, strongestAntennaPower);
         }
         else
         {
            return strongest.AntennaModule.AntennaPower;
         }
      }

      public static double CalcRangeUpdate(int dsnLevel, double vesselRange)
      {
         if (KerbalSpaceCenter.DSNRanges.ContainsKey(dsnLevel))
         {
            var dsnRange = KerbalSpaceCenter.DSNRanges[dsnLevel].Range;
            return dsnRange * vesselRange;
         }
         else
         {
            return 0;
         }
      }

      public static AntennaItem StrongestAntenna(List<AntennaItem> antennas)
      {
         if (antennas.Count > 1)
         {
            AntennaItem strongest = antennas[0];
            foreach (var antenna in antennas)
            {
               if (strongest.AntennaModule.AntennaPower < antenna.AntennaModule.AntennaPower)
               {
                  strongest = antenna;
               }
            }
            return strongest;
         }
         else if (antennas.Count == 1)
         {
            return antennas[0];
         }
         else
         {
            return null;
         }
      }

      private static double CalcRangeFormula(double powerSums, double strongest)
      {
         return strongest * ((powerSums / strongest) * CombinabilityExp);
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
