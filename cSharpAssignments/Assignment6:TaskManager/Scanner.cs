using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAssignment
{
    public class Scanner : IScannable
    {
        public void Scan(string path)
        {
            System.Console.WriteLine($"Scanning .....{path}");
        }
    }

}
