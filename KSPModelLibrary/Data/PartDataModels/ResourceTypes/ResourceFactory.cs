using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ResourceTypes
{
   public static class ResourceFactory
   {
      public static readonly Dictionary<ResourceType, Func<IResource>> Selector = new Dictionary<ResourceType, Func<IResource>>
      {
         { ResourceType.ElectricCharge, () => new ElectricalResource() },
         { ResourceType.MonoPropellant, () => new MonoPorpellentResource() },
         { ResourceType.LiquidFuel, () => new LiquidFuelResource() },
         { ResourceType.Oxidizer, () => new OxidizerResource() },
         { ResourceType.XenonGas, () => new XenonResource() },
         { ResourceType.IntakeAir, () => new AirIntakeResource() },
         { ResourceType.SolidFuel, () => new SolidFuelResource() },
      };

      public static bool PartHasResource<TResource>(Part part) where TResource : IResource
      {
         bool result = false;
         if (part.Resources.Count > 0)
         {
            foreach (var module in part.Resources)
            {
               if (module is TResource)
               {
                  result = true;
                  break;
               }
            }
         }
         return result;
      }
   }
}
