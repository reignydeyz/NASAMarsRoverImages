using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NASAMarsRoverImages.Business.Interfaces;

namespace NASAMarsRoverImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IHostingEnvironment environment;
        private readonly IInputDatesValidator inputDatesValidator;
        private readonly IPhotoService photoService;

        public ServiceController(IHostingEnvironment hostingEnvironment, IInputDatesValidator inputDatesValidator, IPhotoService photoService)
        {
            this.environment = hostingEnvironment;
            this.inputDatesValidator = inputDatesValidator;
            this.photoService = photoService;
        }

        [Route("get")]
        public async Task<IActionResult> Get()
        {
            var txtPath = $@"{this.environment.WebRootPath}\dates.txt";
            var dates = this.inputDatesValidator.GetDatesFromSource(txtPath);
            var strs = new List<string>();

            // Clear image container directory
            if (Directory.Exists($@"{this.environment.WebRootPath}\nasa_imgs\"))
                Directory.Delete($@"{this.environment.WebRootPath}\nasa_imgs\", true);

            Directory.CreateDirectory($@"{this.environment.WebRootPath}\nasa_imgs\");

            foreach (var date in dates)
            {
                var res = await this.photoService.GetJsonData(date);
                var photo = res.First();
                var localPath = $@"{this.environment.WebRootPath}\nasa_imgs\{Path.GetFileName(photo.ImageSource)}";

                strs.Add($"http://{Request.Host}/nasa_imgs/{Path.GetFileName(photo.ImageSource)}");

                await this.photoService.SavePhoto(photo, localPath);
            }

            return Ok(strs);
        }
    }
}