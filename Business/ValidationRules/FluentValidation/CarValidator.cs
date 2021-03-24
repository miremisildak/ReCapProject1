using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator() 
        {
            
            RuleFor(c => c.ModelYear).NotNull();
            RuleFor(c => c.DailyPrice).NotNull().GreaterThan(0);
            RuleFor(c => c.Descriptions).NotNull().MinimumLength(2);
            RuleFor(c => c.BrandId).NotNull();
            RuleFor(c => c.ColorId).NotNull();
            RuleFor(c => c.ModelYear).LessThanOrEqualTo(DateTime.Now.Year);
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1970);
        }
    }
}
