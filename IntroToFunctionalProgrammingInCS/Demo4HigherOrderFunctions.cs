namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo4HigherOrderFunctions
    {
        public static void Run()
        {
            var result = DoAndMeasureTime(Math.Sqrt, 4096);
            result.Show();
            result = DoAndMeasureTime(Math.Log2, 4096);
            result.Show();
        }

        public static Result DoAndMeasureTime(Func<double,double> f, double arg)
        {
            var startTime = DateTime.Now;
            var value = f(arg);
            var endTime = DateTime.Now;
            return new Result(value, (endTime - startTime).TotalMilliseconds);
        }

        internal class Result{
            double Value { get; }
            double Millis { get; }

            public Result(double value, double millis)
            {
                Value = value;
                Millis = millis;
            }

            public void Show()
            {
                Console.WriteLine($"Svar: {Value} Tid: {Millis}ms");
            }
        }
    }
}
