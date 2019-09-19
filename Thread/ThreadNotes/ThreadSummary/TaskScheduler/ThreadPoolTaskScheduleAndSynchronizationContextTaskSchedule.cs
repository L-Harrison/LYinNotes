using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSummary.TaskScheduler
{
    public class ThreadPoolTaskScheduleAndSynchronizationContextTaskSchedule
    {

    }
    //public partial class Form1 : Form
    //{
    //    delegate void de();
    //    private delegate void invokeDelegate();
    //    public Form1()
    //    {
    //        InitializeComponent();
    //    }
    //    volatile int s = 0;
    //    private void Button1_Click(object sender, EventArgs e)
    //    {

    //        ThreadLocal<int> i = new ThreadLocal<int>();

    //        //var task = new Task(() => {
    //        //    Thread.Sleep(2000);
    //        //    var n = 0;
    //        //   // while (true)
    //        //    {
    //        //        try
    //        //        {
    //        //            //this.label1.Invoke(new de(() =>
    //        //            //{
    //        //            //    this.label1.Text = n++.ToString();
    //        //            //}));
    //        //            //this.label1.Text = n++.ToString();   
    //        //            this.label1.Text = "dsad";
    //        //            Thread.Sleep(500);
    //        //        }
    //        //        catch (Exception ex)
    //        //        {

    //        //        }
    //        //    }
    //        //});
    //        //task.Start(TaskScheduler.FromCurrentSynchronizationContext());
    //        var t = Task.Factory.StartNew<int>(() =>
    //        {
    //            Thread.Sleep(5000);
    //            //var n = 0;
    //            //while (true)
    //            //{
    //            //    try
    //            //    {
    //            //        //this.label1.Invoke(new de(() =>
    //            //        //{
    //            //        //    this.label1.Text = n++.ToString();
    //            //        //}));
    //            //        this.label1.Text = n++.ToString();
    //            //        Thread.Sleep(500);
    //            //    }
    //            //    catch (Exception ex)
    //            //    {

    //            //    }
    //            // }
    //            return 10;
    //        }).ContinueWith((n) =>
    //        {
    //            this.label1.Text = n.Result.ToString();
    //        }, TaskScheduler.FromCurrentSynchronizationContext());

    //    }

   
    //}
}
