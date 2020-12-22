using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary
{
   public static class ParseMethods
   {

      #region - Methods
      public static double ParseDouble(string input)
      {
         bool success = Double.TryParse(input, out double result);
         if (success)
         {
            return result;
         }
         else
         {
            return 0;
         }
      }
      public static int ParseInt(string input)
      {
         bool success = Int32.TryParse(input, out int result);
         if (success)
         {
            return result;
         }
         else
         {
            return 0;
         }
      }
      public static bool ParseBool(string input)
      {
         bool success = Boolean.TryParse(input, out bool result);
         if (success)
         {
            return result;
         }
         else
         {
            return false;
         }
      }

      public static TEnum ParseEnum<TEnum>(Type enumType, string input) where TEnum : notnull
      {
         try
         {
            return (TEnum)Enum.Parse(enumType, input);
         }
         catch (Exception)
         {
            throw;
         }
      }
      #endregion
   }
}
