using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
   public class Casa
   {
       [Key]
       public int ID { get; set; }

       [Required]
       [MaxLength(50)]
       public string Oznaka { get; set; }

       [Required]
       public int Kapacitet { get; set; }

       [Required]
       [Range(0,4)]
       public int Napunjenost { get; set; }

       public TecnostBoje TecnostBoje { get; set; }

       public Game Game { get; set; }

   }

}