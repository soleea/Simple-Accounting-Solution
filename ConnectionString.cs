using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace College_Management_System
{
    class ConnectionString
    {
        public string DBConn = @"Data Source=.;Initial Catalog=SimpleAccount;User ID=sa; Password=sola;Connect Timeout=80;MultipleActiveResultSets=true";
       //Data Source=SOLA;Initial Catalog=CMS_DB.MDF;Integrated Security=True;Connect Timeout=30
        //Data Source=SOLA\SOLA;Initial Catalog=CMS_DB.MDF;Integrated Security=True
    }
}
