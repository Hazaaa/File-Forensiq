using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileForensiq.Core.Logger
{
    public class ErrorLogger
    {
        public static void LogError(string message)
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");

            using (StreamWriter sw = File.AppendText(destPath))
            {
                sw.WriteLine(DateTime.Now.ToString() + "/" + message);
            }
        }

        public static List<string> GetAllErrors()
        {
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ErrorLog.txt");
            try
            {
                return File.ReadAllLines(destPath).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }
    }
}
