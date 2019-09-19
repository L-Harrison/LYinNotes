using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.readerWriterLock
{
    public class ReaderWriterLockUnity
    {
        static ReaderWriterLock rwLock = new ReaderWriterLock();
        public static void DO()
        {
            Read();
            Write();
        }

        private static void Write()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    rwLock.AcquireWriterLock(int.MaxValue);
                    Thread.Sleep(5000);
                    Console.WriteLine($"正在写入信息:{Thread.CurrentThread.ManagedThreadId}---{DateTime.Now}");
                    rwLock.ReleaseWriterLock();
                }
            });
        }

        private static void Read()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(10);
                    rwLock.AcquireReaderLock(int.MaxValue);
                    Thread.Sleep(100);
                    Console.WriteLine($"正在读取信息:{Thread.CurrentThread.ManagedThreadId}---{DateTime.Now}");
                    rwLock.ReleaseReaderLock();
                }
            });
        }
    }
}
