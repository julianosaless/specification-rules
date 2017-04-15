using System;
using System.Collections.Generic;

namespace Rules
{
    public class RulesResultBase<TEntity> : IRulesResult<TEntity>
    {
        public  TEntity Entity { get; private set; }
        public List<IRules<TEntity>> Rules { get; private set; }

        public void Add(TEntity entity, List<IRules<TEntity>> rules)
        {
            Entity = entity;
            Rules = rules;
        }
    }
}
