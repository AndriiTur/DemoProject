using System.IO;

namespace DemoProject
{
    public class FileHelper
    {
        public static string FileToString(string path)
        {
            if (File.Exists(path))
                return File.ReadAllText(path);
            else
                return "";
        }

        public static void StringToFile(string path, string str)
        {
            File.WriteAllText(path, str);
        }
    }
}
