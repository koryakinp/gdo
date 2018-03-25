using System;
using System.Collections.Generic;
using System.Text;

namespace Gdo.Tests
{
    internal class LinearOptimizer
    {
        private readonly Optimizer opt_a;
        private readonly Optimizer opt_b;
        public double a { get; private set; }
        public double b { get; private set; }

        public readonly int A;
        public readonly int B;

        public LinearOptimizer(Optimizer a, Optimizer b, int targetA, int targetB)
        {
            this.a = 1;
            this.b = 1;
            opt_a = a;
            opt_b = b;
            A = targetA;
            B = targetB;
        }

        public void Optimize(int x)
        {
            double target = CalculateTarget(x);
            double actual = CalculateActual(x);

            double deda = 2 * (actual - target) * x;
            double dedb = 2 * (actual - target);

            a = opt_a.Compute(deda);
            b = opt_b.Compute(dedb);
        }

        private double CalculateTarget(int x)
        {
            return A * x + B;
        }

        private double CalculateActual(int x)
        {
            return a * x + b;
        }
    }
}
