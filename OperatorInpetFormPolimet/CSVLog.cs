using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace OperatorInpetFormPolimet
{
 
    public  class CSVLog
    {
        readonly  string nameFileCSV = "modellog.csv";
        readonly string FullPathToCSVFile;

        public  CSVLog(string pathToDirectory)
        {
            FullPathToCSVFile = pathToDirectory + Path.DirectorySeparatorChar + nameFileCSV;
        }

        public  void WriteToCSV (string strValue)
        {
            //var file = new FileStream(FullPathToCSVFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //var writer = new StreamWriter(file, Encoding.GetEncoding(1251));

            var file = new FileStream(FullPathToCSVFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            var writer = new StreamWriter(file, Encoding.GetEncoding(1251));

            writer.WriteLine(strValue);

            writer.Close();

        }

        public  void WriteToCSV (DataEntity dataEntity)
        {

        }

    }
}
