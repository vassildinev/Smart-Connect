namespace SmartConnect.Services.Common.Helpers
{
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public static class AsyncHelper
    {
        private static TaskFactory taskFactory;

        static AsyncHelper()
        {
            taskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);
        }

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            TaskAwaiter<TResult> awaiter = taskFactory.StartNew(() => {
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUICulture;
                return func();
            })
            .Unwrap()
            .GetAwaiter();
            return awaiter.GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            CultureInfo currentUICulture = CultureInfo.CurrentUICulture;
            CultureInfo currentCulture = CultureInfo.CurrentCulture;

            TaskAwaiter awaiter = taskFactory.StartNew(() => {
                Thread.CurrentThread.CurrentCulture = currentCulture;
                Thread.CurrentThread.CurrentUICulture = currentUICulture;
                return func();
            })
            .Unwrap()
            .GetAwaiter();

            awaiter.GetResult();
        }
    }
}
