using KSPModelLibrary.CraftParser;
using KSPModelLibrary.Data.PartDataModels.ModuleTypes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace KSPHelperWPF.ViewModels
{
   public class PartsViewModel : ViewModel
   {
      #region - Fields & Properties
      private CraftModel _craft = CraftDataReader.Craft;
      private PartRef _selectedPart;

      private ObservableCollection<string> _categories;
      private string _selectedCategory;
      private ObservableCollection<PartRef> _partsCategory;
      private PartRef _selectedCategoryPart;
      #endregion

      #region - Constructors
      public PartsViewModel()
      {
         MainViewModel.OpenNewCraftEvent += OpenNewCraftEvent;
      }

      private void OpenNewCraftEvent(object sender, Events.OpenCraftEventArgs e)
      {
         Craft = e.Craft;
         GetCraftCategories(e.Craft);
      }
      #endregion

      #region - Methods
      private void GetCraftCategories(CraftModel newCraft)
      {
         if (newCraft is null)
         {
            return;
         }

         Categories = new ObservableCollection<string>();

         foreach (var stage in newCraft.Stages.Values)
         {
            foreach (var part in stage.Parts)
            {
               if (!Categories.Contains(part.Part.Category))
               {
                  Categories.Add(part.Part.Category);
               }
            }
         }
      }

      private void GetPartsByCategory()
      {
         if (_selectedCategory is null)
         {
            return;
         }

         PartsCategory = new ObservableCollection<PartRef>();

         foreach (var stage in Craft.Stages.Values)
         {
            foreach (var part in stage.Parts)
            {
               if (part.Part.Category == SelectedCategory)
               {
                  PartsCategory.Add(part);
               }
            }
         }
      }
      #endregion

      #region - Full Properties
      public CraftModel Craft
      {
         get { return _craft; }
         set
         {
            _craft = value;
            //GetCraftCategories(value);
            OnPropertyChanged(nameof(Craft));
         }
      }

      public PartRef SelectedPart
      {
         get { return _selectedPart; }
         set
         {
            _selectedPart = value;
            OnPropertyChanged(nameof(SelectedPart));
         }
      }

      public ObservableCollection<string> Categories
      {
         get { return _categories; }
         set
         {
            _categories = value;
            OnPropertyChanged(nameof(Categories));
         }
      }

      public string SelectedCategory
      {
         get { return _selectedCategory; }
         set
         {
            _selectedCategory = value;
            GetPartsByCategory();
            OnPropertyChanged(nameof(SelectedCategory));
         }
      }

      public ObservableCollection<PartRef> PartsCategory
      {
         get { return _partsCategory; }
         set
         {
            _partsCategory = value;
            OnPropertyChanged(nameof(PartsCategory));
         }
      }

      public PartRef SelectedCategoryPart
      {
         get { return _selectedCategoryPart; }
         set
         {
            _selectedCategoryPart = value;
            OnPropertyChanged(nameof(SelectedCategoryPart));
         }
      }
      #endregion
   }
}
