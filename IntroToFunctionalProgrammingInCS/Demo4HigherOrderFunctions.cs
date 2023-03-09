namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo4HigherOrderFunctions
    {
        public static void Run()
        {
            var result = DoAndMeasureTime<double,double>(Math.Sqrt, 4096);
            result.Show();
            result = DoAndMeasureTime<double, double>(Math.Log2, 4096);
            result.Show();
        }

        public static Result<TResult> DoAndMeasureTime<T, TResult>(Func<T,TResult> f, T arg)
        {
            var startTime = DateTime.Now;
            var value = f(arg);
            var endTime = DateTime.Now;
            return new Result<TResult>(value, (endTime - startTime).TotalMilliseconds);
        }

        internal class Result<T>{
            T Value { get; }
            double Millis { get; }

            public Result(T value, double millis)
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
