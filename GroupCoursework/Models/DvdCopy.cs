using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupCoursework.Models;

public class DvdCopy
{
    [Key]
    public int CopyNumber { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DatePurchased { get; set; }
    
    
    // Relationship
    public List<Loan> Loans { get; set; }
    
    public int DvdNumber { get; set; }
    [ForeignKey("DvdNumber")]
    public DvdTitle DvdTitle { get; set; }
    
}