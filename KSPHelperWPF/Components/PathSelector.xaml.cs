using KSPHelperWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KSPHelperWPF.Components
{
   public enum FileType
   {
      File,
      Directory,
   }
   /// <summary>
   /// Interaction logic for PathSelector.xaml
   /// </summary>
   public partial class PathSelector : UserControl
   {
      public FileType Type
      {
         get { return (FileType)GetValue(TypeProperty); }
         set { SetValue(TypeProperty, value); }
      }

      // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty TypeProperty =
          DependencyProperty.Register("Type", typeof(FileType), typeof(PathSelector), new PropertyMetadata(FileType.File));



      public bool Exists
      {
         get { return (bool)GetValue(ExistsProperty); }
         set { SetValue(ExistsProperty, value); }
      }

      // Using a DependencyProperty as the backing store for Exists.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty ExistsProperty =
          DependencyProperty.Register("Exists", typeof(bool), typeof(PathSelector), new PropertyMetadata(false));



      public string Title
      {
         get { return (string)GetValue(TitleProperty); }
         set { SetValue(TitleProperty, value); }
      }

      // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string), typeof(PathSelector), new PropertyMetadata(""));



      public string Path
      {
         get { return (string)GetValue(PathProperty); }
         set { SetValue(PathProperty, value); }
      }

      // Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
      public static readonly DependencyProperty PathProperty =
          DependencyProperty.Register("Path", typeof(string), typeof(PathSelector), new PropertyMetadata(""));


      public PathSelector( )
      {
         InitializeComponent();
      }

      private void CheckExists( )
      {
         if (Type == FileType.File)
         {
            Exists = File.Exists(Path);
         }
         else if (Type == FileType.Directory)
         {
            Exists = Directory.Exists(Path);
         }
      }

      private void TextBox_TextChanged( object sender, TextChangedEventArgs e )
      {
         var text = (e.Source as TextBox).Text;
         Path = text;
         CheckExists();
      }
   }
}
