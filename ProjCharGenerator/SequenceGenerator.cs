using System;
using System.IO;
using System.Linq;

namespace ProjCharGenerator
{
    public class SequenceGenerator
    {
        private readonly string[] _baseCombination;
        private readonly int[] _weights;
        private readonly int _totalWeight;
        private readonly int[] _upperBounds;
        private readonly Random _rand;

        public SequenceGenerator(string[] baseCombination, int[] weights)
        {
            _baseCombination = baseCombination;
            _weights = weights;
            _rand = new Random();

            if (_baseCombination.Length != _weights.Length)
            {
                throw new InvalidDataException("Wrong input. Bounds are not equal.");
            }

            _upperBounds = new int[_baseCombination.Length];
            _totalWeight = _weights.Sum();
            InitializeBounds();
        }

        public string GetNextStr()
        {
            var value = _rand.Next(0, _totalWeight);

            for (var i = 0; i < _baseCombination.Length; i++)
            {
                if (value < _upperBounds[i])
                {
                    return _baseCombination[i];
                }
            }

            return "";
        }

        private void InitializeBounds()
        {
            for (int i = 0, upperBound = 0; i < _upperBounds.Length; i++)
            {
                upperBound += _weights[i];
                _upperBounds[i] = upperBound;
            }
        }
    }
}
