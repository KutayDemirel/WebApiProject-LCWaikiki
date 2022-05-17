using FluentValidation;
using System;

namespace PatikaWebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.FirstName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.LastName).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.DateOfBirth).NotEmpty().LessThan(DateTime.Now.Date);

        }
    }
}
