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
      #region - Fields & Properties
      //private static string[] Keys { get; set; } = new string[]
      //{
      //   "MODULE",
      //   "RESOURCE"
      //};

      //public static string[] Values { get; set; } = new string[]
      //{
      //   "name",
      //   "title",
      //   "maxTemp"
      //};

      //public static Dictionary<string, string[]> ModuleProperties { get; set; } = new Dictionary<string, string[]>
      //{
      //   { "ModuleDeployableSolarPanel", new string[] { "chargeRate", "resourceName" } }
      //};
      #endregion

      #region - Methods
      public static void Build(List<BaseObject> data)
      {
         PartData parts = new PartData();

         foreach (var partData in data)
         {
            if (partData is null)
            {
               continue;
            }
            var foundPart = partData.GetChild("PART");
            if (foundPart != null)
            {
               parts.Parts.Add(BuildPart(foundPart));
            }
         }


      }

      private static Part BuildPart(BaseObject part)
      {
         var newPart = new Part();
         var moduleData = part.GetChildren("MODULE");
         var resourceData = part.GetChildren("RESOURCE");

         foreach (var prop in part.Values)
         {
            if (Part.SearchProps.ContainsKey(prop.Key))
            {
               Part.SearchProps[prop.Key](prop.Value, newPart);
            }
         }

         BuildModules(moduleData, newPart);
         BuildResources(resourceData, newPart);

         return newPart;
      }

      public static void BuildModules(List<BaseObject> moduleData, Part part)
      {
         foreach (var rawModule in moduleData)
         {
            foreach (var moduleType in (ModuleType[])Enum.GetValues(typeof(ModuleType)))
            {
               var newModule = ModuleFactory.Selector[moduleType]();
               if (rawModule.Values.ContainsKey("name"))
               {
                  if (rawModule.Values["name"] == Enum.GetName(typeof(ModuleType), moduleType))
                  {
                     string newModuleName = rawModule.Values["name"];
                     newModule.Name = newModuleName;
                     foreach (var keyVal in rawModule.Values)
                     {
                        newModule.SetProp(keyVal.Key, keyVal.Value);
                     }
                     if (!part.Modules.ContainsKey(newModuleName))
                     {
                        part.Modules.Add(rawModule.Values["name"], newModule); 
                     }
                  }
               }

               // Need to test ALL this
               switch (moduleType)
               {
                  case ModuleType.ModuleEnginesFX:
                     if (rawModule.Children.Count > 0)
                     {
                        var tempModule = newModule as EngineModule;
                        foreach (var subModule in rawModule.Children)
                        {
                           if (subModule.Values.ContainsKey("name"))
                           {
                              if (subModule.Key == "PROPELLANT")
                              {
                                 if (tempModule != null)
                                 {
                                    var newPropModule = new PropellentModule();
                                    newPropModule.Name = subModule.Values["name"];
                                    foreach (var keyVal in subModule.Values)
                                    {
                                       newPropModule.SetProp(keyVal.Key, keyVal.Value);
                                    }
                                    tempModule.PropellentRequirements.Add(newPropModule);
                                 }
                              }
                           }
                           if (subModule.Key == "RESOURCE")
                           {
                              
                           }
                        }
                     }
                     break;
                  case ModuleType.ModuleReactionWheel:
                     if (rawModule.Children.Count > 0)
                     {
                        var tempModule = newModule as ReactionWheelModule;
                        foreach (var subModule in rawModule.Children)
                        {
                           if (subModule.Key == "RESOURCE")
                           {
                              tempModule.Electrical = new ElectricalLoadModule();
                              tempModule.Name = subModule.Values["name"];
                              foreach (var keyVal in subModule.Values)
                              {
                                 tempModule.Electrical.SetProp(keyVal.Key, keyVal.Value);
                              }
                           }
                        }
                     }
                     break;
                  default:
                     break;
               }
            }
         }
      }

      public static void BuildResources(List<BaseObject> moduleData, Part part)
      {

         foreach (var rawModule in moduleData)
         {
            foreach (var resourceType in (ResourceType[])Enum.GetValues(typeof(ResourceType)))
            {
               if (rawModule.Values.ContainsKey("name"))
               {
                  if (rawModule.Values["name"] == Enum.GetName(typeof(ResourceType), resourceType))
                  {
                     var newResource = ResourceFactory.Selector[resourceType]();
                     newResource.Name = rawModule.Values["name"];
                     foreach (var keyVal in rawModule.Values)
                     {
                        newResource.SetProp(keyVal.Key, keyVal.Value);
                     }
                     part.Resources.Add(rawModule.Values["name"], newResource);
                  }
               }
            }
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
