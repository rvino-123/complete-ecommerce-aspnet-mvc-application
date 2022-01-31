using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class MovieTime
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }

        // Relationships
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get;}
    }
}
