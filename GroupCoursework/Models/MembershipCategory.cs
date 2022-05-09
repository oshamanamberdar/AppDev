using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class MembershipCategory : IEntityBase
{
    public string CategoryName { get; set; }

    [Display(Name = "Description")]
    [Required(ErrorMessage = "Membership Category Description is Required")]
    public string MembershipCategoryDescription { get; set; }


    [Display(Name = "Total Loans")]
    [Required(ErrorMessage = "Membership Category Total Loans is Required")]
    public int MembershipCategoryTotalLoans { get; set; }


    // Relationship

    public List<Member> Members { get; set; }

    [Key] public int Id { get; set; }
}