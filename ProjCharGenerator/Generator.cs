namespace CharGenerator
{
    public abstract class Generator
    {
        protected string[] items;
        protected int[] weights;

        List<int> rouletteWeights = new List<int>();

        Random Rd { get; }

        public Generator(Random rd)
        {
            this.Rd = rd;
            CreateItemsAndWeights();
            CreateRouletteWeights();
        }

        void CreateRouletteWeights()
        {
            rouletteWeights.Add(weights[0]);
            for (int i = 1; i < weights.Length; i++)
                rouletteWeights.Add(rouletteWeights[i - 1] + weights[i]);
        }

        public string GetText(int lengthText = 100)
        {
            string ans = "";
            for (int i = 0; i < lengthText; i++)
                ans += GetValue() + " ";
            return ans;
        }

        private string GetValue()
        {
            int randomInt = Rd.Next(0, weights.Sum());

            for (int j = 0; j < rouletteWeights.Count; j++)
            {
                if (randomInt < rouletteWeights[j])
                    return items[j];
            }

            return " ";
        }

        protected abstract void CreateItemsAndWeights();
    }
}
