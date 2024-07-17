using FluentValidation;
using Journey.Communication.Requests;
using Journey.Exception;

namespace Journey.Application.UseCases.Activities.Register
{
    public class RegisterActivityVaidator : AbstractValidator<RequestRegisterActivityJson>
    {
        public RegisterActivityVaidator() 
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_EMPTY);
        }
    }
}
