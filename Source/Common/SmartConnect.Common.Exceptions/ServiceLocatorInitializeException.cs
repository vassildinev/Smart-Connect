namespace SmartConnect.Common.Exceptions
{
    using System;

    public class ServiceLocatorInitializeException : Exception
    {
        public ServiceLocatorInitializeException()
        { }

        public ServiceLocatorInitializeException(string message)
            : base(message)
        { }
    }
}
