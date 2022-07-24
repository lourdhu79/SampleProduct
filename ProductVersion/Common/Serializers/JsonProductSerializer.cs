using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProductVersion    
{
    public class JsonProductSerializer : IProductSerializer
    {
        public Product GetProductFromJsonString(string jsonString)
        {
              return JsonConvert.DeserializeObject<Product>(jsonString, new StringEnumConverter())!;
        }
    }
}
