//Task 1
using System;

// Базовий клас, що представляє загальні атрибути та методи для всіх сутностей
public class Entity
{
    // Загальні поля для всіх сутностей
    public string Name { get; set; } // Назва сутності
    public DateTime CreatedAt { get; set; } // Дата створення сутності

    // Метод для відображення інформації про сутність
    public virtual void Show()
    {
        Console.WriteLine($"Name: {Name}"); // Вивід назви сутності
        Console.WriteLine($"Created At: {CreatedAt}"); // Вивід дати створення сутності
    }
}

// Клас деталі, який успадковує базовий клас Entity
public class Detail : Entity
{
    // Додаткові поля для деталі
    public string Material { get; set; } // Матеріал деталі
    public double Weight { get; set; } // Вага деталі

    // Перевизначення методу виведення для деталі
    public override void Show()
    {
        base.Show(); // Виклик методу Show базового класу
        Console.WriteLine($"Material: {Material}"); // Вивід матеріалу деталі
        Console.WriteLine($"Weight: {Weight} kg"); // Вивід ваги деталі
    }
}

// Клас механізму, який успадковує базовий клас Entity
public class Mechanism : Entity
{
    // Додаткові поля для механізму
    public int PartsCount { get; set; } // Кількість деталей у механізмі
    public string Function { get; set; } // Функція механізму

    // Перевизначення методу виведення для механізму
    public override void Show()
    {
        base.Show(); // Виклик методу Show базового класу
        Console.WriteLine($"Parts Count: {PartsCount}"); // Вивід кількості деталей у механізмі
        Console.WriteLine($"Function: {Function}"); // Вивід функції механізму
    }
}

// Клас виробу, який успадковує базовий клас Entity
public class Product : Entity
{
    // Додаткові поля для виробу
    public decimal Price { get; set; } // Ціна виробу
    public string Manufacturer { get; set; } // Виробник виробу

    // Перевизначення методу виведення для виробу
    public override void Show()
    {
        base.Show(); // Виклик методу Show базового класу
        Console.WriteLine($"Price: ${Price}"); // Вивід ціни виробу
        Console.WriteLine($"Manufacturer: {Manufacturer}"); // Вивід виробника виробу
    }
}

// Клас вузла, який успадковує базовий клас Entity
public class Node : Entity
{
    // Додаткові поля для вузла
    public string NodeType { get; set; } // Тип вузла
    public int Connections { get; set; } // Кількість з'єднань вузла

    // Перевизначення методу виведення для вузла
    public override void Show()
    {
        base.Show(); // Виклик методу Show базового класу
        Console.WriteLine($"Node Type: {NodeType}"); // Вивід типу вузла
        Console.WriteLine($"Connections: {Connections}"); // Вивід кількості з'єднань вузла
    }
}

// Головний клас програми
class Program
{
    // Головний метод програми
    static void Main(string[] args)
    {
        // Створення об'єктів різних класів
        Detail bolt = new Detail
        {
            Name = "Bolt",
            CreatedAt = DateTime.Now,
            Material = "Steel",
            Weight = 0.1
        };

        Mechanism engine = new Mechanism
        {
            Name = "Engine",
            CreatedAt = DateTime.Now,
            PartsCount = 100,
            Function = "Power Generation"
        };

        Product smartphone = new Product
        {
            Name = "Smartphone",
            CreatedAt = DateTime.Now,
            Price = 599.99m, // Використовую суфікс m для десяткових значень типу decimal
            Manufacturer = "Apple"
        };

        Node networkNode = new Node
        {
            Name = "Network Node",
            CreatedAt = DateTime.Now,
            NodeType = "Router",
            Connections = 8
        };

        // Виведення інформації про створені об'єкти
        Console.WriteLine("Details:");
        bolt.Show();

        Console.WriteLine("\nMechanisms:");
        engine.Show();

        Console.WriteLine("\nProducts:");
        smartphone.Show();

        Console.WriteLine("\nNodes:");
        networkNode.Show();
    }
}
//Task 2
using System;

// Інтерфейс Trans
interface ITrans
{
    // Метод для виводу інформації про транспортний засіб
    void DisplayInfo();
    // Метод для отримання вантажопідйомності транспортного засобу
    int GetPayloadCapacity();
}

// Базовий клас для транспортних засобів
class Vehicle : ITrans
{
    protected string brand; // Марка транспортного засобу
    protected string registrationNumber; // Номер реєстрації транспортного засобу
    protected int speed; // Швидкість транспортного засобу
    protected int payloadCapacity; // Вантажопідйомність транспортного засобу

    // Конструктор класу
    public Vehicle(string brand, string registrationNumber, int speed, int payloadCapacity)
    {
        this.brand = brand;
        this.registrationNumber = registrationNumber;
        this.speed = speed;
        this.payloadCapacity = payloadCapacity;
    }

    // Реалізація методу для виводу інформації про транспортний засіб
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Brand: {brand}\nRegistration Number: {registrationNumber}\nSpeed: {speed} km/h\nPayload Capacity: {payloadCapacity} kg");
    }

    // Реалізація методу для отримання вантажопідйомності транспортного засобу
    public int GetPayloadCapacity()
    {
        return payloadCapacity;
    }
}

// Похідний клас Легкова машина
class Car : Vehicle
{
    // Конструктор класу
    public Car(string brand, string registrationNumber, int speed, int payloadCapacity)
        : base(brand, registrationNumber, speed, payloadCapacity)
    {
    }
}

// Похідний клас Мотоцикл
class Motorcycle : Vehicle
{
    private bool hasSidecar; // Наявність коляски у мотоцикла

    // Конструктор класу
    public Motorcycle(string brand, string registrationNumber, int speed, int payloadCapacity, bool hasSidecar)
        : base(brand, registrationNumber, speed, hasSidecar ? payloadCapacity : 0)
    {
        this.hasSidecar = hasSidecar;
    }

    // Перевизначений метод для виводу інформації про транспортний засіб
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Has Sidecar: {hasSidecar}");
    }
}

// Похідний клас Вантажівка
class Truck : Vehicle
{
    private bool hasTrailer; // Наявність причепа у вантажівки

    // Конструктор класу
    public Truck(string brand, string registrationNumber, int speed, int payloadCapacity, bool hasTrailer)
        : base(brand, registrationNumber, speed, hasTrailer ? payloadCapacity * 2 : payloadCapacity)
    {
        this.hasTrailer = hasTrailer;
    }

    // Перевизначений метод для виводу інформації про транспортний засіб
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Has Trailer: {hasTrailer}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення бази з транспортними засобами
        Vehicle[] vehicles = new Vehicle[]
        {
            new Car("Toyota", "AB1234", 120, 500),
            new Motorcycle("Honda", "CD5678", 80, 200, true),
            new Truck("Volvo", "EF9012", 80, 2000, true),
            new Truck("Mercedes", "GH3456", 90, 1500, false)
        };

        // Вивід повної інформації на екран
        Console.WriteLine("All Vehicles:");
        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.DisplayInfo();
            Console.WriteLine();
        }

        // Пошук транспортних засобів за вимогами вантажопідйомності
        int requiredPayload = 1000;
        Console.WriteLine($"Vehicles with payload capacity >= {requiredPayload} kg:");
        foreach (Vehicle vehicle in vehicles)
        {
            if (vehicle.GetPayloadCapacity() >= requiredPayload)
            {
                vehicle.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}

//Task 3
using System;
using System.Collections;
using System.Collections.Generic;

// Базовий клас "Деталь"
class Detail
{
    // Властивості деталі: Назва, Матеріал, Вага
    public string Name { get; set; }
    public string Material { get; set; }
    public double Weight { get; set; }

    // Конструктор класу Detail
    public Detail(string name, string material, double weight)
    {
        Name = name;
        Material = material;
        Weight = weight;
    }

    // Метод відображення даних про деталь
    public virtual void Show()
    {
        Console.WriteLine($"Деталь: {Name}");
        Console.WriteLine($"Матеріал: {Material}");
        Console.WriteLine($"Вага: {Weight} кг");
    }
}

// Похідний клас "Механізм"
class Mechanism : Detail
{
    // Додаткова властивість механізму: Кількість деталей
    public int NumOfParts { get; set; }

    // Конструктор класу Mechanism
    public Mechanism(string name, string material, double weight, int numOfParts)
        : base(name, material, weight)
    {
        NumOfParts = numOfParts;
    }

    // Перевизначений метод відображення для механізмів
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Кількість деталей: {NumOfParts}");
    }
}

// Похідний клас "Виріб"
class Product : Detail
{
    // Додаткові властивості виробу: Виробник, Серійний номер
    public string Manufacturer { get; set; }
    public string SerialNumber { get; set; }

    // Конструктор класу Product
    public Product(string name, string material, double weight, string manufacturer, string serialNumber)
        : base(name, material, weight)
    {
        Manufacturer = manufacturer;
        SerialNumber = serialNumber;
    }

    // Перевизначений метод відображення для виробів
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Виробник: {Manufacturer}");
        Console.WriteLine($"Серійний номер: {SerialNumber}");
    }
}

// Похідний клас "Вузол"
class Node : Detail
{
    // Додаткові властивості вузла: Тип вузла, Напруга
    public string NodeType { get; set; }
    public double Voltage { get; set; }

    // Конструктор класу Node
    public Node(string name, string material, double weight, string nodeType, double voltage)
        : base(name, material, weight)
    {
        NodeType = nodeType;
        Voltage = voltage;
    }

    // Перевизначений метод відображення для вузлів
    public override void Show()
    {
        base.Show();
        Console.WriteLine($"Тип вузла: {NodeType}");
        Console.WriteLine($"Напруга: {Voltage} В");
    }
}

// Клас-контейнер для деталей
class DetailCollection : IEnumerable<Detail>
{
    private List<Detail> details = new List<Detail>(); // Список для зберігання деталей

    // Метод для додавання деталі до колекції
    public void Add(Detail detail)
    {
        details.Add(detail);
    }

    // Реалізація інтерфейсу IEnumerable<Detail>
    public IEnumerator<Detail> GetEnumerator()
    {
        return details.GetEnumerator();
    }

    // Реалізація інтерфейсу IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        DetailCollection collection = new DetailCollection(); // Створення колекції деталей

        // Створення об'єктів різних класів і додавання їх до колекції
        Mechanism mech = new Mechanism("Engine", "Steel", 150.5, 100);
        Product product = new Product("Smartphone", "Plastic", 0.2, "Apple", "SN12345");
        Node node = new Node("Electronic block", "Silicon", 0.5, "Computer", 5.0);
        collection.Add(mech);
        collection.Add(product);
        collection.Add(node);

        // Використання foreach для перегляду даних про всі деталі
        foreach (var detail in collection)
        {
            detail.Show();
            Console.WriteLine();
        }
    }
}


