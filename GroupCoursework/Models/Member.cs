using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Member: IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string MemberFirstName { get; set; }
    public string MemberLastName { get; set; }
    public string MemberAddress { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime MemberDob { get; set; }
    
    
    // Relationship
    
    public int MembershipCategoryNumber { get; set; }
    [ForeignKey("MembershipCategoryNumber")]
    public MembershipCategory MembershipCategory { get; set; }
    
    
    public List<Loan> Loans { get; set; }
   



}