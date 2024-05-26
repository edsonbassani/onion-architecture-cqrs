using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.TaskManager.Application.Abstractions
{
    public abstract class ServiceBase
    {
        protected async Task<T> ExecuteWithLoggingAsync<T>(Func<Task<T>> func, [CallerMemberName] string? operationName = null)
        {
            try
            {
                return await func().ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        protected async Task ExecuteWithLoggingAsync(Func<Task> func, [CallerMemberName] string? operationName = null)
        {
            try
            {
                await func().ConfigureAwait(false);
            }
            catch
            {
                throw;
            }
        }

        protected void ExecuteWithLogging(Action action, [CallerMemberName] string? operationName = null)
        {
            try
            {
                action();
            }
            catch
            {
                throw;
            }
        }

        protected TResult ExecuteWithLogging<TResult>(Func<TResult> func, [CallerMemberName] string? methodName = null)
        {
            try
            {
                var result = func();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
