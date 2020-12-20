using KSPModelLibrary.Models;
using KSPModelLibrary.Models.ElectricalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.TestData
{
   public class ElectricalTestData
   {
      #region - Fields & Properties
      public Craft TestCraft { get; set; }
      #endregion

      #region - Constructors
      public ElectricalTestData(int testSelector = 0)
      {
         TestCraft = new Craft
         {
            AllParts = new List<IPart>
            {
               new CommandModule
               {
                  Capacity = 50,
                  DrainRate = 0.2,
                  TimeDiv = TimeDivision.PerMinute,
                  Mass = 10000,
               },
               new Battery
               {
                  Mass = 0.2,
                  Capacity = 200,
               },
               new SolarPanel
               {
                  Mass = 1000,
                  GenRate = 0.8,
                  TimeDiv = TimeDivision.PerSecond,
               },
               new ReactionWheel
               {
                  Mass = 1200,
                  DrainRate = 1,
                  TimeDiv = TimeDivision.PerSecond,
                  Torque = 1000
               }
            }
         };
      }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
