using System;
using System.Collections.Generic;

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
         { ModuleType.ModuleDecouple, () => new DecoupleModule() },
         { ModuleType.ModuleAlternator, () => new AlternatorModule() },
         { ModuleType.ModuleResourceIntake, () => new AirIntakeModule() }
      };

      public static bool PartHasModule<TModule>(Part part) where TModule : IModule
      {
         bool result = false;
         if (part.Modules.Count > 0)
         {
            foreach (var module in part.Modules)
            {
               if (module is TModule)
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
