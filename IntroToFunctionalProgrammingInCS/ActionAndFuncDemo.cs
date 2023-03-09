namespace IntroToFunctionalProgrammingInCS
{
    internal class ActionAndFuncDemo
    {
        public static void Run()
        {
            Action action1 = Console.WriteLine;
            action1();
            Action<string> action2 = Console.WriteLine;
            action2("Terje");
            Func<float, int> func1 = Double;
            Func<double, double> func2 = Math.Sqrt;
            Func<int, int, int, int> func3 = Calc;

            Func<int, int> func4 = i => i * 2;
            Func<int, int> func4b = i =>
            {
                return i * 2;
            };
            Func<int, int> func5 = SimpleDouble;

            int SimpleDouble(int n)
            {
                return n * 2;
            }
        }

        public static void DummyWrite(string txt) { }

        public static int Double(float number)
        {
            return Convert.ToInt32(Math.Round(number * 2));
        }

        public static int Calc(int a, int b, int c)
        {
            return a * 5 - 3 * b + c;
        }
    }
}
