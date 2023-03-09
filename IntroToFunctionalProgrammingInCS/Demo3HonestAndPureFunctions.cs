namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo3HonestAndPureFunctions
    {
        public static void Run()
        {
            IStats stats = new EmptyStats();
            stats.Show();
            stats = stats.AddNumber(1);
            stats = stats.AddNumber(2);
            stats.Show();
        }

        public static string CreateGreeting(string name)
        {
            return $"Hei, {name}!";
        }
    }

    interface IStats
    {
        int Count { get; }
        int Sum { get; }
        int Min { get; }
        int Max { get; }
        float Mean { get; }

        IStats AddNumber(int number);
        void Show();
    }

    class EmptyStats : IStats
    {
        public int Count { get; } = 0;
        public int Sum { get; } = 0;
        public int Min => throw  new ApplicationException();
        public int Max => throw new ApplicationException();
        public float Mean => (float)Sum / Count;
        public IStats AddNumber(int number)
        {
            return new PureStats2(1, number, number, number);
        }
        public void Show()
        {
            Console.WriteLine($@"
                Antall tall:  0
                Sum:          0
                Gjennomsnitt: N/A
                Min:          N/A
                Max:          N/A
            ");
        }
    }
    class PureStats2 : IStats
    {
        public int Count { get; }
        public int Sum { get; }
        public int Min { get; }
        public int Max { get; }
        public float Mean => (float)Sum / Count;

        public PureStats2(int count, int sum, int min, int max)
        {
            Count = count;
            Sum = sum;
            Min = min;
            Max = max;
        }

        public IStats AddNumber(int number)
        {
            return new PureStats2(Count + 1, Sum + number, Math.Min(Min, number), Math.Max(Max, number)
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
