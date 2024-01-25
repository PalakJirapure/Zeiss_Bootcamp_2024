using System;

namespace DoorAssignment
{
    
    class Program
    {
        static void Main()
        {
           
            IDoor simpleDoor = new SimpleDoor();
            simpleDoor.Open();
            simpleDoor.Close();

            Console.WriteLine("\n---------------------\n");

            
            SmartDoor smartDoor = new SmartDoor(new SimpleDoor());
            smartDoor.Open();
            smartDoor.SetTimer(10);
            smartDoor.AutoClose(10); 
            smartDoor.Close();

            Console.WriteLine("\n---------------------\n");

            
            IObserver observer1 = new DoorObserver();
            IObserver observer2 = new DoorObserver();

            smartDoor.AddObserver(observer1);
            smartDoor.AddObserver(observer2);

            
            smartDoor.Open();
            smartDoor.Close();
        }
    }
}
