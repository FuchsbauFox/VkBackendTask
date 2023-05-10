using System;

namespace Users.Application.Common.Exceptions
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string login)
            : base($"User with this login: \"{login}\" already exists.")
        {
        }
    }
}