using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSummary.AggregateExceptionUnity
{
   public class AggregateExceptionUnity
    {
        public static void Do()
        {
            var ta = new Task(() =>
            {
                var t1 = Task.Factory.StartNew(() =>
                {
                    throw new AggregateException("t1异常");
                }, TaskCreationOptions.AttachedToParent);
                var t2 = Task.Factory.StartNew(() =>
                {
                    throw new AggregateException("t2异常");
                }, TaskCreationOptions.AttachedToParent);
            });
            try
            {
                try
                {
                    ta.Start();
                    ta.Wait();
                }
                catch (AggregateException ex)
                {

                    foreach (var item in ex.InnerExceptions)
                    {
                        Console.WriteLine(item.Message);
                    }
                    ex.Handle(m =>
                    {
                        if (m.Message.Contains("t1"))
                        {
                            return false;
                        }
                        return true;
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
