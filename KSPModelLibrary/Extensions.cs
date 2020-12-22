﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSPModelLibrary
{
   public static class Extensions
   {
      public static void Deconstruct<T>(this IList<T> list, out T first, out IList<T> rest)
      {

         first = list.Count > 0 ? list[0] : default(T); // or throw
         rest = list.Skip(1).ToList();
      }

      public static void Deconstruct<T>(this IList<T> list, out T first, out T second, out IList<T> rest)
      {
         first = list.Count > 0 ? list[0] : default(T);
         second = list.Count > 1 ? list[1] : default(T);
         rest = list.Skip(2).ToList();
      }
      public static void Deconstruct<T>(this T[] list, out T first, out IList<T> rest)
      {

         first = list.Length > 0 ? list[0] : default(T);
         rest = list.Skip(1).ToList();
      }

      public static void Deconstruct<T>(this T[] list, out T first, out T second, out IList<T> rest)
      {
         first = list.Length > 0 ? list[0] : default(T);
         second = list.Length > 1 ? list[1] : default(T);
         rest = list.Skip(2).ToList();
      }
   }
}
