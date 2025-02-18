using CommandQuerySeparation.Results;

namespace CommandQuerySeparation.Queries
{
    public interface IQueryAsyncHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Task<Result<TResult>> ExecuteAsync(TQuery query);
    }
}
