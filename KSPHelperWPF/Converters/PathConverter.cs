using KSPHelperWPF.ViewModels;
using KSPModelLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace KSPHelperWPF.Converters
{
   public static class ColorTypes
   {
      public static SolidColorBrush Good { get; } = new SolidColorBrush
      {
         Color = new Color
         { R = 180, G = 255, B = 180 },
      };

      public static SolidColorBrush Bad { get; } = new SolidColorBrush
      {
         Color = new Color { R = 255, G = 180, B = 180 },
      };
   }

   public class PathConverter : IValueConverter
   {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
         //var param = (FileType)parameter;
         var val = (string)value;
         return Directory.Exists(val) ? ColorTypes.Good : ColorTypes.Bad;
         //if (param == FileType.Directory)
         //{
         //}
         //else
         //{
         //   return File.Exists(val) ? ColorTypes.Good : ColorTypes.Bad;
         //}
      }

      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
         return null;
      }
   }
}
