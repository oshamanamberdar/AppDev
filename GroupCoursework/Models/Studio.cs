using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Studio: IEntityBase
{
    [Key]
    public int Id { get; set; }
    
    public string StudioName { get; set; }
    
    // Relationship
    public List<DvdTitle> DvdTitles { get; set; }
}