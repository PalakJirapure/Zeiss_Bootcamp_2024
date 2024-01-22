using System;

namespace ObserverPatternExample
{
    class Program
    {
        static void Main()
        {
            // Create instances of the targets
            Target target = new Target();
            Target2 target2 = new Target2();

            // Create instances of the command and source
            Command command = new Command();
            Source source = new Source();

            // Subscribe Command execution to the Source
            source.ExecuteCommand += (task) =>
            {
                // This handler is optional and can be used to perform additional actions
                Console.WriteLine("Command received: " + task);
            };

            // Trigger the command, which will execute the tasks in both targets using reflection
            source.TriggerCommand(command, "Task Executed", target, target2);
        }
    }
}
