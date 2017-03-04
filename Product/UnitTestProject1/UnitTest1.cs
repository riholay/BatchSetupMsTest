using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static ConcurrentQueue<int> _pool;

        public TestContext TestContext { get; set; }

        public UnitTest1()
        {
            _pool = new ConcurrentQueue<int>();
            // test init
            for (int i = 0; i < 1000; i++) { _pool.Enqueue(i); }
        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            var tasks = _pool.Select(async i => { await LoadUserCollection(i); });

            var timer = Stopwatch.StartNew();
            Task.WaitAll(tasks.ToArray());
            timer.Stop();

            Debug.WriteLine($"Ellpased:{timer.ElapsedMilliseconds}ms.");
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        private static Task LoadUserCollection(int user)
        {
            return Task.Run(() =>
            {
                Debug.WriteLine($"Begin Loading{user}.");
                var delay = new Random(DateTime.Now.Millisecond).Next(2000);
                Debug.WriteLine($"MockLatency:{delay}");
                Task.Delay(delay);
                Debug.WriteLine($"End Loading{user}.");
            });
        }
    }
}
