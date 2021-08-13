using System;

namespace Watchdog.Core.DAL.Entities
{
    [Flags]
    public enum PlatformTypes
    {
        Browser = 0b0001,
        Server = 0b0010,
        Mobile = 0b0100,
        Desktop = 0b1000
    }
}
