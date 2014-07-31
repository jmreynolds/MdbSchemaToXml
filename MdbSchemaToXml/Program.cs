using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading;
using CODE.Framework.Core.Utilities;
using MdbSchemaToXml;

namespace MdbSchemaCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var mdbToXml = new MdbToXml();
            mdbToXml.GenerateXmlOutput(pathToData: @"C:\Temp\20140728\new.mdb", pathToOutput: @"C:\Temp\20140728\new.xml");
            mdbToXml.GenerateXmlOutput(pathToData: @"C:\Temp\20140728\old.mdb", pathToOutput: @"C:\Temp\20140728\old.xml");
        }
    }
}
