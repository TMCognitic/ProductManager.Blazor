namespace CommandQuerySeparation.Queries
{
    public interface IQueryHandlerAsync<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Task<TResult> Execute(TQuery query);
    }
}
