using System;
using System.Collections.Generic;
using System.Text;

namespace KSPModelLibrary.CalculatorModels.ElectricalCalcModels
{
   public class StageTotal : BaseModel
   {
      #region - Fields & Properties
      private int _stage;
      private double _batteries;
      private double _loads;
      private double _generators;
      private double _alternators;
      #endregion

      #region - Constructors
      public StageTotal() { }
      public StageTotal(int stageNumber)
      {
         Stage = stageNumber;
      }
      #endregion

      #region - Methods
      public override string ToString()
      {
         return $"Stage {Stage} : Batt {Batteries} : Loads {Loads} : Gens {Generators}";
      }
      #endregion

      #region - Full Properties
      public int Stage
      {
         get { return _stage; }
         set
         {
            _stage = value;
            OnPropertyChanged(nameof(Stage));
         }
      }

      public double Batteries
      {
         get { return _batteries; }
         set
         {
            _batteries = value;
            OnPropertyChanged(nameof(Batteries));
         }
      }

      public double Loads
      {
         get { return _loads; }
         set
         {
            _loads = value;
            OnPropertyChanged(nameof(Loads));
         }
      }

      public double Generators
      {
         get { return _generators; }
         set
         {
            _generators = value;
            OnPropertyChanged(nameof(Generators));
         }
      }

      public double Alternators
      {
         get { return _alternators; }
         set
         {
            _alternators = value;
            OnPropertyChanged(nameof(Alternators));
         }
      }
      #endregion
   }
}
