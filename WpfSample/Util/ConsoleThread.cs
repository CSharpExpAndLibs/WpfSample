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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dispatcher">伝達先のUIスレッドのディスパッチャ</param>
        /// <param name="notifyCallBack">UIスレッドへの通知に用いるコールバック</param>
        public ConsoleThread(Dispatcher dispatcher, Action<string> notifyCallBack)
        {
            ParentDispatcher = dispatcher;
            notifyInput = notifyCallBack;
        }

        /// <summary>
        /// Consoleに入力された文字列をコールバックでUIスレッドへ
        /// 伝える
        /// </summary>
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
