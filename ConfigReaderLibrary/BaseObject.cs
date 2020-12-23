using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReaderLibrary
{
   /// <summary>
   /// The object containing the data from a config file.
   /// </summary>
   public class BaseObject
   {
      #region - Fields & Properties
      public string Key { get; set; }
      public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
      public BaseObject Parent { get; set; }
      public List<BaseObject> Children { get; set; } = new List<BaseObject>();
      #endregion

      #region - Constructors
      public BaseObject() { }
      #endregion

      #region - Methods
      public BaseObject GetParent()
      {
         return Parent;
      }

      /// <summary>
      /// Gets a child Recursively, searching down the tree.
      /// </summary>
      /// <param name="key">The key of the child objects to search for.</param>
      /// <returns>The found object or null.</returns>
      public BaseObject GetChild(string key)
      {
         if (!String.IsNullOrWhiteSpace(key))
         {
            if (Key == key)
            {
               return this;
            }
            else
            {
               BaseObject foundChild = null;
               foreach (var child in Children)
               {
                  if (child.Key == key)
                  {
                     foundChild = child;
                     break;
                  }
                  else
                  {
                     foundChild = child.GetChild(key);
                     if (foundChild != null)
                     {
                        break;
                     }
                  }
               }
               return foundChild;
            }
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Searches just the next branch of children only.
      /// </summary>
      /// <param name="key">The key of the child objects to search for.</param>
      /// <returns>The found object or null.</returns>
      public BaseObject ShallowGetChild(string key)
      {
         if (String.IsNullOrWhiteSpace(key))
         {
            if (Key == key)
            {
               return this;
            }

            foreach (var child in Children)
            {
               if (child.Key == key)
               {
                  return child;
               }
            }
            return null;
         }
         else
         {
            return null;
         }
      }

      /// <summary>
      /// Gets all the children that match the <paramref name="key"/>.
      /// </summary>
      /// <param name="key"></param>
      /// <returns>A <see cref="List{}"/> of <see cref="BaseObject"/> or an empty <see cref="List{}"/>.</returns>
      public List<BaseObject> GetChildren(string key)
      {
         if (String.IsNullOrWhiteSpace(key))
         {
            throw new Exception("Cannot be null or empty.");
         }

         List<BaseObject> foundChildren = new List<BaseObject>();

         foreach (var child in Children)
         {
            if (child.Key == key)
            {
               foundChildren.Add(child);
            }
         }

         return foundChildren;
      }

      /// <summary>
      /// Finds all children that contain the <paramref name="property"/> and match <paramref name="value"/>.
      /// <para/>
      /// Note: The search is only in the current objects children.
      /// </summary>
      /// <param name="property">The property to search.</param>
      /// <param name="value">The value to search.</param>
      /// <returns>A <see cref="List{T}"/> that match the provided parameters.</returns>
      public List<BaseObject> GetChildrenByProperty(string property, string value)
      {
         List<BaseObject> foundChildren = new List<BaseObject>();

         foreach (var child in Children)
         {
            if (child.Values.ContainsKey(property))
            {
               if (child.Values[property] == value)
               {
                  foundChildren.Add(child);
               }
            }
         }

         return foundChildren;
      }

      /// <summary>
      /// Finds a child that has the <paramref name="property"/> and matches the <paramref name="value"/>
      /// </summary>
      /// <param name="property">The property to search.</param>
      /// <param name="value">The value to search.</param>
      /// <returns>A child that matches the given parameters or null.</returns>
      public BaseObject FindChildByProperty(string property, string value)
      {
         if (String.IsNullOrWhiteSpace(property))
         {
            return null;
         }
         BaseObject foundChild = null;
         foreach (var child in Children)
         {
            if (child.Values.ContainsKey(property))
            {
               if (child.Values[property] == value)
               {
                  foundChild = child;
               }
               else
               {
                  foundChild = child.FindChildByProperty(property, value);
               }
            }
            if (foundChild != null)
            {
               break;
            }
         }
         return foundChild;
      }

      /// <summary>
      /// Finds the Top of the tree.
      /// </summary>
      /// <returns>The root node of the tree.</returns>
      public BaseObject GetRoot()
      {
         if (IsRoot)
         {
            return this;
         }
         else
         {
            return Parent.GetRoot();
         }
      }
      #endregion

      #region - Full Properties
      public bool IsRoot
      {
         get
         {
            return Parent is null;
         }
      }
      #endregion
   }
}
