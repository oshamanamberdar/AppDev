using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Studio: IEntityBase
{
    [Key]
    public int Id { get; set; }


    [Display(Name = "Studio Name")]
    [Required(ErrorMessage = "Studio Name is Required")]
    public string StudioName { get; set; }
    
    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }
}