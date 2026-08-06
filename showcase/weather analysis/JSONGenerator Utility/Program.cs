using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JSONGenerator.GenerateExcel("New York");
            JSONGenerator.GenerateExcel("Los Angeles");
            JSONGenerator.GenerateExcel("Seattle");
            JSONGenerator.GenerateExcel("San Francisco");
            JSONGenerator.GenerateExcel("Washington, D.C");
        }
    }
}
