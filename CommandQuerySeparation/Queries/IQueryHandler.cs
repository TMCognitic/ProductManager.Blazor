using CommandQuerySeparation.Results;

namespace CommandQuerySeparation.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQueryDefinition<TResult>
    {
        Result<TResult> Execute(TQuery query);
    }
}
