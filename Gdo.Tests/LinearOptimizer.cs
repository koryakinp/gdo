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

            opt_a.SetValue(10);
            opt_b.SetValue(5);
        }

        public void Optimize(int x)
        {
            double target = CalculateTarget(x);
            double actual = CalculateActual(x);

            double deda = 2 * (actual - target) * x;
            double dedb = 2 * (actual - target);

            opt_a.Update(deda);
            opt_b.Update(dedb);

            a = opt_a.Value;
            b = opt_b.Value;
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
