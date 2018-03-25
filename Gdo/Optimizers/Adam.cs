﻿using System;

namespace Gdo.Optimizers
{
    public class Adam : Optimizer
    {
        private readonly double beta1;
        private readonly double beta2;
        private double m;
        private double v;


        public Adam(double learningRate, int period1, int period2) : base(learningRate)
        {
            ValidatePeriod(period1);
            ValidatePeriod(period2);

            beta1 = 1 - 1.00 / period1;
            beta2 = 1 - 1.00 / period2;
        }

        public override void Update(double dx)
        {
            m = beta1 * m + (1 - beta1) * dx;
            v = beta2 * v + (1 - beta2) * Math.Pow(dx, 2);
            Value -= _lr * (m / Rms(v));
        }
    }
}
