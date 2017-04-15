using System.Collections.Generic;

namespace Rules
{
    public abstract class RulesBase<TEntity, TRulesResult>
    {
        protected abstract List<IRules<TEntity>> Rules { get; }

        public abstract List<TRulesResult> ApplyRules(List<TEntity> entites);

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
