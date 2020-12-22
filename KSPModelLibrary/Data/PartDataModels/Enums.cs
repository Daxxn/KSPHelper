using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   public enum ModuleType
   {
      ModuleCommand,
      ModuleDataTransmitter,
      ModuleEnginesFX,
      ModuleReactionWheel,
      ModuleScienceExperiment,
      ModuleDeployableSolarPanel,
   }

   /// <summary>
   /// Basically a "Tank" of some kind.
   /// </summary>
   public enum ResourceType
   {
      ElectricCharge,
      MonoPropellant,
      LiquidFuel,
      Oxidizer,
      XenonGas,
   }

   public enum AntennaType
   {
      INTERNAL,
      DIRECT,
      RELAY
   }

   public enum EngineType
   {
      LiquidFuel,
   }
}
