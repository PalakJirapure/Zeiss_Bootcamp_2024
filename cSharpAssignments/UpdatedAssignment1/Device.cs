using System;
using System.Collections.Generic;

class Device
{
    [Required]
    public string Id { get; set; }

    [Range(10, 100)]
    public int Code { get; set; }

    [MaxLength(100)]
    public string Description { get; set; }
}
