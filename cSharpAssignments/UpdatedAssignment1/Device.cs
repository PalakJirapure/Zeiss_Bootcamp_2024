using System;
using System.Collections.Generic;

namespace DeviceValidatorAssignment
{
    class Device
    {
        [Required(ErrorMessage = "ID Property Requires Value")]
        [Pattern(@"^\d{5}[A-Z]{3}$", ErrorMessage = "ID must be in the format 5 digits followed by 3 uppercase letters.")]
        public string Id { get; set; }

        [Range(10, 100, ErrorMessage = "Code Value Must Be Within 10-100")]
        public int Code { get; set; }

        [MaxLength(100, ErrorMessage = "Max of 100 Characters are allowed")]
        public string Description { get; set; }

        [CustomValidation("ABC", ErrorMessage = "CustomProperty must contain the parameter ABC.")]
        public string CustomProperty { get; set; }
    }
}
