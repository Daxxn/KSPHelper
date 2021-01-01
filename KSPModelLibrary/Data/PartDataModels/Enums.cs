using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.PartDataModels
{
   /// <summary>
   /// Module type for each part. - Used for parsing.
   /// </summary>
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
      SCANsat,
      SCANexperiment,
   }

   /// <summary>
   /// Basically a "Tank/Container" of some kind.
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

   /// <summary>
   /// Specifies how antenna module works.
   /// </summary>
   public enum AntennaType
   {
      INTERNAL,
      DIRECT,
      RELAY
   }

   /// <summary>
   /// All Engine types.
   /// </summary>
   public enum EngineType
   {
      LiquidFuel,
      SolidBooster,
      Turbine,
   }

   /// <summary>
   /// Selects how fuel is used from the tanks. 
   /// </summary>
   public enum FlowMode
   {
      STAGE_PRIORITY_FLOW,
   }

   public enum DataType
   {
      PartData,
      ScienceData,
   }

   public enum VesselType
   {
      Probe,
      Lander,
      Rover,
      Ship,
   }
}
