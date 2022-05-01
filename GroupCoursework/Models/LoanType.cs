using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class LoanType: IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Loan Types")]
    [Required(ErrorMessage = "Loan Type is Required")]
    public string LoanTypes { get; set; }

    [Display(Name = "Loan Durantion")]
    [Required(ErrorMessage = "Loan Durantion is Required")]
    public string LoanDurantion { get; set; }
    
    
    // Relationship
    public List<Loan> Loans { get; set; }
}