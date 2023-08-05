namespace ACADEMY.DOMAIN.Exceptions
{
    public class ValidatorException : Exception
    {
        public ValidatorException(string mensaje) : base(mensaje) { }
    }
}
