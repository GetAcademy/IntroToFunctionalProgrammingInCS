namespace IntroToFunctionalProgrammingInCS
{
    internal class Demo5CurryingAndPartialApplication
    {
        public static void Run()
        {
            // uten currying
            Console.WriteLine(CreateTagWithoutCurrying("h1", "Norge"));
            Console.WriteLine(CreateTagWithoutCurrying("h2", "Stavern"));

            // med currying og partial application
            var h1creator = CreateTagLambda("h1");
            var h2creator = CreateTagLambda("h2");
            Console.WriteLine(h1creator("Norge"));
            Console.WriteLine(h2creator("Stavern"));

            // Action vs Func
        }

        public static string CreateTagWithoutCurrying(string tagName, string content)
        {
            return $"<{tagName}>{content}</{tagName}>";
        }

        public static Func<string, Func<string, string>> CreateTagLambda =
            tagName => content => $"<{tagName}>{content}</{tagName}>";


        public static Func<string, string> CreateTag(string tagName)
        {
            string CreateTagImpl(string content)
            {
                return $"<{tagName}>{content}</{tagName}>";
            }
            return CreateTagImpl;
        }
    }
}
