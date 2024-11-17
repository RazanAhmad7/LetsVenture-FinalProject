using System.ComponentModel.DataAnnotations.Schema;

namespace LetsVen.Models
{
    public class AdventureImages
    {

        public int Id { get; set; }
        public string Path { get; set; }


        // Relationships
        public int AdventureId { get; set; }

        [ForeignKey("AdventureId")]
        public Adventure Adventure { get; set; }
    }
}
