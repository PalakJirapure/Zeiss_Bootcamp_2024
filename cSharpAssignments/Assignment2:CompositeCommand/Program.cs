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
 
            Action command1 = new Action(target.ExecuteTask);
            Action command2 = new Action(target2.DoTask);

            Action compositeCommand = command1 + command2;
            source.SetCommand(compositeCommand);
            source.TriggerCommand();
       
            source.SetCommand(command1);
            source.TriggerCommand();
 
            source.SetCommand(command2);
            source.TriggerCommand();
        }
    }
}
