using System;

namespace Gdo
{
    public abstract class Optimizer : ICloneable
    {
        internal readonly double _lr;
        public double Value;

        internal Optimizer(double learningRate)
        {
            ValidateLearningRate(learningRate);
            _lr = learningRate;
        }

        internal double Rms(double val)
        {
            double sqrt = Math.Sqrt(val);
            if (sqrt == 0)
            {
                sqrt += double.Epsilon;
            }
            return sqrt;
        }

        public abstract void Update(double dx);

        public void SetValue(double value)
        {
            Value = value;
        }

        internal void ValidateLearningRate(double lr)
        {
            if(lr > 1 || lr <= 0)
            {
                throw new Exception(Messages.InvalidLearningRateMessage);
            }
        }

        internal void ValidatePeriod(int period)
        {
            if (period <= 1)
            {
                throw new Exception(Messages.InvalidPeriodMessage);
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
