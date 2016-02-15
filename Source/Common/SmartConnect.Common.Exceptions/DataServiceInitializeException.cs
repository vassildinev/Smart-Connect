namespace SmartConnect.Common.Exceptions
{
    using System;

    public class DataServiceInitializeException : Exception
    {
        public DataServiceInitializeException()
        { }

        public DataServiceInitializeException(string message)
            : base(message)
        { }
    }
}
