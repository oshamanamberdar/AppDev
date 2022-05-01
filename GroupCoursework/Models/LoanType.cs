using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class LoanType: IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string LoanTypes { get; set; }
    public string LoanDurantion { get; set; }
    
    
    // Relationship
    public List<Loan> Loans { get; set; }
}