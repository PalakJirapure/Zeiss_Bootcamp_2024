
using System;
using UpdatedDoorAssignment;

class Program
{
    static void Main()
    {
        SmartDoor smartDoor = new SmartDoor();

        
        SmartFeatures smartFeatures = new SmartFeatures();
        smartFeatures.ConfigureFeatures(smartDoor);

       
        smartDoor.OpenWithTimer();
        Console.ReadLine();
    }
}
