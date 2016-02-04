namespace SmartConnect.Web.Infrastructure
{
    using System;

    using Common.Constants;
    using Ninject;
    using SmartConnect.Common.Exceptions;

    public class ObjectFactory
    {
        private static volatile ObjectFactory objectFactory;

        private static object syncLock = new object();

        private IKernel kernel;

        private ObjectFactory()
        { }

        public static ObjectFactory Instance
        {
            get
            {
                if (objectFactory == null)
                {
                    lock (syncLock)
                    {
                        if (objectFactory == null)
                        {
                            objectFactory = new ObjectFactory();
                        }
                    }
                }

                return objectFactory;
            }
        }

        public void InitializeKernel(IKernel appKernel)
        {
            if(this.kernel != null)
            {
                throw new ServiceLocatorInitializeException(ServiceLocator.MultipleInitializationMessage);
            }

            this.kernel = appKernel;
        }

        public T GetInstance<T>()
        {
            return this.kernel.Get<T>();
        }

        public object GetInstance(Type type)
        {
            return this.kernel.Get(type);
        }

        public T TryGetInstance<T>()
        {
            return this.kernel.TryGet<T>();
        }

        public object TryGetInstance(Type type)
        {
            return this.kernel.TryGet(type);
        }
    }
}
