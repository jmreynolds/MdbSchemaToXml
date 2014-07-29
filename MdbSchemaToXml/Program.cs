using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using CODE.Framework.Core.Utilities;

namespace MdbSchemaCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var newCompare = new MdbCompare(@"C:\Temp\20140728\new.mdb", @"C:\Temp\20140728\new.xml");
            var oldCompare = new MdbCompare(@"C:\Temp\20140728\old.mdb", @"C:\Temp\20140728\old.xml");
        }
    }
}
