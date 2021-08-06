namespace Watchdog.Core.Common.DTO.Platform
{
    public class PlatformDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public PlatformTypesDto PlatformTypes { get; set; }
    }
}
