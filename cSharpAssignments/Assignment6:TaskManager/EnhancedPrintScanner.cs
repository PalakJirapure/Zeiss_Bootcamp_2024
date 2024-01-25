using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAssignment
{
    public class EnhancedPrintScanner : IPrintable, IScannable
    {
        private readonly IPrintable _printer;
        private readonly IScannable _scanner;

        public EnhancedPrintScanner(IPrintable printer, IScannable scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }

        public void Print(string path)
        {
            _printer.Print(path);
            System.Console.WriteLine($"Enhanced Printing .....{path}");
        }

        public void Scan(string path)
        {
            _scanner.Scan(path);
            System.Console.WriteLine($"Enhanced Scanning .....{path}");
        }
    }

}
