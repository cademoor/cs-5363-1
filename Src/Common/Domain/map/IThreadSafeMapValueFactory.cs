namespace Ttu.Domain
{
    public interface IThreadSafeMapValueFactory<TValue>
    {

        TValue CreateMapValue(object newValueArg);

    }
}
