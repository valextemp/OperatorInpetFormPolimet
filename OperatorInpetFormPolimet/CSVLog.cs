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
        //new comment 20230519
        readonly  string nameFileCSV = "modellog.csv";
        readonly string FullPathToCSVFile;
        readonly string firstString = "Timestamp;Param_1_Optimal;Param_1_Managed;Parama_1_Comment;Param_2_Optimal;Param_2_Managed;Parama_2_Comment;Param_3_Optimal;Param_3_Managed;Parama_3_Comment;Param_4_Optimal;Param_4_Managed;Parama_4_Comment;Param_5_Optimal;Param_5_Managed;Parama_5_Comment";

        public string FirstString { get => firstString; }

        public  CSVLog(string fullPathToFile)
        {
            //FullPathToCSVFile = pathToDirectory + Path.DirectorySeparatorChar + nameFileCSV;
            FullPathToCSVFile = fullPathToFile;
        }

        public  void WriteToCSV (string strValue)
        {
            bool fileExist = false;
            //var file = new FileStream(FullPathToCSVFile, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //var writer = new StreamWriter(file, Encoding.GetEncoding(1251));
            fileExist = File.Exists(FullPathToCSVFile);
            var file = new FileStream(FullPathToCSVFile, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            var writer = new StreamWriter(file, Encoding.GetEncoding(1251));

            if (!fileExist)
            {
                writer.WriteLine(FirstString);
            }
            writer.WriteLine(strValue);

            writer.Close();

        }

        public  void WriteToCSV (DataEntity dataEntity)
        {

        }

    }
}
