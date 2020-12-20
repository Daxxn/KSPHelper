using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class ViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged = (o, e) => { };

      public void OnPropertyChanged(string name)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
