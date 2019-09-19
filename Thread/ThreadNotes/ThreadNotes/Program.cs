using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ThreadSummary.CountDownEventUnity;
using ThreadSummary.ParallelUnity;
using ThreadSummary.readerWriterLock;
using ThreadSummary.task;
using ThreadSummary.TaskSchedule;
using ThreadSummary.threadPool;

namespace ThreadNotes.Thread.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Class @class = new Class();
            //@class.Ces();

            //SelfDefineTaskSchedule_Test.DO();
            //ThreadPoolUnity.Do();
            //ThreadPoolUnity.Timer();
            //TaskUnity.Do();
            //TaskUnity.Do2();
            //TaskUnity.Do3();
            //TaskUnity.Do4();
            //ParallelUnity.DO();
            //ReaderWriterLockUnity.DO();
            CountDownEvent.DO();
            Console.Read();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
