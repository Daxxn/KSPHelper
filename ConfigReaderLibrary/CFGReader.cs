using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigReaderLibrary
{
   public class CFGReader
   {
      #region - Fields & Properties
      public string FilePath { get; set; }
      public BaseObject ParsedObject { get; set; }
      private List<string> Data { get; set; }
      #endregion

      #region Constructors
      public CFGReader(string path)
      {
         FilePath = path;
      }
      #endregion

      #region - Methods
      public static List<BaseObject> ReadFiles(string[] files)
      {
         try
         {
            var output = new List<BaseObject>();

            foreach (var file in files)
            {
               var newReader = new CFGReader(file);
               newReader.ReadFile();
               output.Add(newReader.ParseFile());
            }
            return output;
         }
         catch (Exception)
         {
            throw;
         }
      }

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

      public BaseObject ParseFile()
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

      public (string, string) ParseLine(string line)
      {
         //var cleanedLine = CleanTabsRec(line);
         var dirtySplit = line.Split(new string[] { " = ", "=" }, StringSplitOptions.RemoveEmptyEntries);
         var split = Clean(dirtySplit, false);
         if (split.Length == 2)
         {
            return (split[0], split[1]);
         }
         else if (split.Length == 1)
         {
            return (split[0], "NULL");
         }
         else if (split.Length > 2)
         {
            return (split[0], split[2]);
         }
         else
         {
            return ("PARSE FAILURE", "NULL");
         }
      }

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

      private string Clean(string input, bool strict = true)
      {
         if (strict)
         {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
               if (c != '\t' && c != ' ')
               {
                  sb.Append(c);
               }
            }
            return sb.ToString();
         }
         else
         {
            if (input.Contains('\t') || input.Contains(' '))
            {
               return Clean(input);
            }
            else
            {
               return input;
            }
         }
      }
      private string[] Clean(string[] inputs, bool strict = true)
      {
         List<string> output = new List<string>();
         foreach (var input in inputs)
         {
            output.Add(Clean(input, strict));
         }
         return output.ToArray();
      }

      private string CleanTabsAndSpaces(string input)
      {
         var cleanedTabs = CleanTabsRec(input);
         return cleanedTabs.Replace(" ", "");
      }

      private string[] CleanSpaces(string[] inputs)
      {
         List<string> output = new List<string>();
         foreach (var input in inputs)
         {
            output.Add(input.Trim());
         }
         return output.ToArray();
      }

      #region OLD Async Version
      //public async Task<BaseObject> ParseFileAsync()
      //{
      //   try
      //   {
      //      return await Task.Run(() =>
      //      {
      //         ReadFile();
      //         return ParseFile();
      //      });
      //   }
      //   catch (Exception)
      //   {
      //      throw;
      //   }
      //}

      //public static async Task<List<BaseObject>> ReadFilesAsync(string[] files)
      //{
      //   try
      //   {
      //      //List<Task<BaseObject>> tasks = new List<Task<BaseObject>>();

      //      //foreach (var file in files)
      //      //{
      //      //   var newReader = new CFGReader(file);
      //      //   //newReader.ReadFile();
      //      //   tasks.Add(newReader.ParseFileAsync());
      //      //}

      //      var output = await Task.Run(() =>
      //      {
      //         return ReadFiles(files);
      //      });

      //      return output;
      //   }
      //   catch (Exception)
      //   {
      //      throw;
      //   }
      //}

      //public async Task ReadFileAsync(string path)
      //{
      //   try
      //   {
      //      var output = new List<string>();
      //      await Task.Run(() =>
      //      {
      //         ReadFile();
      //      });
      //   }
      //   catch (Exception)
      //   {
      //      throw;
      //   }
      //}
      #endregion
      #endregion

      #region - Full Properties

      #endregion
   }
}
