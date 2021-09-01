namespace Watchdog.Core.Common.DTO.Avatar
{
    public class AvatarDto
    {
        public int Id { get; set; } //id of user or organization whose avatar you want to change
        public string Base64 { get; set; }
    }
}
