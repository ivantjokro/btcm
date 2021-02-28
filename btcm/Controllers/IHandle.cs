namespace btcm.Controllers
{
    public interface IHandlesCommand<in TCommand, out TResult> : IHandler where TCommand : ICommand<TResult>
    {
        TResult Handle(string hashBlockNumber);
    }
}
