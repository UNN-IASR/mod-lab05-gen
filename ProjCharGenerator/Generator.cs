using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCharGenerator
{
    public abstract class Generator
    {
        protected string[] _items;
        protected int[] _weights;

        int[] rouletWeights;
        int sumWeight;

        Random rd;

        public Generator(Random rd = null)
        {
            this.rd = rd is null ? new Random() : rd;

            InitilizeWeightAndItems();

            if (_items.Length != _weights.Length)
                throw new Exception($"Length items {_items.Length} and " +
                    $"length weights {_weights.Length} must be equels");

            CreateRouletWeights();
        }

        protected abstract void InitilizeWeightAndItems();

        void CreateRouletWeights()
        {
            sumWeight = 0;

            rouletWeights = new int[_weights.Length];
            rouletWeights[0] = _weights[0];

            for (int i = 1; i < _weights.Length; i++)
                rouletWeights[i] = rouletWeights[i - 1] + _weights[i];

            for (int i = 0; i < _weights.Length; i++)
                sumWeight += _weights[i];
        }

        public string GetText(int lenghtText = 100)
        {
            string ans = "";

            for (int i = 0; i < lenghtText; i++)
                ans += GetValue() + " ";

            return ans;
        }

        private string GetValue()
        {
            int randomInt = rd.Next(0, sumWeight);

            for (int j = 0; j < rouletWeights.Length; j++)
            {
                if (randomInt < rouletWeights[j])
                    return _items[j];
            }

            return " ";
        }
    }
}