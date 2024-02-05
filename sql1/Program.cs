using Microsoft.EntityFrameworkCore;
using sql1.Models;
using System.Xml.Linq;

ShopDbContext shopDbContext = new ShopDbContext();

ShowMenu();
void ShowMenu()
{
    Console.WriteLine("1.Create");
    Console.WriteLine("2.GetAll");
    Console.WriteLine("3.GetById");
    Console.WriteLine("4.Update");
    Console.WriteLine("5.Remove");

    Console.WriteLine("6.ProductGetAll");
    Console.WriteLine("0.Close");
}
int request = int.Parse(Console.ReadLine());


while (request != 0)
{
    switch(request)
    {
        case 1:
            Create();
            break;
        case 2:
            GetAll();
            break;
        case 3:
            GetById();
            break;
        case 4:
            Update();
            break;
        case 5:
            Remove();
            break;

        default:
            Console.WriteLine("Duzgun deyer daxil et!");
            break;
    }

    ShowMenu();
    request = int.Parse(Console.ReadLine());

}

void Create()
{
    Console.WriteLine("Add Name");
    string? Name = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("Name can not be empaty");
        Name = Console.ReadLine();
    }

    Category category = new Category
    {
        Name = Name,
        CreatedAt = DateTime.UtcNow.AddHours(4),
    };

    shopDbContext.Add(category);

    int result = shopDbContext.SaveChanges();

    Console.WriteLine(result > 0 ? "Success" : "Something went wrong");
}

void GetAll()
{
    IQueryable<Category> queries = shopDbContext.Categories.Where(x => !x.IsDeleted).AsNoTracking();

    List<Category> categories = queries.Select(x => new Category { Name = x.Name }).ToList();

    foreach (var category in categories)
    {
        Console.WriteLine(category.Name);
    }
}

void GetById()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);

    Category? category = shopDbContext.Categories.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found category");
        return;
    }

    Console.WriteLine(category.Name);
}

void Update()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);

    Category? category = shopDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found category");
        return;
    }

    Console.WriteLine("Add new Name");
    string Name = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(Name))
    {
        Console.WriteLine("Name can not be empaty");
        Name = Console.ReadLine();
    }

    category.Name = Name;
    category.UpdatedAt = DateTime.UtcNow.AddHours(4);
    shopDbContext.SaveChanges();
}

void Remove()
{
    Console.WriteLine("Add Id");
    int.TryParse(Console.ReadLine(), out int id);

    Category? category = shopDbContext.Categories.Where(x => x.Id == id).FirstOrDefault();

    if (category == null)
    {
        Console.WriteLine("Not found category");
        return;
    }

    category.IsDeleted = true;
    shopDbContext.SaveChanges();
}

