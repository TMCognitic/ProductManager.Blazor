namespace CommandQuerySeparation.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        TResult Execute(TQuery query);
    }
}
