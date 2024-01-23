using System;
using System.Reflection;

public deligate void Command()

/* namespace ObserverPatternExample
{
    public class Command
    {
        public void Execute(string task, params object[] targets)
        {
            Console.WriteLine(task);

            foreach (var target in targets)
            {
                Type targetType = target.GetType();
                MethodInfo method = targetType.GetMethod("ExecuteTask");
                if (method != null)
                {
                    if(method.ReturnType==typeof(void)&& method.GetParameters().Length == 0   )
                    {
                        method.Invoke(target, null);
                    }
            }
        }
    }
}*/
