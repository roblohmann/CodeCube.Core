using System;
using System.Threading;
using System.Threading.Tasks;

namespace CodeCube.Core.Helpers
{
    /// <summary>
    /// Helper class to execute async methods synchronously.
    /// </summary>
    /// <remarks>Code gracefully taken from https://cpratt.co/async-tips-tricks. </remarks>
    public static class AsyncHelper
    {
        private static readonly TaskFactory _taskFactory = new TaskFactory(CancellationToken.None, TaskCreationOptions.None, TaskContinuationOptions.None, TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();

        public static void RunSync(Func<Task> func)
            => _taskFactory
                .StartNew(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
    }
}
