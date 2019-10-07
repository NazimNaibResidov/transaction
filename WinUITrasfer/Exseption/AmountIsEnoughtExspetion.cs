using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinUITrasfer.Exseption
{
   public class AmountIsEnoughtExspetion:ApplicationException
    {
        public AmountIsEnoughtExspetion(string message):base(message)
        {

        }
    }
}
