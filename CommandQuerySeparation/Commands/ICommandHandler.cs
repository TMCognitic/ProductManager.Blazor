namespace CommandQuerySeparation.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        bool Execute(TCommand command);
    }
}
