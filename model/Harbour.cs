using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxex_api.model;

public class Harbour
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Required]
    public int id_country { get; set; }
    
    [Required]
    public string name { get; set; }
    
    [ForeignKey("id_country")]
    public Country Country { get; set; }
}