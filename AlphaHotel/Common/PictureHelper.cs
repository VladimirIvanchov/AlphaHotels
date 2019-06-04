using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Common
{
    public class PictureHelper : IPictureHelper
    {
        private readonly IHostingEnvironment appEnvironment;

        public PictureHelper(IHostingEnvironment appEnvironment)
        {
            this.appEnvironment = appEnvironment ?? throw new ArgumentNullException(nameof(appEnvironment));
        }

        public async Task<string> ConvertPicturePath(IFormFile picture)
        {
            var uploads = Path.Combine(this.appEnvironment.WebRootPath, "images/hotelPresentation/");
            string fileName = "";
            if (picture.Length > 0)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(picture.FileName);
                using (var stream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }
            }

            return fileName;
        }
    }
}
