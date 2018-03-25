using System;

namespace Gdo.Optimizers
{
    public class Adadelta : Optimizer
    {
        private readonly double _period;
        private double ema1;
        private double ema2;

        public Adadelta(double learningRate, int period) : base(learningRate)
        {
            ValidatePeriod(period);
            _period = 1 - 1.00 / period;
            ema1 = 1;
            ema2 = 1;
        }

        public override void Update(double dx)
        {
            ema1 = _period * ema1 + (1 - _period) * Math.Pow(dx, 2);
            var delta = (Rms(ema2) / Rms(ema1)) * dx;
            ema2 = _period * ema2 + (1 - _period) * Math.Pow(delta, 2);

            Value -= delta;
        }
    }
}
