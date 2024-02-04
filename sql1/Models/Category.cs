
namespace sql1.Models
{
    public class Category: BaseModel
    {
        public string Name { get; set; } = null!;
        public List<Product> Products { get; set; }
    }
}
