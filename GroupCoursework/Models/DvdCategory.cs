using System.ComponentModel.DataAnnotations;

namespace GroupCoursework.Models;

public class DvdCategory
{
    [Key]
    public int CategoryNumber { get; set; }
    
    public string CategoryDescription { get; set; }
    
    public string AgeRestricted { get; set; }
    
    
    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }
    
    
}