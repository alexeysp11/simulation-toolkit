using System; 
using System.Threading; 
using System.Threading.Tasks; 

namespace Test.StreetRacing.VisualElements
{
    /// <summary>
    /// Class that allows to use threads for executing tests 
    /// </summary>
    public static class ThreadHelper
    {
        /// <summary>
        /// Allows to use STA 
        /// </summary>
        /// <param name="action">Delegate for using anonymous methods</param>
        /// <returns>Type of an asynchronous method</returns>
        public static Task StartSTATask(Action action)
        {
            var tcs = new TaskCompletionSource<object>();
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                    tcs.SetResult(new object());
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            return tcs.Task;
        }
    }
}