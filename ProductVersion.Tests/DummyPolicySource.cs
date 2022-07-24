namespace ProductVersion.Tests
{
    public class DummyProductSource : IProductSource
    {
        public string ProductString { get; set; } = "";

        public string GetProductFromSource()
        {
            return ProductString;
        }
    }
}