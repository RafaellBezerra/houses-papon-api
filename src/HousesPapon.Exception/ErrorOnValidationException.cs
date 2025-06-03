using System.Net;

namespace HousesPapon.Exception
{
    public class ErrorOnValidationException : HousesPaponException
    {
        private readonly List<string> _errorMessages;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty) => _errorMessages = errorMessages;

        public override int StatusCodes => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return _errorMessages;
        }
    }
}
