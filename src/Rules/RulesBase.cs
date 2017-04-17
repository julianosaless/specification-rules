using System.Collections.Generic;
using System.Linq;

namespace Rules
{
    public abstract class RulesBase<TEntity, TRulesResult>
    {
        protected abstract List<IRules<TEntity>> Rules { get; }

        public virtual List<TRulesResult> ApplyRules(List<TEntity> entites)
        {
            return entites
                     .Select(entity => new RulesResultBase<TEntity>(entity, ProcessRules(entity))).Cast<TRulesResult>().ToList();
        }

        protected virtual List<IRules<TEntity>> ProcessRules(TEntity entity)
        {
            var rules = new List<IRules<TEntity>>();
            for (var positionOfRule = 0; positionOfRule < Rules.Count; positionOfRule++)
            {
                var rule = Rules[positionOfRule];
                rule.Validate(entity);
                rules.Add(rule);

                if (rule.StatusOfValidation == StatusOfValidation.Error)
                    positionOfRule = Rules.Count;
            }
            return rules;
        }
    }
}
