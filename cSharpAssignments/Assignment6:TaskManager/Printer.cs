using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAssignment
{
    public class Printer : IPrintable
    {
        public void Print(string path)
        {
            System.Console.WriteLine($"Printing .....{path}");
        }
    }

}
