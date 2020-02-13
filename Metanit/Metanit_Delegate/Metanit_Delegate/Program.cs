using System;

namespace Metanit_Delegate
{
    delegate int  Solver(int x, int y);

    delegate void SendMess(string mes);

    delegate double Operations(params double[] arrayofparams);

    class Program
    {
        Solver solver;

        static void Main(string[] args)
        {
            //int x = 10, y = 15;

            Rectangle R = ContrTest; // contr

            Action<int, int> action = (x, y) => Console.WriteLine(x+y); ;

            action?.Invoke(19, 15);

            Predicate<int> predicate = x =>x>34;

            Console.WriteLine(predicate?.Invoke(19 + 15));

            Func<int, int, int, int> func = (x, y, z) => x + y + z;

            Console.WriteLine(predicate?.Invoke(func(4, 12, 17)));


            FigureDelegateCova<Figure> fdCova = FigureCreater;
            
            Console.WriteLine(fdCova?.Invoke().Name);

            FigureDelegateCova<Rect> rdCova = RectCreater;

            Console.WriteLine(rdCova?.Invoke().Comment);

            FigureDelegateCova<Figure> fdCova1 = rdCova;

            Console.WriteLine(fdCova1?.Invoke());

            StartGame();


            Console.ReadKey();
        }

        public static void StartGame()
        {
            PingPongArg pingPongArg = new PingPongArg();
            pingPongArg.Count = 999;
            pingPongArg.pingPlayer = new Ping();
            pingPongArg.pingPlayer.PingHandler += GetPing;


            pingPongArg.pongPlayer = new Pong();
            pingPongArg.pongPlayer.PongHandler += GetPong;

            pingPongArg.pingPlayer.PingMethod(pingPongArg);
        }

        public static void GetPing(object sender, PingPongArg arg, string message)
        {
            if (arg.Count == 0)
              Console.WriteLine("Game is stopped");
            else
            {
                arg.Count--;

                Console.WriteLine($"{message} осталось проходов: {arg.Count}");

                arg.pongPlayer.PongMethod(arg);
            } 
        }

        public static void GetPong(object sender, PingPongArg arg, string message)
        {
            if (arg.Count == 0)
                Console.WriteLine("Game is stopped");
            else
            {
                arg.Count--;

                Console.WriteLine($"{message} осталось проходов: {arg.Count}");

                arg.pingPlayer.PingMethod(arg);
            }
        }


        public Program()
        {
            int x = 5, y = 5;

            //solver = new Solver(SayHello());
        }


        private static Figure FigureCreater()
        {
            return new Figure(5, 6) {Name = "Figure"};
        }

        private static Rect RectCreater()
        {
            return new Rect(5, 6) { Name = "Rect", Comment = "Comment"};
        }

        private static void ContrTest(Rect r)
        {

        }

        private static void IncEvent(object ob, AccauntEventArgs arg)
        {
            Console.WriteLine("IncEvent");

            Console.WriteLine($"{ob} _____{arg.Message}______{arg.Val}");
        }

        private static void Inc(int i, double d, object ob, AccauntEventArgs arg)
        {
            Console.WriteLine("inc i++");

            Console.WriteLine($"{ob} _____{arg.Message}______{arg.Val}");
        }

        private static void Smth(int x, Operations p, object ob, AccauntEventArgs arg)
        {

            Console.WriteLine(p?.Invoke(1,2,3,4));
        }

        private static void Inc2(int i, string s, object ob, AccauntEventArgs arg)
        {
            Console.WriteLine("inc2 i++");

            Console.WriteLine($"{ob} _____{arg.Message}______{arg.Val}");
        }
        private static void SayHello()
        {
            Console.WriteLine("Hello!!!");
        }
        private static int Multiple(int x, int y)
        {
            return x * y;
        }
    }
}
