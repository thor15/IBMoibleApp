using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace IBCompSciApp.Models
{
    //if can't find file replace the text in combine with Application.persistentDataPath

    public static class FileManager
    {
        public static bool WriteToFile(string a_FileName, string a_FileContents)
        {
            var fullPath = Path.Combine("C:\\Aiden Carr\\IBMoibleApp\\IBCompSciApp\\IBCompSciApp\\IBCompSciApp", a_FileName);

            try
            {
                File.WriteAllText(fullPath, a_FileContents);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to write to {fullPath} with exception {e}");
                Debug.WriteLine("");
                Debug.WriteLine("");
                return false;
            }
        }

        public static bool LoadFromFile(string a_FileName, out string result)
        {
            var fullPath = a_FileName;// Path.Combine("\\aiden\\Unity\\2D-platformer\\2D-platformer", a_FileName);

            try
            {
                result = File.ReadAllText(fullPath);
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to read from {fullPath} with exception {e}");
                result = "";
                return false;
            }
        }
    }
}
