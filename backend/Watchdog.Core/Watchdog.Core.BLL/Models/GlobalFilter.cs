using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Core.BLL.Models
{
    public class GlobalFilter
    {
        public string Value { get; set; }
        public ICollection<string> Fields { get; set; }
    }
}
