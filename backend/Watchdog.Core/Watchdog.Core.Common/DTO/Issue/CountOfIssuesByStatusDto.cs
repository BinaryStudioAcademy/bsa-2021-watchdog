namespace Watchdog.Core.Common.DTO.Issue
{
    public class CountOfIssuesByStatusDto
    {
        public int ActiveCount { get; set; }
        public int ResolvedCount { get; set; }
        public int IgnoredCount { get; set; }
    }
}