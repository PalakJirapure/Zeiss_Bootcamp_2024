using System;

namespace ObserverPatternExample
{
    public delegate void ExecuteCommandDelegate(string task);

    public class Source
    {
        
        public event ExecuteCommandDelegate ExecuteCommand;

        public void TriggerCommand(Command command, string task, params object[] targets)
        {
            
            ExecuteCommand?.Invoke(task);

            
            command.Execute(task, targets);
        }
    }
}
