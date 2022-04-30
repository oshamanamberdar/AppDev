using System.ComponentModel.DataAnnotations;

namespace GroupCoursework.Models;

public class MembershipCategory
{
    [Key]
    public int MembershipCategoryNumber { get; set; }
    public string MembershipCategoryDescription { get; set; }
    public int MembershipCategoryTotalLoans { get; set; }
    
    
    // Relationship

    public List<Member> Members { get; set; }

}