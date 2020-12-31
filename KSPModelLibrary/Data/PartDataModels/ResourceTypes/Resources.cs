using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ResourceTypes
{
   public class ElectricalResource : BaseResource, IResource, IElectrical { }
   public class LiquidFuelResource : BaseResource, IResource { }
   public class MonoPorpellentResource : BaseResource, IResource { }
   public class OxidizerResource : BaseResource, IResource { }
   public class XenonResource : BaseResource, IResource { }
   public class AirIntakeResource : BaseResource, IResource { }
   public class SolidFuelResource : BaseResource, IResource { }
   public class OreResource : BaseResource, IResource { }
}
