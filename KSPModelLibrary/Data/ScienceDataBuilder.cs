using ConfigReaderLibrary;
using KSPModelLibrary.Data.ScienceDataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data
{
   public static class ScienceDataBuilder
   {
      #region - Fields & Properties

      #endregion

      #region - Methods
      public static Science BuildData(BaseObject root)
      {
         if (root != null)
         {
            var newScience = new Science();

            foreach (var experimentData in root.Children)
            {
               newScience.Experiments.Add(Experiment.Build(experimentData));
            }

            return newScience;
         }
         else
         {
            return null;
         }
      }

      public static Science BuildData(List<BaseObject> rootObjects)
      {
         if (rootObjects != null || rootObjects.Count > 0)
         {
            var newScience = new Science();

            foreach (var scienceData in rootObjects)
            {
               foreach (var experimentData in scienceData.Children)
               {
                  newScience.Experiments.Add(Experiment.Build(experimentData));
               }
            }

            return newScience;
         }
         else
         {
            return null;
         }
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
