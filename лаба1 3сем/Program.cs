using System;
using System.Collections.Generic;

namespace NewProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<MobileDevice> devices = new List<MobileDevice>
            {
                new Smartphone { Brand = "Samsung", Model = "Galaxy S24", Price = 800, RAM = 8, Battery = 5000 }, // Создаем вариации
                new Smartphone { Brand = "Apple", Model = "iPhone 15", Price = 1000, RAM = 6, Battery = 3877 },
                new EBook { Brand = "Amazon", Model = "Kindle Paperwhite", Price = 140, ScreenInch = 6.8, Storage = 16, BackLight = true },
                new EBook { Brand = "PocketBook", Model = "InkPad", Price = 219, ScreenInch = 7.8, Storage = 32, BackLight = true }
            };

            foreach (var device in devices) //вывод всех данных
            {
                Console.WriteLine(device.GetInfo());
            }

            Console.WriteLine("Изменение цены первого телефона");
            Smartphone phone1 = (Smartphone)devices[0];
            phone1.Price = 700;
            phone1.RAM = 12;
            Console.WriteLine(phone1.GetInfo());

            Console.WriteLine("Установка некорректной цены");
            phone1.Price = -958;
            Console.WriteLine(phone1.GetInfo());

            Console.WriteLine("\nОбъекты по умолчанию");
            Smartphone phone3 = new Smartphone();
            Console.WriteLine(phone3.GetInfo());

            EBook ebook3 = new EBook();
            Console.WriteLine(ebook3.GetInfo());

            Console.WriteLine("\nИзменение ebook1");
            EBook ebook1 = (EBook)devices[2];
            ebook1.Price = 119;
            ebook1.BackLight = false;
            Console.WriteLine(ebook1.GetInfo());

            Console.WriteLine("\nДемонстрация доступа через свойства");
            Smartphone phone2 = (Smartphone)devices[1];
            Console.WriteLine($"phone2.Brand = {phone2.Brand}");
            Console.WriteLine($"phone2.Price = {phone2.Price}");

            EBook ebook2 = (EBook)devices[3];
            Console.WriteLine($"ebook2.ScreenInch = {ebook2.ScreenInch}");
            Console.WriteLine($"ebook2.Storage = {ebook2.Storage}");
        }
    }

    public class MobileDevice
        {
            private int price;
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Price
            {
                get => price;
                set
                {
                    if (value > 0)
                        price = value;
                    else
                        Console.WriteLine("[Ошибка] Цена должна быть больше 0!");
                }
            }
            public MobileDevice()
                {
                    Brand = "Unknown";
                    Model = "Unknown";
                }

            public virtual string GetInfo()
            {
                return $"Brand: {Brand}, Model: {Model}, Price: {Price}";
            }
        }

    public class Smartphone : MobileDevice
    {
        private int ram;
        private int battery;
        public int RAM
        {
            get => ram;
            set
            {
                if (value > 0)
                    ram = value;
                else
                    Console.WriteLine("[Ошибка] RAM должна быть больше 0!");
            }
        }
        public int Battery
        {
            get => battery;
            set
            {
                if (value > 0)
                    battery = value;
                else
                    Console.WriteLine("[Ошибка] Ёмкость аккумулятора должна быть больше 0!");
            }
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", RAM: {RAM} GB, Battery: {Battery} mAh";
        }
    }

    public class EBook : MobileDevice
    {
        private int storage;
        public double ScreenInch { get; set; }
        public bool BackLight { get; set; }
        public int Storage
        {
            get => storage;
            set
            {
                if (value > 0)
                    storage = value;
                else
                    Console.WriteLine("[Ошибка] Объём памяти должен быть больше 0!");
            }
        }
        public override string GetInfo()
        {
            return base.GetInfo() + $", ScreenInch: {ScreenInch}, Storage: {Storage} GB, Backlight: {BackLight}";
        }
    }
}

