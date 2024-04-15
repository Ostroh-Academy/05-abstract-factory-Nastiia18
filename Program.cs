using System;

// Інтерфейс для двигуна
public interface IEngine
{
    void Start();
    void Stop();
}

// Конкретна реалізація бензинового двигуна
public class PetrolEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol engine started.");
    }

    public void Stop()
    {
        Console.WriteLine("Petrol engine stopped.");
    }
}

// Конкретна реалізація дизельного двигуна
public class DieselEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Diesel engine started.");
    }

    public void Stop()
    {
        Console.WriteLine("Diesel engine stopped.");
    }
}

// Інтерфейс для кузова
public interface IBody
{
    void Open();
    void Close();
}

// Конкретна реалізація кузова типу купе
public class CoupeBody : IBody
{
    public void Open()
    {
        Console.WriteLine("Coupe body opened.");
    }

    public void Close()
    {
        Console.WriteLine("Coupe body closed.");
    }
}

// Конкретна реалізація кузова типу седан
public class SedanBody : IBody
{
    public void Open()
    {
        Console.WriteLine("Sedan body opened.");
    }

    public void Close()
    {
        Console.WriteLine("Sedan body closed.");
    }
}

// Абстрактна фабрика для створення автомобілів
public interface ICarFactory
{
    IEngine CreateEngine();
    IBody CreateBody();
}

// Конкретна реалізація абстрактної фабрики для створення бензинових автомобілів
public class PetrolCarFactory : ICarFactory
{
    public IEngine CreateEngine()
    {
        return new PetrolEngine();
    }

    public IBody CreateBody()
    {
        return new CoupeBody();
    }
}

// Конкретна реалізація абстрактної фабрики для створення дизельних автомобілів
public class DieselCarFactory : ICarFactory
{
    public IEngine CreateEngine()
    {
        return new DieselEngine();
    }

    public IBody CreateBody()
    {
        return new SedanBody();
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        // Використовуємо фабрику для створення бензинового автомобіля
        ICarFactory petrolFactory = new PetrolCarFactory();
        BuildCar(petrolFactory);

        Console.WriteLine();

        // Використовуємо фабрику для створення дизельного автомобіля
        ICarFactory dieselFactory = new DieselCarFactory();
        BuildCar(dieselFactory);
    }

    static void BuildCar(ICarFactory factory)
    {
        Console.WriteLine("Building car...");
        IEngine engine = factory.CreateEngine();
        IBody body = factory.CreateBody();

        engine.Start();
        body.Open();
        body.Close();
        engine.Stop();

        Console.WriteLine("Car build complete.");
    }
}

