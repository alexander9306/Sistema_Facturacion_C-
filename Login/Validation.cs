using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Login
{
    public class Validation
    {
        public static int ValidateInt(string Entry)
        {
            int value;
            int.TryParse(Entry, out value);
            return value;
        }
    }
}
