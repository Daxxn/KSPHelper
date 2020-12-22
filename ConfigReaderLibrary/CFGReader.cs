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
      public static List<BaseObject> ReadFiles(string[] files, string filter)
      {
         try
         {
            var output = new List<BaseObject>();

            foreach (var file in files)
            {
               var newReader = new CFGReader(file);
               newReader.ReadFile();
               output.Add(newReader.ParseFile(filter));
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
                  output.Add(reader.ReadLine());
               }
            }
            Data = output;
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
                  if (Data[i].Contains('{'))
                  {
                     if (i > 0)
                     {
                        var cleanedKey = CleanTabsRec(Data[i - 1]);
                        var newChild = new BaseObject();
                        newChild.Key = cleanedKey;
                        tempObject.Children.Add(newChild);
                        newChild.Parent = tempObject;
                        tempObject = newChild;
                     }
                  }
                  if (Data[i].Contains('='))
                  {
                     var cleanedLine = CleanTabsRec(Data[i]);
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
                  if (Data[i].Contains('}'))
                  {
                     if (i < Data.Count)
                     {
                        tempObject = tempObject.Parent;
                     }
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
         var split = line.Split(new string[] { " = ", "=" }, StringSplitOptions.None);
         if (split.Length == 0)
         {
            return ("PARSE FAILURE", "NULL");
         }
         if (split.Length == 1)
         {
            return (split[0], "NULL");
         }
         if (split.Length > 2)
         {
            return (split[0], split[2]);
         }
         return (split[0], split[1]);
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
