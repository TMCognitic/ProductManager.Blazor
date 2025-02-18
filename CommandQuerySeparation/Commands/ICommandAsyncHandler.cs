using CommandQuerySeparation.Results;

namespace CommandQuerySeparation.Commands
{
    public interface ICommandAsyncHandler<TCommand>
        where TCommand : ICommandDefinition
    {
        Task<Result> ExecuteAsync(TCommand command);
    }
}
