using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAssignment
{
    public static class TaskManager
    {
        public static void ExecutePrintTask(IPrintable printer, string documentPath)
        {
            printer.Print(documentPath);
        }

        public static void ExecuteScanTask(IScannable scanner, string documentPath)
        {
            scanner.Scan(documentPath);
        }
    }

}
