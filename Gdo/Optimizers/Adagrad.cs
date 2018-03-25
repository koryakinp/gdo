using System;

namespace Gdo.Optimizers
{
    public class Adagrad : Optimizer
    {
        private double _cache;

        public Adagrad(double learningRate) : base(learningRate) {}

        public override void Update(double dx)
        {
            _cache += Math.Pow(dx, 2);
            Value -= _lr * (dx / Rms(_cache));
        }
    }
}
