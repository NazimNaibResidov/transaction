using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUITrasfer.Models
{
  public  class Log
    {
        public int Id { get; set; }
        public string FormAccount { get; set; }
        public string ToAccount { get; set; }
        public decimal TrasferAmmount { get; set; }
        public DateTime TrasferData { get; set; }
        public bool IsTrasferSuccessFul { get; set; }
        public string FailedReason { get; set; }
    }
}
