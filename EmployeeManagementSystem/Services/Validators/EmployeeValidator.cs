using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;
using FluentValidation.Resources;
using FluentValidation.Internal;
using FluentValidation;


namespace EmployeeManagementSystem.Services.Validators
{
 
    public class EmployeeDataValidator : AbstractValidator<EmployeeData>
    {
        public EmployeeDataValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Salary).InclusiveBetween(10, 100000);
            RuleFor(x => x.Age).GreaterThan(17);
        }
       
        
    }
    public class ManagerValidator : AbstractValidator<Manager>
    {
        public ManagerValidator()
        {
            RuleFor(x => x.EmployeesUnderManager.Count).GreaterThan(0);
            
        }
    }


}
