using System;

namespace ObserverPatternExample
{
    class Program
{
    static void Main()
    {
        Target target = new Target();
        Target2 target2 = new Target2();
        
 
        Source source = new Source();
 
        Command command1 = new Command(target, "ExecuteTask");
        Command command2 = new Command(target2, "DoTask");
       
 
        source.SetCommand(command1);
 
        source.TriggerCommand();
 
        source.SetCommand(command2);
        source.TriggerCommand();
 
        source.SetCommand(command3);
        source.TriggerCommand();
    }
}
}
