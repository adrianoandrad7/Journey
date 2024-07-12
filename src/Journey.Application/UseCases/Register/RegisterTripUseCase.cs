using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;
using Journey.Exception.ExceptionsBase;

namespace Journey.Application.UseCases.Register
{
    public class RegisterTripUseCase
    {
        public ResponseShortTripJson Execute(RequestRegisterTripJson request) 
        {
            Validate(request);

            var dbContext = new JourneyDbContext();

            var entity = new Trip
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
            };

            dbContext.Trips.Add(entity);

            dbContext.SaveChanges();

            return new ResponseShortTripJson
            {
                EndDate = entity.EndDate,
                StartDate = entity.StartDate,
                Name = entity.Name,
                Id = entity.Id
            };
        }

        private void Validate(RequestRegisterTripJson request)
        {
            var validator = new RegisterTripValidator();

            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessagens = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessagens);
            }
        }
    }
}
