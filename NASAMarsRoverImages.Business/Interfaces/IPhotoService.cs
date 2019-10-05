using NASAMarsRoverImages.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NASAMarsRoverImages.Business.Interfaces
{
    public interface IPhotoService
    {
        /// <summary>
        /// Gets the Json data from NASA API
        /// </summary>
        /// <param name="date">earth_date</param>
        /// <returns></returns>
        Task<IEnumerable<Photo>> GetJsonData(DateTime date);

        /// <summary>
        /// Randomly selects picture
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        Task<Photo> SelectPhoto(IEnumerable<Photo> photos);

        /// <summary>
        /// Saves the photo locally
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="localPath"></param>
        /// <returns></returns>
        Task SavePhoto(Photo photo, string localPath);
    };
}
