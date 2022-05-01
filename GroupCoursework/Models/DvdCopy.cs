using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class DvdCopy: IEntityBase
{
    [Key]
    public int Id { get; set; }


    [Display(Name = "Date Purchased")]
    [Required(ErrorMessage = "Purchased Date is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DatePurchased { get; set; }


    // Relationship
    public List<Loan> Loans { get; set; }
    
    public int DvdNumber { get; set; }
    [ForeignKey("DvdNumber")]
    public DvdTitle DvdTitle { get; set; }
    
}