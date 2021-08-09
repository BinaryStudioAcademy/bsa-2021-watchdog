using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface IImageUpload
    {
        Task<string> UploadAsync(string imgUri);
        Task<string> UploadAsync(byte[] byteArray);
    }
}
