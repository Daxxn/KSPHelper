using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KSPModelLibrary.CalculatorModels.AntennaCalcModels
{
   public class BaseModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

      public void OnPropertyChanged(string name)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
      }
   }
}
