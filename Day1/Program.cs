using System;
using System.Collections.Generic;
using System.IO;

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Product(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Name}: {Quantity}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string path = "products.txt";
        List<Product> products = LoadProducts(path);

        Console.WriteLine("Выберите действие:");
        Console.WriteLine("a) Показать список продуктов");
        Console.WriteLine("b) Добавить новый продукт");
        Console.WriteLine("c) Продать продукт");
        char choice = Console.ReadKey().KeyChar;
        Console.WriteLine();

        switch (choice)
        {
            case 'a':
                ShowProducts(products);
                break;
            case 'b':
                AddProduct(products, path);
                break;
            case 'c':
                SellProduct(products, path);
                break;
            default:
                Console.WriteLine("Неизвестное действие");
                break;
        }
    }

    static List<Product> LoadProducts(string path)
    {
        List<Product> products = new List<Product>();
        if (File.Exists(path))
        {
            foreach (string line in File.ReadAllLines(path))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int quantity))
                {
                    Product product = new Product(parts[0], quantity);
                    products.Add(product);
                }
            }
        }
        return products;
    }
    
    static void ShowProducts(List<Product> products)
    {
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }

    static void AddProduct(List<Product> products, string path)
    {
        Console.Write("Введите имя продукта: ");
        string name = Console.ReadLine();
        Console.Write("Введите количество: ");
        if (int.TryParse(Console.ReadLine(), out int quantity))
        {
            bool found = false;
            foreach (Product product in products)
            {
                if (product.Name == name)
                {
                    product.Quantity += quantity;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Product product = new Product(name, quantity);
                products.Add(product);
            }
            SaveProducts(products, path);
            Console.WriteLine("Продукт добавлен");
        }
        else
        {
            Console.WriteLine("Некорректное количество");
        }
    }

    static void SellProduct(List<Product> products, string path)
    {
        Console.Write("Введите имя продукта: ");
        string name = Console.ReadLine();
        Console.Write("Введите количество: ");
        if (int.TryParse(Console.ReadLine(), out int quantity))
        {
            bool found = false;
            foreach (Product product in products)
            {
                if (product.Name == name)
                {
                    if (product.Quantity >= quantity)
                    {
                        product.Quantity -= quantity;
                        SaveProducts(products, path);
                        Console.WriteLine("Продукт продан");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно продуктов на складе");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Продукт не найден");
            }
        }
        else
        {
            Console.WriteLine("Некорректное количество");
        }
    }

    static void SaveProducts(List<Product> products, string path)
    {
        using (StreamWriter writer = new StreamWriter(path))
        {
            foreach (Product product in products)
            {
                writer.WriteLine($"{product.Name}:{product.Quantity}");
                
            }
        }
    }
    
}

