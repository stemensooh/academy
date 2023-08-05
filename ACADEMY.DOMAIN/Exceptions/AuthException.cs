namespace ACADEMY.DOMAIN.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException(string mensaje) : base(mensaje) { }
    }
}
