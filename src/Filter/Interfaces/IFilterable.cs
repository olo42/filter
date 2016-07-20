

namespace De.Apck.Tools.Filter
{
    public interface IFilterable<T>
    {
        T ToWhereClause(FilterDefinition filterDEfinition);
    }
}