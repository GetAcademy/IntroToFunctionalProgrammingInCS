namespace IntroToFunctionalProgrammingInCS
{
    abstract class Option<T>
    {
        public abstract Option<TResult> Run<TResult>(Func<T, TResult> f);

        public static Option<T> Wrap(T value)
        {
            return value == null ? new None<T>() : new Some<T>(value);
        }
    }

    class Some<T> : Option<T>
    {
        public T Data { get; }

        public Some(T data)
        {
            Data = data;
        }

        public override Option<TResult> Run<TResult>(Func<T, TResult> f)
        {
            return Option<TResult>.Wrap(f(Data));
        }

    }

    class None<T> : Option<T>
    {
        public override Option<TResult> Run<TResult>(Func<T, TResult> f)
        {
            return new None<TResult>();
        }
    }
}
