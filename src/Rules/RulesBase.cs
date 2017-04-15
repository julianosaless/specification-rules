using System.Collections.Generic;

namespace Rules
{
    public abstract class RulesBase<TEntity>
    {
        protected abstract List<IRules<TEntity>> Rules { get; }

        public virtual List<RulesResultBase<TEntity>> ApplyRules(List<TEntity> entites)
        {
            var rulesResult = new List<RulesResultBase<TEntity>>();
            entites.ForEach(entity =>
            {
                var ruleResultBase = new RulesResultBase<TEntity>();
                ruleResultBase.Add(entity, ProcessRules(entity));
                rulesResult.Add(ruleResultBase);
            });
            return rulesResult;
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
