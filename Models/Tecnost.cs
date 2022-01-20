using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models
{
   public class TecnostBoje
   {
       [Key]
       public int ID { get; set; }

       [MaxLength(50)]
       [Required]
       public string red1 { get; set; }

       [MaxLength(50)]
       [Required]
       public string red2 { get; set; }

       [MaxLength(50)]
       [Required]
       public string red3 { get; set; }

       [MaxLength(50)]
       [Required]
       public string red4 { get; set; }

       public int CasaId { get; set; }

       public Casa Casa { get; set; }

      
       
   }

}