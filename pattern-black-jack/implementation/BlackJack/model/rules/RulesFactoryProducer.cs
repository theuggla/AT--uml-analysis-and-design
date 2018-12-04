namespace BlackJack.model.rules
{
    class RulesFactoryProducer 
    {
        public enum RuleType
        {
            DealerFavoured,
            PlayerFavoured,
            Mix
        }

        public static AbstractRulesFactory GetFactory(RuleType ruleType)
        {
            switch (ruleType)
            {
                case RuleType.DealerFavoured:
                    return new DealerFavouredFactory();
                case RuleType.PlayerFavoured:
                    return new PlayerFavouredFactory();
                case RuleType.Mix:
                    return new MixAndMatchFactory();
                default:
                    return null;
            }
        }
    }
}