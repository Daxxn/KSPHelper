using CustomDataTypeLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.Data.WorldDataModels
{
   public class PlanetModel
   {
      public static readonly Dictionary<PlanetNames, PlanetModel> PlanetData = new Dictionary<PlanetNames, PlanetModel>
      {
         { 
            PlanetNames.Kerbol, new PlanetModel
            {
               Name = PlanetNames.Kerbol,
               ParentOrbit = PlanetNames.NULL,
               Mass = new Metric(ScientificNumber.ToNumber(1.757, 28), Prefix.Kilo, Measurement.Gram),
               SurfaceGravity = new Gravity(1.746),
               Radius = new Metric(261600000),
               RotationalPeriod = new TimeSpan(20,0,0,0),
               SOI = Metric.Infinity,
               Atmospere = 0.157907727430507
            }
         },
         {
            PlanetNames.Moho, new PlanetModel
            {
               Name = PlanetNames.Moho,
               ParentOrbit = PlanetNames.Kerbol,
               SemiMajorAxis = new Metric(5263138.30, Prefix.Kilo),
               Eccentricity = 0.2,
               Inclination = 7,
               OrbitalPeriod = new TimeSpan(102,3,29,14),
               Mass = new Metric(ScientificNumber.ToNumber(2.526, 21), Prefix.Kilo, Measurement.Gram),
               SurfaceGravity = new Gravity(0.275),
               Radius = new Metric(250, Prefix.Kilo),
               RotationalPeriod = new TimeSpan(56, 0, 6, 40),
               SOI = new Metric(9646.66, Prefix.Kilo),
               Atmospere = 0
            }
         },
         {
            PlanetNames.Eve, new PlanetModel
            {
               Name = PlanetNames.Eve,
               ParentOrbit = PlanetNames.Kerbol,
               SemiMajorAxis = new Metric(9832684.54, Prefix.Kilo),
               Eccentricity = 0.01,
               Inclination = 2.09999990463257,
               OrbitalPeriod = new TimeSpan(261, 5, 39, 55 ),
               Mass = new Metric(ScientificNumber.ToNumber(1.224, 23), Prefix.Kilo, Measurement.Gram),
               SurfaceGravity = new Gravity(1.7),
               Radius = new Metric(700, Prefix.Kilo),
               RotationalPeriod = new TimeSpan(3, 4, 21, 40),
               SOI = new Metric(85109.36, Prefix.Kilo),
               Atmospere = 5
            }
         },
         {
            PlanetNames.Gilly, new PlanetModel
            {
               Name = PlanetNames.Gilly,
               ParentOrbit = PlanetNames.Eve,
               SemiMajorAxis = new Metric(31500, Prefix.Kilo),
               Eccentricity = 0.55,
               Inclination = 12,
               OrbitalPeriod = new TimeSpan(17, 5, 56, 27),
               Mass = new Metric(ScientificNumber.ToNumber(1.242, 17), Prefix.Kilo, Measurement.Gram),
               SurfaceGravity = new Gravity(0.005),
               Radius = new Metric(13, Prefix.Kilo),
               RotationalPeriod = new TimeSpan(1, 1, 50, 55),
               SOI = new Metric(126.12, Prefix.Kilo),
               Atmospere = 0
            }
         },
         {
            PlanetNames.Kerbin, new PlanetModel
            {
               Name = PlanetNames.Kerbin,
               ParentOrbit = PlanetNames.Kerbol,
               SemiMajorAxis = new Metric(13599840.26, Prefix.Kilo),
               Eccentricity = 0,
               Inclination = 0,
               OrbitalPeriod = new TimeSpan(426, 0, 32, 25),
               Mass = new Metric(ScientificNumber.ToNumber(5.292, 22), Prefix.Kilo),
               SurfaceGravity = new Gravity(1),
               Radius = new Metric(600, Prefix.Kilo),
               RotationalPeriod = new TimeSpan(5, 59, 9),
               SOI = new Metric(84159.29, Prefix.Kilo),
               Atmospere = 1
            }
         }
      };
      #region - Fields & Properties
      public PlanetNames Name { get; set; } = PlanetNames.Kerbol;
      public PlanetNames ParentOrbit { get; set; }
      public Metric SemiMajorAxis { get; set; }
      public double Eccentricity { get; set; }
      public double Inclination { get; set; }
      public TimeSpan OrbitalPeriod { get; set; }
      public Metric Mass { get; set; }
      public Gravity SurfaceGravity { get; set; }
      public Metric Radius { get; set; }
      public TimeSpan RotationalPeriod { get; set; }
      public Metric SOI { get; set; }
      public double Atmospere { get; set; }
      #endregion

      #region - Constructors
      public PlanetModel() { }
      #endregion

      #region - Methods

      #endregion

      #region - Full Properties

      #endregion
   }
}
