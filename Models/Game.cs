using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Models
{
   public class Game
   {
       [Key]
       public int ID { get; set; }

       [Required]
       [MaxLength(50)]
       public string Ime { get; set; }

       public List<Casa> Case { get; set; }
   }

}