using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAPI.Domain.Entities
{
    [Table("Apartments")]
    public class Apartments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Block")]
        [MaxLength(10)]
        public required string Block { get; set; } = string.Empty;  

        [Column("ApartmentNo")]
        [MaxLength(10)]
        public required string ApartmentNumber { get; set; } = string.Empty;
        public string ApartmentManager {  get; set; }
      
    }
}
