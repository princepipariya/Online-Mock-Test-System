using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockTest.Models
{
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Score_Id { get; set; }
        public string Username { get; set; }
        public string Subject { get; set; }
        public string Difficulty { get; set; }
        public int Mark { get; set; }
    }
}
