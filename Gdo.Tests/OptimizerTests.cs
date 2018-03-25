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
        public void TestAdam()
        {
            var opt_a = new Adam(0.01,100, 1000);
            var opt_b = new Adam(0.01, 100, 1000);

            var optimizer = new LinearOptimizer(opt_a, opt_b, 2, 30);

            for (int i = 0; i < 20000; i++)
            {
                int x = GutRandomX();
                optimizer.Optimize(x);
            }

            Assert.AreEqual(optimizer.A, optimizer.a, 0.1);
            Assert.AreEqual(optimizer.B, optimizer.b, 0.1);
        }

        [TestMethod]
        public void TestAdagrad()
        {
            var opt_a = new Adagrad(1);
            var opt_b = new Adagrad(1);

            var optimizer = new LinearOptimizer(opt_a, opt_b, 2, 30);

            for (int i = 0; i < 100000; i++)
            {
                int x = GutRandomX();
                optimizer.Optimize(x);
            }

            Assert.AreEqual(optimizer.A, optimizer.a, 0.1);
            Assert.AreEqual(optimizer.B, optimizer.b, 0.1);
        }

        [TestMethod]
        public void TestRMSprop()
        {
            var opt_a = new RMSprop(0.01, 20);
            var opt_b = new RMSprop(0.01, 20);

            var optimizer = new LinearOptimizer(opt_a, opt_b, 2, 30);

            for (int i = 0; i < 20000; i++)
            {
                int x = GutRandomX();
                optimizer.Optimize(x);
            }

            Assert.AreEqual(optimizer.A, optimizer.a, 0.1);
            Assert.AreEqual(optimizer.B, optimizer.b, 0.1);
        }

        [TestMethod]
        public void TestAdadelta()
        {
            var opt_a = new Adadelta(0.1, 25);
            var opt_b = new Adadelta(0.1, 25);

            var optimizer = new LinearOptimizer(opt_a, opt_b, 2, 30);

            for (int i = 0; i < 200000; i++)
            {
                int x = GutRandomX();
                optimizer.Optimize(x);
            }

            Assert.AreEqual(optimizer.A, optimizer.a, 0.1);
            Assert.AreEqual(optimizer.B, optimizer.b, 0.1);
        }
    }
}
