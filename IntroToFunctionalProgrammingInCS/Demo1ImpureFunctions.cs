namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo1ImpureFunctions
    {
        public static void Run()
        {
            // eks 1
            Greet("Terje");

            // eks
            var stats = new ImpureStats();
            stats.AddNumber(1);
            stats.AddNumber(2);
            stats.Show();
        }

        public static void Greet(string name)
        {
            Console.WriteLine($"Hei, {name}!");
        }
    }

    class ImpureStats
    {
        private int _count;
        private int _sum;
        private float mean => (float)_sum / _count;
        private int? _min;
        private int? _max;

        public void AddNumber(int number)
        {
            _count++;
            _sum += number;
            _min = _min == null ? number : Math.Min(_min.Value, number);
            _max = _max == null ? number : Math.Max(_max.Value, number);
        }

        public void Show()
        {
            Console.WriteLine($@"
                Antall tall:  {_count}
                Sum:          {_sum}
                Gjennomsnitt: {mean}
                Min:          {_min}
                Max:          {_max}
            ");
        }

    }
}
