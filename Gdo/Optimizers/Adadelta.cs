using System;

namespace Gdo.Optimizers
{
    public class Adadelta : Optimizer
    {
        private readonly double _period;
        private double ema1;
        private double ema2;

        public Adadelta(int period, double learningRate) : base(learningRate)
        {
            ValidatePeriod(period);
            _period = 1 - 1.00 / _period;
        }

        public override double Compute(double dx)
        {
            ema1 = _period * ema1 + (1 - _period) * Math.Pow(dx, 2);
            var rms_grad = Rms(ema1);

            ema2 = _period * ema2 + (1 - _period) * Math.Pow(rms_grad, 2);
            var rms_teta = Rms(ema2);

            return x -= (rms_teta / rms_grad) * dx;
        }
    }
}
