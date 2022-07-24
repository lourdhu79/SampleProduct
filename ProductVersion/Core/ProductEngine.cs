using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProductVersion
{
    /// <summary>
    /// The ProductEngine reads the product details from a file and produces a version info based on release type.
    /// </summary>
    public class ProductEngine  
    {
        private readonly ILogger _logger;
        private readonly IProductSource _productSource; 
        private readonly IProductSerializer _productSerializer;
        //private readonly RaterFactory _raterFactory;
        public string? VersionInfo { get; set; }

        public ProductEngine(ILogger logger,
            IProductSource productSource,
            IProductSerializer productSerializer)
        {
            _logger = logger;
            _productSource = productSource;
            _productSerializer = productSerializer;            
        }

        public void VersionDetails()    
        {   
           
            _logger.Log("Start Versioing..");
            _logger.Log("Loading Product Info");

            string releaseJson = _productSource.GetProductFromSource();

            var release = _productSerializer.GetProductFromJsonString(releaseJson);

            switch (release.Type)
            {
                case ProductType.Feature:
                    _logger.Log("Feature version");
                    if (release.Major >= 0) release.Major = release.Major + 1;
                    release.Minor = 0;
                    // can be cleaned wiht utility or helper method later
                    VersionInfo = release.Base + "." + release.Major.ToString() + "." + release.Minor.ToString();
                    //releaseDest.WritePolicyFromSource(release);
                    break;
                case ProductType.BugFix:
                    _logger.Log("BugFix version");
                    if (release.Minor >= 0) release.Minor = release.Minor + 1;
                    VersionInfo = release.Base + "." + release.Major.ToString() + "." + release.Minor.ToString();
                    //releaseDest.WritePolicyFromSource(release);
                    break;
                default:
                    _logger.Log("Unknown Release type");
                    break;

            }
            _logger.Log("End Versioning.");
            
        }
        
    }
}
