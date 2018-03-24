using System;

namespace Gdo.Optimizers
{
    public class Adagrad : Optimizer
    {
        private double _cache;

        public Adagrad(double learningRate) : base(learningRate) {}

        public override double Compute(double dx)
        {
            _cache += Math.Pow(dx, 2);
            return x -= _lr * (dx / Rms(_cache));
        }
    }
}
