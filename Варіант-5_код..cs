using System;

// Інтерфейс для меблів
public interface IFurniture
{
    void Assemble();
}

// Інтерфейс для декоративних елементів
public interface IDecoration
{
    void Install();
}

// Конкретна реалізація меблів у стилі модерн
public class ModernFurniture : IFurniture
{
    public void Assemble()
    {
        Console.WriteLine("Assembling modern furniture.");
    }
}

// Конкретна реалізація меблів у стилі класика
public class ClassicFurniture : IFurniture
{
    public void Assemble()
    {
        Console.WriteLine("Assembling classic furniture.");
    }
}

// Конкретна реалізація декоративних елементів у стилі модерн
public class ModernDecoration : IDecoration
{
    public void Install()
    {
        Console.WriteLine("Installing modern decoration.");
    }
}

// Конкретна реалізація декоративних елементів у стилі класика
public class ClassicDecoration : IDecoration
{
    public void Install()
    {
        Console.WriteLine("Installing classic decoration.");
    }
}

// Абстрактна фабрика для створення інтер'єру
public interface IInteriorFactory
{
    IFurniture CreateFurniture();
    IDecoration CreateDecoration();
}

// Конкретна реалізація абстрактної фабрики для створення інтер'єру у стилі модерн
public class ModernInteriorFactory : IInteriorFactory
{
    public IFurniture CreateFurniture()
    {
        return new ModernFurniture();
    }

    public IDecoration CreateDecoration()
    {
        return new ModernDecoration();
    }
}

// Конкретна реалізація абстрактної фабрики для створення інтер'єру у стилі класика
public class ClassicInteriorFactory : IInteriorFactory
{
    public IFurniture CreateFurniture()
    {
        return new ClassicFurniture();
    }

    public IDecoration CreateDecoration()
    {
        return new ClassicDecoration();
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        // Використовуємо фабрику для створення інтер'єру у стилі модерн
        IInteriorFactory modernFactory = new ModernInteriorFactory();
        BuildInterior(modernFactory);

        Console.WriteLine();

        // Використовуємо фабрику для створення інтер'єру у стилі класика
        IInteriorFactory classicFactory = new ClassicInteriorFactory();
        BuildInterior(classicFactory);
    }

    static void BuildInterior(IInteriorFactory factory)
    {
        Console.WriteLine("Building interior...");
        IFurniture furniture = factory.CreateFurniture();
        IDecoration decoration = factory.CreateDecoration();

        furniture.Assemble();
        decoration.Install();

        Console.WriteLine("Interior build complete.");
    }
}
