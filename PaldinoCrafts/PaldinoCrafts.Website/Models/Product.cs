using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PaldinoCrafts.Website.Models
{
    public class Product
    {
        [JsonPropertyName("Id")]
        public String ID { get; set; }
        public String Maker { get; set; }
        
        [JsonPropertyName("img")]
        public String Image { get; set; }
        [JsonPropertyName("Url")]
        public String URL { get; set; }
        public String Title { get; set; }

        public String Description { get; set; }
        public int[] Ratings { get; set; }

        public int VoteCount { get { return Ratings == null ? 0 : Ratings.Length; } }
        public int AverageRating { get { return VoteCount == 0 ? 0 : Convert.ToInt32(Ratings.Sum() / Ratings.Length); } }

        /// <summary>
        /// Returns a JSON serialized string of this product.
        /// </summary>
        public override String ToString() => JsonSerializer.Serialize<Product>(this);
        
    }
}
