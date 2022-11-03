using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Exercices07.Models.Entities
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime FoundingDate { get; set; }
        public int SportId { get; set; }
        public virtual IList<Player>? Players { get; set; }
        public virtual Sport? Sport { get; set; }
        public virtual IList<Trophy>? Trophies { get; set; }
    }
}
