using Gdo.Optimizers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Gdo.Tests
{
    [TestClass]
    public class OptimizerTests
    {
        private readonly Random _rnd;

        public OptimizerTests()
        {
            _rnd = new Random();
        }

        private int GutRandomX()
        {
            return (int)Math.Ceiling(_rnd.NextDouble() * 100);
        }

        [TestMethod]
        public void TestFlat()
        {
            Optimize(new Flat(0.0001), new Flat(0.0001), 2, 30, 100000, 0.1);
        }

        [TestMethod]
        public void TestAdam()
        {
            Optimize(new Adam(0.01, 100, 1000), new Adam(0.01, 100, 1000), 2, 30, 20000, 0.1);
        }

        [TestMethod]
        public void TestAdagrad()
        {
            Optimize(new Adagrad(1), new Adagrad(1), 2, 30, 100000, 0.1);
        }

        [TestMethod]
        public void TestRMSprop()
        {
            Optimize(new RMSprop(0.01, 20), new RMSprop(0.01, 20), 2, 30, 10000, 0.1);
        }

        [TestMethod]
        public void TestAdadelta()
        {
            Optimize(new Adadelta(0.1, 25), new Adadelta(0.1, 25), 2, 30, 10000, 0.1);
        }

        private void Optimize(Optimizer opt_a, Optimizer opt_b, int targetA, int targetB, int epochs, double delta)
        {
            var optimizer = new LinearOptimizer(opt_a, opt_b, 2, 30);

            for (int i = 0; i < epochs; i++)
            {
                int x = GutRandomX();
                optimizer.Optimize(x);
            }

            Assert.AreEqual(optimizer.A, optimizer.a, optimizer.A * delta);
            Assert.AreEqual(optimizer.B, optimizer.b, optimizer.B * delta);
        }
    }
}
