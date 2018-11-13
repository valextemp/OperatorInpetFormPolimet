using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorInpetFormPolimet
{
    public class Param
    {
        public string NameShort { get; set; }
        public string NameRus { get; set; }
        public string NameEng { get; set; }
        public decimal? Optimal { get; set; }
        public decimal? Managed { get; set; }
        public string Comment { get; set; }

        public bool Accept { get; set; }

        public string GetStringToCSV(bool acccept, string optimal, string managed, string comment)
        {
            if (acccept)
            {
                return optimal + ";" + managed + ";" + "Null";
            }
            else
            {
                return "Null;Null;" + comment.Replace("\r\n", " ").Trim();
            }
        }

    }
}
