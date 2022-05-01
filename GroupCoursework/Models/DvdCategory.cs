using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class DvdCategory: IEntityBase
{
    [Key]
    public int Id { get; set; }
    
    public string CategoryDescription { get; set; }
    
    public string AgeRestricted { get; set; }
    
    
    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }
    
    
}