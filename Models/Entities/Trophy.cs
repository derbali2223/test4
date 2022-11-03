using Microsoft.EntityFrameworkCore.Metadata;
using System.Drawing;

namespace Exercices07.Models.Entities
{
    public class Trophy
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public int TeamId { get; set; }
        public virtual Team? Team { get; set; }
    }
}
