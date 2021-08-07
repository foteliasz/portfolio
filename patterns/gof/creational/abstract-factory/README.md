# Abstract Factory

An exemplary implementation of Abstarct Factory design pattern. [Wiki reference](https://en.wikipedia.org/wiki/Abstract_factory_pattern).

## Goal

The common goal of this pattern is to decouple creation of the class from its usage. Allows to replace all implementation of an abstraction in a single place.

## Problem it solves

Some real world examples:

* Allows to quickly replace your IRepository implementation from relational database to document database
* Allows to replace your logging library from one to another. For instance from [winston](https://www.npmjs.com/package/winston) to [log4js](https://www.npmjs.com/package/log4js)

## Code

```c#
    interface IProduct { string Name { get; } }

    class FooProduct: IProduct { public string Name => "Foo"; }

    class BarProduct : IProduct { public string Name => "Bar"; }

    interface IFactory { IProduct Create(); }

    class FooFactory: IFactory
    {
        public IProduct Create() { return new FooProduct(); }
    }

    class BarFactory : IFactory
    {
        public IProduct Create() { return new BarProduct(); }
    }

    class ProductShowcase
    {
        private readonly IFactory _factory;

        public ProductShowcase(IFactory factory)
        {
            _factory = factory;
        }

        public string Expose()
        {
            var product = _factory.Create();
            return $"Look at this new shiny {product.Name} product!";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var fooShowcase = new ProductShowcase(new FooFactory());
            var barShowcase = new ProductShowcase(new BarFactory());

            Console.WriteLine(fooShowcase.Expose());
            Console.WriteLine(barShowcase.Expose());
        }
    }
```

## Output

```shell
Look at this new shiny Foo product!
Look at this new shiny Bar product!
```
