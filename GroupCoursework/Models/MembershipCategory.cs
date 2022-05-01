using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class MembershipCategory : IEntityBase
{
    [Key]
    public int Id { get; set; }
    public string MembershipCategoryDescription { get; set; }
    public int MembershipCategoryTotalLoans { get; set; }
    
    
    // Relationship

    public List<Member> Members { get; set; }

   
}