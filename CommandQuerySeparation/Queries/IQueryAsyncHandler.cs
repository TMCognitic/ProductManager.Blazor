namespace CommandQuerySeparation.Queries
{
    public interface IQueryAsyncHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Task<TResult> ExecuteAsync(TQuery query);
    }
}
