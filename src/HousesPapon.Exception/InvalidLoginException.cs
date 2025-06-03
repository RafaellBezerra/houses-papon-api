
using HousesPapon.Exception.Resources;
using System.Net;

namespace HousesPapon.Exception
{
    public class InvalidLoginException : HousesPaponException
    {
        public InvalidLoginException() : base(ResourceErrorMessages.INVALID_EMAIL_OR_PASSWORD) { }
        public override int StatusCodes => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
