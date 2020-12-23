using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   public enum ModuleType
   {
      ModuleCommand,
      ModuleDataTransmitter,
      ModuleEngines,
      ModuleEnginesFX,
      MultiModeEngine,
      ModuleReactionWheel,
      ModuleScienceExperiment,
      ModuleDeployableSolarPanel,
      ModuleDecouple,
      ModuleResourceIntake,
      ModuleAlternator,
      ModuleGenerator,
      ModuleResourceConverter,
      ModuleResourceHarvester,
      ModuleAsteroidDrill,
      ModuleActiveRadiator,
      ModuleLight,
      ModuleRCSFX,
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
      IntakeAir,
      SolidFuel,
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
      SolidBooster,
      Turbine,
   }

   public enum FlowMode
   {
      STAGE_PRIORITY_FLOW,
   }

   public enum DataType
   {
      PartData,
      ScienceData,
   }
}
