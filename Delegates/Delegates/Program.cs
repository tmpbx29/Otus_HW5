using Delegates;

// Пример поиска максимального элемента
var products = new List<Product>
    {
        new Product { Name = "Продукт1", Price = 10.5f },
        new Product { Name = "Продукт2", Price = 15.3f },
        new Product { Name = "Продукт3", Price = 8.7f },
        new Product { Name = "Продукт5", Price = 8.6f },
        new Product { Name = "Продукт25", Price = 999.9f }
    };

var maxProduct = products.GetMax(p => p.Price);
Console.WriteLine($"Максимальная цена продукта: {maxProduct?.Name ?? "не найдено"}, цена: {maxProduct?.Price} ");

// Пример поиска файлов
var searcher = new FileSearcher();
searcher.FileFound += OnFileFound;

Console.WriteLine("Укажите директорию для поиска:");
var directory = Console.ReadLine();

Console.WriteLine($"Начинаем поиск файлов в директории: {directory}");
searcher.Search(directory);
Console.WriteLine("Поиск завершен.");

static void OnFileFound(object sender, FileArgs e)
{
    Console.WriteLine($"Найден файл: {e.FileName}");
    
    if (e.FileName.ToLower().Contains("stop"))
    {
        e.Cancel = true;
        Console.WriteLine("Найден файл остановки поиска...");
    }
} 