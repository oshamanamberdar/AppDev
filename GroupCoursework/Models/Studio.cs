using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Studio : IEntityBase
{
    [Display(Name = "Studio Name")]
    [Required(ErrorMessage = "Studio Name is Required")]
    public string StudioName { get; set; }

    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }

    [Key] public int Id { get; set; }
}