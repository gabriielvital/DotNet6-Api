using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GB.ApiDotNet6.Application.DTOs.Validations
{
    public class PersonDtoValidator : AbstractValidator<PersonDTO>
    {
        public PersonDtoValidator() 
        {
            RuleFor(x => x.Document)
               .NotEmpty()
               .NotNull()
               .WithMessage("Document deve ser informado!");
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name deve ser informado!");
            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("Phone deve ser informado!");
        }
    }
}
