using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class ExceptionDialogViewModel : ViewModel
   {
      private Exception _exception;
      public ExceptionDialogViewModel( Exception exe )
      {
         Exception = exe;
      }

      public Exception Exception
      {
         get { return _exception; }
         set
         {
            _exception = value;
            OnPropertyChanged(nameof(Exception));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Type));
         }
      }

      public string Title
      {
         get
         {
            string temp = "Error!! ";
            if (_exception != null)
            {
               if (_exception.Message.Length > 40)
               {
                  temp += _exception.Message.Substring(0, 40);
               }
               else
               {
                  temp += _exception.Message;
               }
            }
            return temp;
         }
      }

      public string Type
      {
         get
         {
            return _exception.GetType().Name;
         }
      }

      public string InnerType
      {
         get
         {
            if (_exception is null || _exception.InnerException is null)
            {
               return null;
            }
            return _exception.InnerException.GetType().Name;
         }
      }
   }
}
