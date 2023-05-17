using System;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Validations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public sealed class PositiveIntegerAttribute : ValidationAttribute {

    public PositiveIntegerAttribute() : base("The {0} field must be a positive integer.") { }
        
    public override bool IsValid(object? value) {
        if (value == null) {
            return false;
        }

        int i;
        if (value is int num) {
            i = num;
        } else if (!int.TryParse(value.ToString(), out i)) {
            return false;
        }

        return i >= 0;
    }
}
