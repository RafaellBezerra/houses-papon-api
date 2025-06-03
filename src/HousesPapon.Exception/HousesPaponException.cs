namespace HousesPapon.Exception
{
    public abstract class HousesPaponException : System.Exception
    {
        protected HousesPaponException(string message) : base(message) { }
        public abstract int StatusCodes { get; }
        public abstract List<string> GetErrors();
    }
}
