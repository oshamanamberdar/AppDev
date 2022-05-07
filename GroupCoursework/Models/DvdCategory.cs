using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class DvdCategory: IEntityBase
{
    [Key]
    public int Id { get; set; }
    
    public string DvdCategoryName { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Category Description is Required")]
    public string CategoryDescription { get; set; }


    [Display(Name = "Age Restricted")]
    [Required(ErrorMessage = "Age Restricted is Required")]
    public string AgeRestricted { get; set; }
    
    
    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }
    
    
}