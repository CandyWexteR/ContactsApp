using System;

namespace ContactsApp.Exceptions
{
    /// <summary>
    /// Исключение, возникающее при условии отсутствия возможности проведения операции редактирования.
    /// </summary>
    public class InvalidEditOperationException : Exception
    {
        /// <summary>
        /// Создать исключение <see cref="InvalidEditOperationException"/>
        /// </summary>
        /// <param name="message">Сообщение исключения</param>
        public InvalidEditOperationException(string message) : base(message)
        {
        }
    }
}