using KSPModelLibrary.CraftParser;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPHelperWPF.Events
{
   public class OpenCraftEventArgs : EventArgs
   {
      public CraftModel Craft { get; private set; }

      public OpenCraftEventArgs(CraftModel craft)
      {
         Craft = craft;
      }
   }
}
