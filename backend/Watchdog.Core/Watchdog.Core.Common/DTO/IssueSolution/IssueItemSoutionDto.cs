using System.Collections.Generic;

namespace Watchdog.Core.Common.DTO.IssueSolution
{
    public class IssueItemSolutionDto
    {
        public string Body { get; set; }
        public ICollection<IssueAnswerDto> Answers { get; set; }
    }
}
