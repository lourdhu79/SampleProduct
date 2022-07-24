using Newtonsoft.Json;

namespace ProductVersion.Tests
{
    public class ProductEngineVersion
    {
        private ProductEngine _engine;
        private DummyLogger _logger;
        private DummyProductSource _productSource;
        private JsonProductSerializer _productSerializer;

        public ProductEngineVersion()
        {
            _logger = new DummyLogger();
            _productSource = new DummyProductSource();
            _productSerializer = new JsonProductSerializer();

            _engine = new ProductEngine(_logger,_productSource,_productSerializer);
        }

        [Fact]
        public void TestReleaseFeature()
        {
            var release = new Product
            {
                Type = ProductType.Feature,
                Name = "Product 1",
                Base = "1.0",
                Major = 1,
                Minor = 0
            };
            string json = JsonConvert.SerializeObject(release);
            File.WriteAllText(@"c:\temp\product.json", json);
            _productSource.ProductString = json;

            //var engine = new ProductEngine(string.Empty);
            _engine.VersionDetails();          

            Assert.Equal("1.0.2.0", _engine.VersionInfo);

        }
        [Fact]
        public void TestReleaseBugFix()
        {
            var release = new Product
            {
                Type = ProductType.BugFix,
                Name = "Product 1",
                Base = "1.0",
                Major = 2,
                Minor = 0
            };
            string json = JsonConvert.SerializeObject(release);
            File.WriteAllText(@"c:\temp\product.json", json);
            _productSource.ProductString = json;

            //var engine = new ProductEngine(string.Empty);
            _engine.VersionDetails();

            Assert.Equal("1.0.2.1", _engine.VersionInfo);
        }

        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var release = new Product
            {
                Type = ProductType.Feature,
                Name = "Product 1",
                Base = "1.0",
                Major = 2,
                Minor = 0
            };
            string json = JsonConvert.SerializeObject(release);
            File.WriteAllText(@"c:\temp\product.json", json);
            _productSource.ProductString = json;

            _engine.VersionDetails();
            var result = _engine.VersionInfo;

            Assert.Contains(_logger.LoggedMessages, m => m == "Start Versioing..");
            Assert.Contains(_logger.LoggedMessages, m => m == "Loading Product Info");
            Assert.Contains(_logger.LoggedMessages, m => m == "Feature version");
            Assert.Contains(_logger.LoggedMessages, m => m == "End Versioning.");           
        }
    }
}
