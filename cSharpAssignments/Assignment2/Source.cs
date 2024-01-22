using System;

namespace ObserverPatternExample
{
    public delegate void ExecuteCommandDelegate(string task);

    public class Source
    {
        // Event for the command execution
        public event ExecuteCommandDelegate ExecuteCommand;

        public void TriggerCommand(Command command, string task, params object[] targets)
        {
            // Invoke the event, triggering the command execution
            ExecuteCommand?.Invoke(task);

            // Use reflection to execute the tasks in the specified targets
            command.Execute(task, targets);
        }
    }
}
