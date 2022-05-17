using FluentValidation;

namespace PatikaWebApi.Application.AuthorOperations.Queries.GetAuthorsDetail
{
    public class GetAuthorsDetailQueryValidator : AbstractValidator<GetAuthorsDetailQuery>
    {
        public GetAuthorsDetailQueryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
    }
}
