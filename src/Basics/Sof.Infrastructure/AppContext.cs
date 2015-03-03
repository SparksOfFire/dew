using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sof
{
    public class AppContext
    {
        public static AppContext Current { get; set; }

        public log4net.ILog Logger { get; set; }

        public Operator Operator { get; set; }
    }

    public class Operator
    {

    }
}
