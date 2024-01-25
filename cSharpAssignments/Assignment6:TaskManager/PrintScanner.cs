using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAssignment
{
    public class PrintScanner : IPrintable, IScannable
    {
        private readonly IPrintable _printer;
        private readonly IScannable _scanner;

        public PrintScanner(IPrintable printer, IScannable scanner)
        {
            _printer = printer;
            _scanner = scanner;
        }

        public void Print(string path)
        {
            _printer.Print(path);
        }

        public void Scan(string path)
        {
            _scanner.Scan(path);
        }
    }

}
