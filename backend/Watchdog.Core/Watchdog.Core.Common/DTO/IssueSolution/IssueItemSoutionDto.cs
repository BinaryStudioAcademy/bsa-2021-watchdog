namespace Watchdog.Core.Common.DTO.IssueSolution
{
    public class IssueItemSolutionDto
    {
        
        public bool IsAnswered { get; set; }
        
        public int ViewCount { get; set; }
        
        public int AnswerCount { get; set; }
        public int Score { get; set; }
        public string Link { get; set; }
    }
}
