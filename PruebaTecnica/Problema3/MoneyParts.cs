namespace PruebaTecnica.Problema3
{
    public class MoneyParts
    {
        private static readonly decimal[] Denominations = { 0.05m, 0.1m, 0.2m, 0.5m, 1m, 2m, 5m, 10m, 20m, 50m, 100m, 200m };

        public static List<List<decimal>> Build(string amount)
        {
            decimal targetAmount = decimal.Parse(amount);
            List<List<decimal>> result = new List<List<decimal>>();
            List<decimal> currentCombination = new List<decimal>();

            GenerateCombinations(result, currentCombination, targetAmount, 0);

            return result;
        }

        private static void GenerateCombinations(List<List<decimal>> result, List<decimal> currentCombination, decimal remainingAmount, int startIdx)
        {
            if (remainingAmount == 0)
            {
                result.Add(new List<decimal>(currentCombination));
                return;
            }

            for (int i = startIdx; i < Denominations.Length; i++)
            {
                decimal denomination = Denominations[i];

                if (remainingAmount >= denomination)
                {
                    currentCombination.Add(denomination);
                    GenerateCombinations(result, currentCombination, remainingAmount - denomination, i);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }


       
    }
}
