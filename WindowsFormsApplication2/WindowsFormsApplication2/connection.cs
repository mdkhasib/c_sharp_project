
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace WindowsFormsApplication2
{
    class connection
    {
        public OracleConnection thisConnection = new OracleConnection("Data Source=XE;User ID=system;Password=system;");
    }
}



