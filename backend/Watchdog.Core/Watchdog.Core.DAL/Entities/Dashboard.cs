using System.Collections.Generic;
using Watchdog.Core.DAL.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Watchdog.Core.DAL.Entities
{
    public class Dashboard : AuditEntity<int>
    {
        public Dashboard()
        {
            Tiles = new List<Tile>();
        }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "Name should be minimum 3 characters and a maximum of 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]*$")]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public User User { get; set; }

        public string Icon { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }

        public ICollection<Tile> Tiles { get; set; }
    }
}
