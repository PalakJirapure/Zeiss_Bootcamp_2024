using System;
using System.Reflection;

namespace ObserverPatternExample
{
    public class Command
    {
        public void Execute(string task, params object[] targets)
        {
            Console.WriteLine(task);

            // Invoke ExecuteTask method of each target using reflection
            foreach (var target in targets)
            {
                Type targetType = target.GetType();
                MethodInfo method = targetType.GetMethod("ExecuteTask");
                if (method != null)
                {
                    method.Invoke(target, null);
                }
            }
        }
    }
}
