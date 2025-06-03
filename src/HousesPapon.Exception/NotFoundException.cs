
using System.Net;

namespace HousesPapon.Exception
{
    public class NotFoundException : HousesPaponException
    {
        public NotFoundException(string message) : base(message) { }
        public override int StatusCodes => (int)HttpStatusCode.NotFound;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
