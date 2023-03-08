namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo2PureFunctions
    {
        public static void Run()
        {
            var text = CreateGreeting("Terje");
            Console.WriteLine(text);

            var stats = new PureStats();
            stats = stats.AddNumber(1);
            stats = stats.AddNumber(2);
            stats.Show();
        }

        public static string CreateGreeting(string name)
        {
            return $"Hei, {name}!";
        }
    }

    class PureStats
    {
        public int Count { get; }
        public int Sum { get; }
        public int? Min { get; }
        public int? Max { get; }
        public float Mean => (float)Sum / Count;

        public PureStats() : this(0, 0, null, null)
        {
        }

        public PureStats(int count, int sum, int? min, int? max)
        {
            Count = count;
            Sum = sum;
            Min = min;
            Max = max;
        }

        public PureStats AddNumber(int number)
        {
            return new PureStats(
                Count + 1,
                Sum + number,
                Min == null ? number : Math.Min(Min.Value, number),
                Max == null ? number : Math.Max(Max.Value, number)
            );
        }

        public void Show()
        {
            Console.WriteLine($@"
                Antall tall:  {Count}
                Sum:          {Sum}
                Gjennomsnitt: {Mean}
                Min:          {Min}
                Max:          {Max}
            ");
        }
    }
}

