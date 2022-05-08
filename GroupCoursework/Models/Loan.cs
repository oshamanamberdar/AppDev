using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Loan: IEntityBase
{
    [Key]
    public int  Id { get; set; }

    
    [Display(Name = "Date Out")]
    [Required(ErrorMessage = "Date Out is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateOut { get; set; }


    [Display(Name = "Due Date")]
    [Required(ErrorMessage = "Date Due is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateDue { get; set; }


    [Display(Name = "Date Returned")]
    [Required(ErrorMessage = "Date Returned is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateReturned { get; set; }
    
    
    
    // Relationship
    
    public int MemberNumber { get; set; }
    [ForeignKey("MemberNumber")]
    public Member Member { get; set; }
    
    
    public int LoanTypeNumber { get; set; }
    [ForeignKey("LoanTypeNumber")]
    public LoanType LoanType { get; set; }
    
    
    public int CopyNumber { get; set; }
    [ForeignKey("CopyNumber")]
    public DvdCopy DvdCopy { get; set; }
    
}