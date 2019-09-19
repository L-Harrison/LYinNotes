using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSummary.lockUnity
{
    public class MonitorsUnity
    {
        static Object obj = new Object();
        object s = new object();
        static int num = 0;
        public static void Moni()
        {
            //for (int i = 0; i < 5; i++)
            //{
            //    Task.Factory.StartNew(() =>
            //    {                    
            //        for (int j = 0; j < 100; j++)
            //        {
            //            var f = false;
            //            try
            //            {
            //                Monitor.Enter(obj, ref f);
            //                Console.WriteLine(num++);
            //                //Monitor.Exit(obj);
            //            }
            //            catch (Exception ex)
            //            {

            //            } finally
            //            {
            //                if (f)
            //                {
            //                    Monitor.Exit(obj);
            //                }
            //            }
            //        }
            //    });
            //}     
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        lock (obj)
                        {
                            Console.WriteLine(num++);
                        }
                        //var f = false;
                        //try
                        //{
                        //    Monitor.Enter(obj, ref f);
                        //    Console.WriteLine(num++);
                        //    //Monitor.Exit(obj);
                        //}
                        //catch (Exception ex)
                        //{

                        //} finally
                        //{
                        //    if (f)
                        //    {
                        //        Monitor.Exit(obj);
                        //    }
                        //}
                    }
                });
            }
        }
    }
}
