namespace IntroToFunctionalProgrammingInCS
{
    interface IOption<T>
    {
        TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> onNone);
    }

    class Some<T> : IOption<T>
    {
        private T _data;

        public Some(T data)
        {
            _data = data;
        }

        public TResult Match<TResult>(Func<T, TResult> onSome, Func<TResult> _) =>
            onSome(_data);
    }

    class None<T> : IOption<T>
    {
        public TResult Match<TResult>(Func<T, TResult> _, Func<TResult> onNone) =>
            onNone();
    }
}
