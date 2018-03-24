using System;

namespace Gdo
{
    public abstract class Optimizer
    {
        protected readonly double _lr;
        protected double x;

        protected Optimizer(double learningRate)
        {
            ValidateLearningRate(learningRate);
            _lr = learningRate;
        }

        protected double Rms(double val)
        {
            double sqrt = Math.Sqrt(val);
            if (sqrt == 0)
            {
                sqrt += double.Epsilon;
            }
            return sqrt;
        }

        public abstract double Compute(double dx);

        protected void ValidateLearningRate(double lr)
        {
            if(lr > 1 || lr <= 0)
            {
                throw new Exception(Messages.InvalidLearningRateMessage);
            }
        }

        protected void ValidatePeriod(int period)
        {
            if (period <= 1)
            {
                throw new Exception(Messages.InvalidPeriodMessage);
            }
        }
    }
}
