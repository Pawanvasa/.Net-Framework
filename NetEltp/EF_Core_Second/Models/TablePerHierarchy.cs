using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace EF_Core_Second.Models
{
    public abstract class ProductionUnit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Required]
        public int ReleaseYear { get; set; }
    }
    public class Movies : ProductionUnit
    {
        [Required]
        public string Category { get; set; } = String.Empty;
        [Required]
        public int PlayDuration { get; set; }
        [Required]
        public double BoxOfficeCollection { get; set; }
    }

    public class WebSeries : ProductionUnit
    {
        [Required]
        public int Seasons { get; set; }
        [Required]
        public int EpisodPerSeason { get; set; }
    }
}
