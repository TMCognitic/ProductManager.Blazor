namespace CommandQuerySeparation.Commands
{
    public interface ICommandAsyncHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        Task<bool> ExecuteAsync(TCommand command);
    }
}
