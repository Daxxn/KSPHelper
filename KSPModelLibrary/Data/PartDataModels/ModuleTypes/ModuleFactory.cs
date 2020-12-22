using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels.ModuleTypes
{
   public class ModuleFactory
   {
      public static readonly Dictionary<ModuleType, Func<IModule>> Selector = new Dictionary<ModuleType, Func<IModule>>
      {
         { ModuleType.ModuleCommand, () => new CommandModule() },
         { ModuleType.ModuleDataTransmitter, () => new CommsModule() },
         { ModuleType.ModuleEnginesFX, () => new EngineModule() },
         { ModuleType.ModuleReactionWheel, () => new ReactionWheelModule() },
         { ModuleType.ModuleScienceExperiment, () => new ScienceModule() },
         { ModuleType.ModuleDeployableSolarPanel, () => new SolarPanelModule() },
         { ModuleType.ModuleDecouple, () => new DecoupleModule() }
      };
   }
}
