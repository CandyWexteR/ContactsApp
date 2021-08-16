using System;

namespace ContactsApp.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при условии отсутствия возможности проведения операции.
    /// </summary>
    public class InvalidOperationException : Exception
    {
        public InvalidOperationException(string message) : base(message)
        {
        }
    }
}