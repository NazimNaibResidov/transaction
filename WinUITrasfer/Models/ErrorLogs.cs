using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUITrasfer.Models
{
   public class ErrorLogs
    {
        public int Id { get; set; }
        public string ErrorMesage { get; set; }
        public string AccountNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}
