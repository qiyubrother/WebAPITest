using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPITest
{
    public class DebugHelper
    {
        private Queue<string> queue = new Queue<string>();
        private bool endService = false;
        public string DebugFileName = $@"Debug-{DateTime.Now.Year}{DateTime.Now.Month.ToString().PadLeft(2, '0')}{DateTime.Now.Day.ToString().PadLeft(2, '0')}.log";
        public void Print(string s)
        {
            var d = $"[{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff")}]" + s;
            queue.Enqueue(d);
            Console.WriteLine(d);
        }

        public void StartService()
        {
            Task.Run(() =>
            {
                do
                {
                    if (queue.Count > 0)
                    {
                        var s = queue.Dequeue();
                        System.IO.File.AppendAllLines(DebugFileName, new[] { s });
                    }
                    System.Threading.Thread.Sleep(20);
                } while (!endService);
            });
        }

        public void EndService() => endService = true;
    }
}
