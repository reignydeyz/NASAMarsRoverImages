using Microsoft.Extensions.Options;
using NASAMarsRoverImages.Business.Dtos;
using NASAMarsRoverImages.Business.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverImages.Business
{
    public class PhotoService : IPhotoService
    {
        private readonly IOptions<NasaSettings> nasaOptions;
        private readonly IHttpClientFactory httpClientFactory;

        public PhotoService(IOptions<NasaSettings> nasaOptions, IHttpClientFactory httpClientFactory)
        {
            this.nasaOptions = nasaOptions;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Photo>> GetJsonData(DateTime date)
        {
            using (var httpClient = this.httpClientFactory.CreateClient("nasa"))
            {
                var dateStr = date.ToString("yyyy-M-d");
                var url = $"{nasaOptions.Value.ApiUrl}?earth_date={dateStr}&api_key={nasaOptions.Value.ApiKey}";

                var response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                    throw new ArgumentException("Not able to fetch data");
                else
                {
                    var str = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<NASA>(str);

                    return obj.Photos;
                }
            }
        }

        public async Task SavePhoto(Photo photo, string localPath)
        {
            var req = WebRequest.Create(photo.ImageSource);
            req.ContentType = "application/img";
            req.Method = "GET";

            using (var s = req.GetResponse().GetResponseStream())
            {
                using (var w = File.OpenWrite(localPath))
                {
                    await s.CopyToAsync(w);
                }
            }
        }

        public Task<Photo> SelectPhoto(IEnumerable<Photo> photos)
        {
            throw new NotImplementedException();
        }
    }
}
