using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.CountDownEventUnity
{
    public class CountDownEvent
    {
        static CountdownEvent ve = new CountdownEvent(10);
        public static void DO()
        {
            //加载order
            ve.Reset(10);
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() => {
                    LoadOrdersTable();
                });
            }
            ve.Wait();
            //加载order
            ve.Reset(5);
            for (int i = 0; i < 5; i++)
            {
                Task.Factory.StartNew(() => {
                    LoadProductsTable();
                });
            }
            ve.Wait();
            //加载order
            ve.Reset(2);
            for (int i = 0; i < 2; i++)
            {
                Task.Factory.StartNew(() => {
                    LoadUsersTable();
                });
            }
            ve.Wait();
            Console.Read();
        }
        static void LoadOrdersTable()
        {
            ve.Signal();
            Console.WriteLine($"当前正在加载order表...{Thread.CurrentThread.ManagedThreadId}");
        }
        static void LoadProductsTable()
        {
            ve.Signal();
            Console.WriteLine($"当前正在加载products表...{Thread.CurrentThread.ManagedThreadId}");
        }
        static void LoadUsersTable()
        {
            ve.Signal();
            Console.WriteLine($"当前正在加载users表...{Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
