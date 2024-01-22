using System;
using System.Collections.Generic;

namespace DeviceValidatorAssignment
{
    class Program
    {
        static void Main()
        {
            Device deviceObj = new Device();
            deviceObj.Id = "31027INT";
            deviceObj.Code = 5;
            deviceObj.Description = "Good toy to play with";
            deviceObj.CustomProperty = "ABC Custom Value";
            
            List<string> errors;
            bool isValid = ObjectValidator.Validate(deviceObj, out errors);

            if (!isValid)
            {
                foreach (string item in errors)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("All Perfect!");
            }
        }
    }
}
