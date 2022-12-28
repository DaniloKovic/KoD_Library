using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KoD_Library_HCI_Core6.Models.Exceptions
{
    public class MyException : Exception
    {
        public MyException()
        {

        }

        public MyException(string customMessage) 
            : base(String.Format("Invalid: {0}", customMessage))
        {
            
        }
    }
}
