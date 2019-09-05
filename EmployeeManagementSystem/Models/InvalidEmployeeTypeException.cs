using System;
using System.Runtime.Serialization;

namespace EmployeeManagementSystem.Models
{
    [Serializable]
    internal class InvalidEmployeeTypeException : Exception
    {
        public InvalidEmployeeTypeException()
        {
        }

        public InvalidEmployeeTypeException(string message) : base(message)
        {
        }

        public InvalidEmployeeTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidEmployeeTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}