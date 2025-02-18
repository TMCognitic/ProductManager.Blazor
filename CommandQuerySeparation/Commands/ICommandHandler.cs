using CommandQuerySeparation.Results;

namespace CommandQuerySeparation.Commands
{
    public interface ICommandHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        Result Execute(TCommand command);
    }
}
