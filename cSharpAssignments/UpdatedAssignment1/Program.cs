using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Device
{
    [Required]
    public string Id { get; set; }

    [Range(10, 100)]
    public int Code { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }
}

class Program
{
    static void Main()
    {
        Device deviceObj = new Device();
        deviceObj.Id = "31027INT";
        deviceObj.Code = 10;
        deviceObj.Description = "Good toy to play with";
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
