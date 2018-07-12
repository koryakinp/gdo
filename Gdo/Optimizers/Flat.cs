using System;
using System.Collections.Generic;
using System.Text;

namespace Gdo.Optimizers
{
    public class Flat : Optimizer
    {
        public Flat(double learningRate) : base(learningRate) {}

        public override void Update(double dx)
        {
            Value -= dx * _lr;
        }
    }
}
