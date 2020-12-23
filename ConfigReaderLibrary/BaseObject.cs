using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigReaderLibrary
{
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

      ///// <summary>
      ///// Basic ONLY. Need to implement recursive tree search.
      ///// </summary>
      //public BaseObject GetChild(string key)
      //{
      //   if (String.IsNullOrEmpty(key))
      //   {
      //      var found = Children.Find((obj) => obj.Key == key);
      //      if (found != null)
      //      {
      //         return found;
      //      }
      //      else
      //      {
      //         return null;
      //      }
      //   }
      //   return null;
      //}

      public BaseObject GetChild(string key)
      {
         if (!String.IsNullOrEmpty(key))
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

      public List<BaseObject> GetChildren(string name)
      {
         if (String.IsNullOrWhiteSpace(name))
         {
            throw new Exception("Cannot be null or empty.");
         }

         List<BaseObject> foundChildren = new List<BaseObject>();

         foreach (var child in Children)
         {
            if (child.Key == name)
            {
               foundChildren.Add(child);
            }
         }

         return foundChildren;
      }

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

      public BaseObject FindChildByProperty(string property, string value)
      {
         if (String.IsNullOrWhiteSpace(property))
         {
            return null;
         }
         //if (Values.ContainsKey(property))
         //{
         //   if (Values[property] == value)
         //   {
         //      return this;
         //   }
         //}
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
