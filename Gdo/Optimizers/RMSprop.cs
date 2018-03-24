using System;

namespace Gdo.Optimizers
{
    public class RMSprop : Optimizer
    {
        private readonly double _ma;
        private double _cache;

        public RMSprop(double learningRate, int period) : base(learningRate)
        {
            ValidatePeriod(period);
            _ma = 1 - 1.00 / period;
        }

        public override double Compute(double dx)
        {
            _cache = _cache == 0 
                ? _cache = Math.Pow(dx, 2) 
                : _cache = _ma * _cache + (1 - _ma) * Math.Pow(dx, 2);

            return x -= _lr * (dx / Rms(_cache));
        }
    }
}
