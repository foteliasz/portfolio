using System;

namespace Singleton
{
    interface ICounter
    {
        int Sum { get; }

        void Add(int value);
    }

    class GlobalCounter : ICounter
    {
        #region ICounter implementation

        public int Sum { get; private set; }

        public void Add(int value)
        {
            Sum += value;
        }

        #endregion

        #region Singleton

        private static ICounter _instance;

        private GlobalCounter() { }

        public static ICounter Instance => _instance ??= new GlobalCounter();

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var firstReference = GlobalCounter.Instance;
            var secondReference = GlobalCounter.Instance;
            var thirdReference = GlobalCounter.Instance;

            firstReference.Add(3);
            secondReference.Add(5);
            thirdReference.Add(10);

            var anotherInstance = GlobalCounter.Instance;
            Console.WriteLine($"The global sum equals: {anotherInstance.Sum}");
        }
    }
}
