using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AlphaHotel.Common
{
    public interface IPictureHelper
    {
        Task<string> ConvertPicturePath(IFormFile picture);
    }
}
