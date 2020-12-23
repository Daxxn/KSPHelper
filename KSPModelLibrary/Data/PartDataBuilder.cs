using ConfigReaderLibrary;
using KSPModelLibrary.Data.PartDataModels;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using KSPModelLibrary.Data.PartDataModels.ResourceTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data
{
   public static class PartDataBuilder
   {
      #region - Methods
      /// <summary>
      /// Parses the parts data from a .cfg file.
      /// </summary>
      /// <param name="data">The data from the config file.</param>
      /// <returns>PartData of all parsed parts.</returns>
      public static PartData Build(List<BaseObject> data)
      {

         if (data != null)
         {
            PartData parts = new PartData();

            foreach (var partData in data)
            {
               if (partData is null)
               {
                  continue;
               }
               var foundPartData = partData.GetChild("PART");
               if (foundPartData != null)
               {
                  var newPart = BuildPart(foundPartData);
                  if (newPart != null)
                  {
                     parts.Parts.Add(newPart);
                  }
               }
            }

            return parts;
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Builds a single part from the config data.
      /// </summary>
      /// <param name="partData">object with the PART tag.</param>
      /// <returns>New part with Modules/Resources included.</returns>
      private static Part BuildPart(BaseObject partData)
      {
         if (partData != null)
         {
            var newPart = new Part();

            foreach (var prop in partData.Values)
            {
               if (Part.SearchProps.ContainsKey(prop.Key))
               {
                  Part.SearchProps[prop.Key](prop.Value, newPart);
               }
            }

            BuildModules(partData, newPart);
            BuildResources(partData, newPart);

            return newPart;
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Parses modules from the part.
      /// </summary>
      /// <param name="root">The config part data.</param>
      /// <param name="part">The instance of the new part.</param>
      public static void BuildModules(BaseObject root, Part part)
      {
         foreach (var moduleType in (ModuleType[])Enum.GetValues(typeof(ModuleType)))
         {
            BuildModule(root, part, moduleType);
         }
      }

      /// <summary>
      /// Gets all modules pertaining to the module type given.
      /// </summary>
      /// <param name="root">The config part data.</param>
      /// <param name="part">The instance of the new part.</param>
      /// <param name="type">The type of module to search for.</param>
      public static void BuildModule(BaseObject root, Part part, ModuleType type)
      {
         foreach (var module in GetModules(root, type))
         {
            if (module is null)
            {
               continue;
            }
            switch (type)
            {
               case ModuleType.ModuleCommand:
                  part.Modules.Add(CommandModule.BuildModule(module));
                  break;
               case ModuleType.ModuleDataTransmitter:
                  part.Modules.Add(CommsModule.BuildModule(module));
                  break;
               case ModuleType.ModuleEngines:
                  part.Modules.Add(EngineModule.BuildModule(module));
                  break;
               case ModuleType.ModuleEnginesFX:
                  part.Modules.Add(EngineModule.BuildModule(module));
                  break;
               case ModuleType.MultiModeEngine:
                  part.Modules.Add(MultiModeEngineModule.BuildModule(module));
                  break;
               case ModuleType.ModuleReactionWheel:
                  part.Modules.Add(ReactionWheelModule.BuildModule(module));
                  break;
               case ModuleType.ModuleScienceExperiment:
                  part.Modules.Add(ScienceModule.BuildModule(module));
                  break;
               case ModuleType.ModuleDeployableSolarPanel:
                  part.Modules.Add(SolarPanelModule.BuildModule(module));
                  break;
               case ModuleType.ModuleDecouple:
                  part.Modules.Add(DecoupleModule.BuildModule(module));
                  break;
               case ModuleType.ModuleResourceIntake:
                  part.Modules.Add(AirIntakeModule.BuildModule(module));
                  break;
               case ModuleType.ModuleAlternator:
                  part.Modules.Add(AlternatorModule.BuildModule(module));
                  break;
               case ModuleType.ModuleGenerator:
                  part.Modules.Add(GeneratorModule.BuildModule(module));
                  break;
               case ModuleType.ModuleResourceConverter:
                  part.Modules.Add(ResourceConverterModule.BuildModule(module));
                  break;
               case ModuleType.ModuleResourceHarvester:
                  part.Modules.Add(ResourceHarvesterModule.BuildModule(module));
                  break;
               case ModuleType.ModuleAsteroidDrill:
                  part.Modules.Add(ResourceAsteroidHarvesterModule.BuildModule(module));
                  break;
               case ModuleType.ModuleActiveRadiator:
                  part.Modules.Add(RadiatorModule.BuildModule(module));
                  break;
               case ModuleType.ModuleLight:
                  part.Modules.Add(LightModule.BuildModule(module));
                  break;
               case ModuleType.ModuleRCSFX:
                  part.Modules.Add(RCSModule.BuildModule(module));
                  break;
               default:
                  break;
            }
         }
      }

      /// <summary>
      /// Gets the module config data from the PART object tree.
      /// </summary>
      /// <param name="baseModule">The PART config object.</param>
      /// <param name="type">The type to search in the tree.</param>
      /// <returns>A list of all found objects matching the given type.</returns>
      private static List<BaseObject> GetModules(BaseObject baseModule, ModuleType type)
      {
         return baseModule.GetChildrenByProperty("name", type.ToString());
      }

      /// <summary>
      /// Builds resources from the PART object.
      /// </summary>
      /// <param name="root">The PART config object.</param>
      /// <param name="part">The instance of the new part.</param>
      public static void BuildResources(BaseObject root, Part part)
      {
         foreach (var obj in GetResources(root))
         {
            if (obj.Values.ContainsKey("name"))
            {
               bool success = Enum.TryParse(obj.Values["name"], out ResourceType type);
               if (success)
               {
                  var newResource = ResourceFactory.Selector[type]();
                  foreach (var kv in obj.Values)
                  {
                     newResource.SetProp(kv);
                  }
                  part.Resources.Add(newResource);
               }
            }
         }
      }

      /// <summary>
      /// Gets the resource config data from the PART object tree.
      /// </summary>
      /// <param name="root">The PART config object.</param>
      /// <returns>A list of all the resources for the part.</returns>
      private static List<BaseObject> GetResources(BaseObject root)
      {
         return root.GetChildren("RESOURCE");
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
