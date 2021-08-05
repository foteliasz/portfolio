using System;

namespace AbstractFactory
{

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
}
