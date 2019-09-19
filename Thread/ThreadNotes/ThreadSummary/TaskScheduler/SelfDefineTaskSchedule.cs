using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.TaskSchedule
{
    public class SelfDefineTaskSchedule : TaskScheduler
    {
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }

        protected override void QueueTask(Task task)
        {
            var thread = new Thread(() =>
            {
                TryExecuteTask(task);
            });
            thread.Start();
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return true;
        }
    }

    public class SelfDefineTaskSchedule_Test
    {
        public static void DO()
        {
            var task = new Task(() => {
                Console.WriteLine("sas");
            });
            task.Start(new SelfDefineTaskSchedule());
            Console.Read();
        }
    }

}
