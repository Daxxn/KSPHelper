using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReaderLibrary
{
   /// <summary>
   /// Parses a .cfg or config file.
   /// </summary>
   public class CFGReader
   {
      #region - Fields & Properties
      /// <summary>
      /// The path to the config file.
      /// </summary>
      public string FilePath { get; set; }
      /// <summary>
      /// The ROOT node of the config file.
      /// </summary>
      public BaseObject ParsedObject { get; set; }
      /// <summary>
      /// The lines from the config file.
      /// </summary>
      private List<string> Data { get; set; }
      #endregion

      #region Constructors
      public CFGReader(string path)
      {
         FilePath = path;
      }
      #endregion

      #region - Methods
      /// <summary>
      /// Reads an array of config files.
      /// </summary>
      /// <param name="files">The complete paths to the config files.</param>
      /// <returns>A list of ROOT nodes for the config files.</returns>
      public static List<BaseObject> ReadFiles(string[] files)
      {
         try
         {
            var output = new List<BaseObject>();

            foreach (var file in files)
            {
               var newReader = new CFGReader(file);
               newReader.ReadFile();
               output.Add(newReader.ParseLines());
            }
            return output;
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Reads the config file.
      /// </summary>
      public void ReadFile()
      {
         try
         {
            var output = new List<string>();
            using (StreamReader reader = new StreamReader(FilePath))
            {
               while (!reader.EndOfStream)
               {
                  var line = Clean(reader.ReadLine());
                  if (!String.IsNullOrWhiteSpace(line))
                  {
                     output.Add(line);
                  }
               }
            }
            Data = output;
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Reads and parses the file.
      /// </summary>
      /// <returns>The root node of the file.</returns>
      public BaseObject ParseFile()
      {
         try
         {
            ReadFile();
            return ParseLines();
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Parses the config file.
      /// </summary>
      /// <returns>The ROOT node of the config file.</returns>
      public BaseObject ParseLines()
      {
         try
         {
            BaseObject tempObject = new BaseObject();
            for (int i = 0; i < Data.Count; i++)
            {
               if (String.IsNullOrWhiteSpace(Data[i]) || Data[i] == "\t")
               {
                  continue;
               }
               // Starts a new node on the current node.
               else if (Data[i].Contains('{'))
               {
                  if (i > 0)
                  {
                     string temp = Data[i];
                     string key;
                     if (temp.EndsWith("{") && temp.Length > 2)
                     {
                        key = temp.TrimEnd('{');
                     }
                     else
                     {
                        key = Data[i - 1];
                     }
                     var newChild = new BaseObject { Key = key };
                     tempObject.Children.Add(newChild);
                     newChild.Parent = tempObject;
                     tempObject = newChild;
                  }
               }
               // Parses the property.
               else if (Data[i].Contains('='))
               {
                  var cleanedLine = Data[i];
                  if (cleanedLine.StartsWith("//"))
                  {
                     continue;
                  }
                  var (key, val) = ParseLine(cleanedLine);
                  var success = tempObject.Values.TryAdd(key, val);
                  if (!success)
                  {
                     Console.WriteLine($"Key already Exists {key}");
                  }
               }
               // moves up to the parent node.
               else if (Data[i].Contains('}'))
               {
                  tempObject = tempObject.Parent;
               }
            }
            ParsedObject = tempObject.GetRoot();
            return ParsedObject;
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Parses the config file, if the first node matches the <paramref name="filter"/>
      /// </summary>
      /// <param name="filter">The filter for the first node.</param>
      /// <returns>The ROOT node of the config file.</returns>
      public BaseObject ParseFile(string filter)
      {
         try
         {
            if (Data[0] == filter)
            {
               BaseObject tempObject = new BaseObject();
               for (int i = 0; i < Data.Count; i++)
               {
                  if (String.IsNullOrWhiteSpace(Data[i]) || Data[i] == "\t")
                  {
                     continue;
                  }
                  // Starts a new node on the current node.
                  else if (Data[i].Contains('{'))
                  {
                     if (i > 0)
                     {
                        string temp = Data[i];
                        string key;
                        if (temp.EndsWith("{") && temp.Length > 1)
                        {
                           key = temp.TrimEnd('{');
                        }
                        else
                        {
                           key = Data[i - 1];
                        }
                        var newChild = new BaseObject{ Key = key };
                        tempObject.Children.Add(newChild);
                        newChild.Parent = tempObject;
                        tempObject = newChild;
                     }
                  }
                  // Parses the property.
                  else if (Data[i].Contains('='))
                  {
                     var cleanedLine = Data[i];
                     if (cleanedLine.StartsWith("//"))
                     {
                        continue;
                     }
                     var (key, val) = ParseLine(cleanedLine);
                     var success = tempObject.Values.TryAdd(key, val);
                     if (!success)
                     {
                        Console.WriteLine($"Key already Exists {key}");
                     }
                  }
                  // moves up to the parent node.
                  else if (Data[i].Contains('}'))
                  {
                     tempObject = tempObject.Parent;
                  }
               }
               ParsedObject = tempObject.GetRoot();
               return ParsedObject;
            }
            else
            {
               return null;
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      /// <summary>
      /// Parses the property from the given line.
      /// </summary>
      /// <param name="line">The line to parse.</param>
      /// <returns>A <see cref="Tuple{T1, T2}"/> of <see cref="string"/>s for the property and value of the line.</returns>
      public (string, string) ParseLine(string line)
      {
         //var cleanedLine = CleanTabsRec(line);
         var dirtySplit = line.Split(new string[] { " = ", "=" }, StringSplitOptions.RemoveEmptyEntries);
         //var split = Clean(dirtySplit, false);
         var split = Trim(dirtySplit);
         if (split.Length == 2)
         {
            return (CleanSpaces(split[0]), split[1]);
         }
         else if (split.Length == 1)
         {
            return (CleanSpaces(split[0]), "NULL");
         }
         else if (split.Length > 2)
         {
            return (CleanSpaces(split[0]), split[2]);
         }
         else
         {
            return ("PARSE FAILURE", "NULL");
         }
      }

      /// <summary>
      /// Recursively removes tabs from the line.
      /// </summary>
      /// <param name="input">The line to clean.</param>
      /// <returns>The cleaned <paramref name="input"/> line.</returns>
      private string CleanTabsRec(string input)
      {
         if (input[0] == '\t')
         {
            input = input.Remove(0, 1);

            if (input[0] == '\t')
            {
               input = CleanTabsRec(input);
            }
         }
         return input;
      }

      /// <summary>
      /// Removes tabs and spaces from the given <paramref name="input"/> line.
      /// </summary>
      /// <param name="input">The line to clean.</param>
      /// <param name="strict">If true, will clean the line anyway, otherwise will check the line first.</param>
      /// <returns>The cleaned <paramref name="input"/> line.</returns>
      private string Clean(string input, bool strict = true)
      {
         var newInput = RemoveComment(input);
         if (strict)
         {
            //StringBuilder sb = new StringBuilder();
            //foreach (char c in input)
            //{
            //   if (c != '\t' && c != ' ')
            //   {
            //      sb.Append(c);
            //   }
            //}
            //return sb.ToString();
            //return CleanTabs(input);
            return CleanSpaces(newInput.Trim('\t'));
         }
         else
         {
            //if (input.Contains('\t') || input.Contains(' '))
            if (input.Contains('\t'))
            {
               return Clean(newInput);
            }
            else
            {
               return newInput;
            }
         }
      }

      //private string CleanTabs(string input)
      //{
      //   if (input.StartsWith('\t') || input.StartsWith(' '))
      //   {
      //      var clean = input.TrimStart('\t', ' ');
      //      if (clean.StartsWith('\t') || clean.StartsWith(' '))
      //      {
      //         return CleanTabs(clean);
      //      }
      //      else
      //      {
      //         return clean;
      //      }
      //   }
      //   else
      //   {
      //      return input;
      //   }
      //}

      private string CleanSpaces(string input)
      {
         //StringBuilder sb = new StringBuilder();
         //foreach (char c in input)
         //{
         //   if (c != ' ')
         //   {
         //      sb.Append(c);
         //   }
         //}
         //return sb.ToString();
         return input.TrimStart(' ', '\t');
      }

      private string[] Trim(string[] inputs)
      {
         var output = new string[inputs.Length];
         for (int i = 0; i < inputs.Length; i++)
         {
            output[i] = inputs[i].Trim();
         }
         return output;
      }

      private string RemoveComment(string input)
      {
         if (!input.Contains("//#"))
         {
            if (input.Contains("//"))
            {
               return input.Split('/', StringSplitOptions.RemoveEmptyEntries)[0];
            }
            else
            {
               return input;
            }
         }
         else
         {
            return input;
         }
      }

      /// <summary>
      /// Cleans the tabs and spaces from an <see cref="Array"/> of lines.
      /// </summary>
      /// <param name="inputs">The input lines.</param>
      /// <param name="strict">If true, will clean the lines anyway, otherwise will check the lines first.</param>
      /// <returns>The cleaned <paramref name="inputs"/>.</returns>
      private string[] Clean(string[] inputs, bool strict = true)
      {
         List<string> output = new List<string>();
         foreach (var input in inputs)
         {
            output.Add(Clean(input, strict));
         }
         return output.ToArray();
      }
      #endregion

      #region - Full Properties

      #endregion
   }
}
