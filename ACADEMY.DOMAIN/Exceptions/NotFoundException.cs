﻿namespace ACADEMY.DOMAIN.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string mensaje) : base(mensaje) { }
    }
}
