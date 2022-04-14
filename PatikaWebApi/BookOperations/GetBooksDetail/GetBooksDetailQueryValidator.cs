using FluentValidation;

namespace PatikaWebApi.BookOperations.GetBooksDetail
{
    public class GetBooksDetailQueryValidator : AbstractValidator<GetBooksDetailQuery>
    {
        public GetBooksDetailQueryValidator(){

            RuleFor(query => query.BookId).GreaterThan(0);
           // RuleFor(query => query.BookName).NotEmpty().MinimumLength(1);
            
        }
    }
}
