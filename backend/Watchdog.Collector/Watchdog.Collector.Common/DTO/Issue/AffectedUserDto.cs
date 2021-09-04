using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Collector.Common.DTO.Issue
{
    public class AffectedUserDto
    {
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
