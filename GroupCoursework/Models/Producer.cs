using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Producer: IEntityBase
{
    [Key]
    public int Id { get; set; }


    [Display(Name = "Name")]
    [Required(ErrorMessage = "Producer Name is Required")]
    public string ProducerName { get; set; }
    
    
    // Relationship
    
    public List<DvdTitle> DvdTitles { get; set; }

}