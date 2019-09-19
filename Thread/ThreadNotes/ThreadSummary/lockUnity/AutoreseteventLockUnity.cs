using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.lockUnity
{
    public class AutoreseteventLockUnity
    {
        //TaskScheduler
        static AutoResetEvent areLock = new AutoResetEvent(true);
        static ManualResetEvent manLock = new ManualResetEvent(false);
        static Semaphore seLock = new Semaphore(1, 10);
        static Mutex mutexLock = new Mutex();
        static ManualResetEventSlim ManualResetEventSlim = new ManualResetEventSlim();
        public static void Do()
        {
            areLock.WaitOne();  //塞一张火车票到闸机中
            Console.WriteLine("火车票验证通过,可以通行了");
            areLock.Set();     //从闸机中取走火车票
        }
        public static void Mutex()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        mutexLock.WaitOne();
                        Console.WriteLine(m++);
                        mutexLock.ReleaseMutex();
                    }
                });
            }
        }
        public static void Semphore()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        seLock.WaitOne();
                        Console.WriteLine(m++);
                        seLock.Release();
                    }
                });
            }
        }
        public static void ManualSet()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    for (int j = 0; j < 100; j++)
                    {
                        manLock.WaitOne();
                        Console.WriteLine(m++);
                    }
                });
            }
            Thread.Sleep(5000);
            manLock.Set();
        }
        public static void AutoReset()
        {
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        for (int j = 0; j < 100; j++)
                        {
                            areLock.WaitOne();
                            Console.WriteLine(m++);
                            areLock.Set();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {

                    }
                });
            }
        }
        static int m = 0;
    }
}
