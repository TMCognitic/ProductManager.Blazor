namespace CommandQuerySeparation.Commands
{
    public interface ICommandHandlerAsync<TCommand>
        where TCommand : ICommandDefinition
    {
        Task<bool> Execute(TCommand command);
    }
}
