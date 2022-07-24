namespace ProductVersion    
{
    public class StringProductSource : IProductSource
    {
        public string ProductString { get; set; } = "";

        public string GetProductFromSource()
        {
            return ProductString;
        }
    }
}
