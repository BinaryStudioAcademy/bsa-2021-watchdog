using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.Common.DTO.Platform
{
    public class PlatformDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }

        public IEnumerable<string> PlatformTypes { get; set; }
    }
}
