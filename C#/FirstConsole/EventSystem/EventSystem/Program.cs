using System;

namespace EventSystem
{

    class MyEventArgs : EventArgs
    {
        private string time;
        private string name = "MyEvent";

        public string Time
        {
            get
            {
                return time;
            }
        }

        public string Name
        {
            get { return name; }
        }
        public MyEventArgs(string time, string name)
        {
            this.time = time;
            this.name = name;
        }
        public MyEventArgs(string time)
        {
            this.time = time;
        }
    }
    
    class Events
    {
        static event EventHandler onSpacePressed;
        private static event EventHandler<MyEventArgs> onSpacePressed_2;
        static bool end_while = false;

        static void Test_Delegate_Event(string msg2)
        {
            Console.WriteLine("==Test_Delegate_Event==");
            Console.WriteLine($"msg = {msg2}");
        }
        
        static void Test_onSpacePressed_Event_My(object sender, MyEventArgs e)
        {
            Console.WriteLine($"==Test_onSpacePressed_Event_My==");

            Console.WriteLine($"Sender = {sender} and e = {e}, so e.time = {e.Time} & e.name = {e.Name}");
        }

        static void Test_onSpacePressed_Event(object sender, EventArgs e)
        {
            Console.WriteLine($"==Test_onSpacePressed_Event==");
            Console.WriteLine($"Sender = {sender} and e = {e}");
        }
        delegate void EventHandlerOnDelegate(string msg);
        static event EventHandlerOnDelegate OnPressUp;
        static void Main()
        {
            OnPressUp += Test_Delegate_Event;
            onSpacePressed += Test_onSpacePressed_Event;
            onSpacePressed_2 += Test_onSpacePressed_Event;
            onSpacePressed_2 += Test_onSpacePressed_Event_My;
            int key_p;
            do
            {
                key_p = Console.Read();
                Console.WriteLine($"{key_p.ToString()}");
                if (key_p.ToString() == "101")
                {
                    end_while = true;
                }
                else if (key_p.ToString() == "115")
                {
                    if (onSpacePressed_2 != null) onSpacePressed_2("Pressed 's'", new MyEventArgs(System.DateTime.Now.ToString(), "My Sec Name"));
                }else if (key_p.ToString() == "100")
                {
                    onSpacePressed?.Invoke("This2", EventArgs.Empty);
                } else if (key_p.ToString() == "102")
                {
                    if (onSpacePressed_2 != null) onSpacePressed_2("Pressed 'f'", new MyEventArgs(System.DateTime.Now.ToString()));
                } else if (key_p.ToString() == "103")
                {
                    OnPressUp?.Invoke("Now i pressed 'g' and send this msg via delegated event");
                }

                Console.ReadLine();
            } while (!end_while);

            Environment.Exit(0);
        }
    }
}