using System;

namespace Gdo
{
    public abstract class Optimizer
    {
        internal protected readonly double _lr;
        public double Value;

        internal Optimizer(double learningRate)
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

        public abstract void Update(double dx);

        internal void SetValue(double value)
        {
            Value = value;
        }

        internal protected void ValidateLearningRate(double lr)
        {
            if(lr > 1 || lr <= 0)
            {
                throw new Exception(Messages.InvalidLearningRateMessage);
            }
        }

        internal protected void ValidatePeriod(int period)
        {
            if (period <= 1)
            {
                throw new Exception(Messages.InvalidPeriodMessage);
            }
        }
    }
}
