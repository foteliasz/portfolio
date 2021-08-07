# Singleton

An exemplary implementation of Singleton design pattern. [Wiki reference](https://en.wikipedia.org/wiki/Singleton_pattern).

## Goal

The common goal of this pattern is to assure of existing only one instance of the class.

## Problem it solves

Some real world examples:

* Allows quick access to your database management connection object
* Allows quick access to global application configuration wrapper class
* In some cases it might be way to synchronize your multi-threading operations

## Code

```c#
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
```

## Output

```shell
The global sum equals: 18
```
