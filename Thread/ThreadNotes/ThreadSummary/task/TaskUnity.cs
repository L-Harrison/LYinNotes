using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.task
{
    public class TaskUnity
    {
        public static void Do()
        {
            Task task = new Task(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("t1");
            });
            var task2 = new Task(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("t2");
            });
            task.Start();
            task2.Start();
            //Task.WaitAll(new Task[] { task, task2 });
            //Task.WaitAny(new Task[] { task, task2 });
            Task.WhenAll(new Task[] { task, task2 }).ContinueWith(m =>
            {
                Console.WriteLine("全部结束时执行");
            });
            Console.WriteLine("结束");

        }
        public static void Do2()
        {
            Task<int> task = new Task<int>(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("t1");
                return 1;
            });
            var task2 = new Task<int>(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("t2");
                return 2;
            });
            task.Start();
            task2.Start();
            //Task.WaitAll(new Task[] { task, task2 });
            //Task.WaitAny(new Task[] { task, task2 });
            Task<int>.WhenAll<int>(new Task<int>[] { task, task2 }).ContinueWith((m) =>
            {
                Console.WriteLine($"全部结束时执行{string.Join(",", m.Result)}");



            });
            //var p=  task.ContinueWith(n => {
            //  Console.WriteLine(n.Result);
            //  return 22;
            //});
            // Console.WriteLine(p.Result);
            Console.WriteLine("结束");

        }
        /// <summary>
        ///     TaskCreationOptions 得作用
        /// </summary>
        public static void Do3()
        {
           Task.Factory.StartNew(() => {

                var t1 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("t1");
                },TaskCreationOptions.AttachedToParent);
                var t2 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(4000);
                    Console.WriteLine("t2");
                }, TaskCreationOptions.AttachedToParent);
               //注意此处    TaskCreationOptions.AttachedToParent得作用
           },TaskCreationOptions.DenyChildAttach).ContinueWith(m=> {

                Console.WriteLine("结束");
            });

        }
        /// <summary>
        ///     TaskContinuationOptions  CancellationTokenSource 得作用
        /// </summary>
        public static void Do4()
        {
            CancellationTokenSource token = new CancellationTokenSource();
            token.Cancel();
         
           Task.Factory.StartNew(() => {

                var t1 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("t1");
                }, TaskCreationOptions.AttachedToParent);
                var t2 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(4000);
                    Console.WriteLine("t2");
                },token.Token,TaskCreationOptions.AttachedToParent, TaskScheduler.Current);
               //注意此处    TaskCreationOptions.AttachedToParent得作用
           }).ContinueWith(m=> {

                Console.WriteLine("结束");
            }, TaskContinuationOptions.LazyCancellation);

        }

        public static void DO5()
        {
            int ce = 0;
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            cancellationToken.Token.Register(() =>
            {
                Console.WriteLine("取消时调用");
            });
            var task = Task.Factory.StartNew(() =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine($"{ce++}");
                }
            }, cancellationToken.Token);
            //System.Threading.Thread.Sleep(30000);
            //cancellationToken.Cancel();
            cancellationToken.CancelAfter(new TimeSpan(0, 0, 10));


        }
    }
}
