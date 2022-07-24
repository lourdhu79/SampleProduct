using System.IO;

namespace ProductVersion    
{
    public class FileProductSource : IProductSource
    {
        public string GetProductFromSource()
        {
            return File.ReadAllText("product.json");
        }
    }
}
