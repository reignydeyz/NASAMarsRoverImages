using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASAMarsRoverImages.Business.Dtos
{
    public class Photo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("earth_date")]
        public DateTime EarthDate { get; set; }

        [JsonProperty("img_src")]
        public string ImageSource { get; set; }
    }
}
