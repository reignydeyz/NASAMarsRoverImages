using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NASAMarsRoverImages.Business.Dtos
{
    public class NASA
    {
        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
