using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxex_api.model;

public class Country
{
 [Key]
 [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
 public int id { get; set; }
 
 [Required]
 public string kd_country { get; set; }
 
 [Required]
 public string name { get; set; }
 
 public ICollection<Harbour> Harbours { get; set; }
}