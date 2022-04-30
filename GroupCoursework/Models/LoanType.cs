using System.ComponentModel.DataAnnotations;

namespace GroupCoursework.Models;

public class LoanType
{
    [Key]
    public int LoanTypeNumber { get; set; }
    public string LoanTypes { get; set; }
    public string LoanDurantion { get; set; }
    
    
    // Relationship
    public List<Loan> Loans { get; set; }
}