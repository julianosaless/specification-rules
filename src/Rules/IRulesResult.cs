using System.Collections.Generic;

namespace Rules
{
    public interface IRulesResult<TEntity>
    {
        void Add(TEntity entity, List<IRules<TEntity>> rules);
    }
}
