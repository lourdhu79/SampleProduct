namespace ProductVersion.Tests
{
    public class JsonSerilizerTest
    {
        [Fact]
        public void DefaultReleaseFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new JsonProductSerializer();

            var result = serializer.GetProductFromJsonString(inputJson);

            var product = new Product();
            AssertReleasesEqual(result, product);
        }

        [Fact]
        public void SampleProductFromValidJsonString()
        {
            var inputJson = @"{ ""Type"":1,""Name"":""Product2"",""Base"":""1.0"",""Major"":1,""Minor"":0}";
            var serializer = new JsonProductSerializer();

            var result = serializer.GetProductFromJsonString(inputJson);

            var policy = new Product { Type = ProductType.Feature, Name= "Product2", Base="1.0", Major=1, Minor=0 };
            AssertReleasesEqual(result, policy);
        }

        private static void AssertReleasesEqual(Product result, Product prod)
        {
            Assert.Equal(prod.Name, result.Name);
            Assert.Equal(prod.Base, result.Base);
            Assert.Equal(prod.Major, result.Major);
            Assert.Equal(prod.Minor, result.Minor);
        }
    }
}