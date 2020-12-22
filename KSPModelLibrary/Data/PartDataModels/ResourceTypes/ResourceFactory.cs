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
         { ResourceType.LiquidFuel, () => new LiquidFuelResource() },
         { ResourceType.MonoPropellant, () => new MonoPorpellentResource() },
         { ResourceType.Oxidizer, () => new OxidizerResource() },
         { ResourceType.XenonGas, () => new XenonResource() }
      };
   }
}
