using System.Collections.Generic;

namespace Rules
{
    public sealed class RulesResultBase<TEntity>
    {
        public RulesResultBase(TEntity entity, List<IRules<TEntity>> rules)
        {
            Entity = entity;
            Rules = rules;
        }

        public TEntity Entity { get; private set; }
        public List<IRules<TEntity>> Rules { get; private set; }
    }
}
