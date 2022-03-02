using System;

namespace ContactsApp.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при условии отсутствия возможности проведения операции.
    /// </summary>
    public class InvalidEditOperationException : Exception
    {
        public InvalidEditOperationException(string message) : base(message)
        {
        }
    }
}