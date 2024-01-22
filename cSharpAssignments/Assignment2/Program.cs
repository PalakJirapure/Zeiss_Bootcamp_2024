using System;

namespace ObserverPatternExample
{
    class Program
    {
        static void Main()
        {

            Target target = new Target();
            Target2 target2 = new Target2();

            
            Command command = new Command();
            Source source = new Source();

           
            source.ExecuteCommand += (task) =>
            {
                
                Console.WriteLine("Command received: " + task);
            };

           
            source.TriggerCommand(command, "Task Executed", target, target2);
        }
    }
}
