using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfSample
{
    class ConsoleThread
    {
        public Dispatcher ParentDispatcher { get; private set; }
        Action<string> notifyInput;
        public bool IsActive { get; private set; } = false;

        public ConsoleThread(Dispatcher d, Action<string> a)
        {
            ParentDispatcher = d;
            notifyInput = a;
        }

        public void ExecuteConsole()
        {

            Task consoleTask = Task.Run(() =>
            {
                IsActive = true;
                Console.WriteLine("Show console window from wpf project!!");
                while (true)
                {
                    Console.Write("In> ");
                    var l = Console.ReadLine();
                    Console.WriteLine($"[Out]:{l}");
                    if (l.ToLower() == "exit")
                        break;
                    notifyInput(l);
                }
                IsActive = false;
            });

        }



    }
}
