using System;

namespace ProductVersion    
{

    public class Product
    {
        public ProductType Type { get; set; }

        #region Product Info
        public string? Name { get; set; }
        // can be exteneded as per requriement
        #endregion

        #region Release
        public String? Base { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        #endregion
        
    }
}
