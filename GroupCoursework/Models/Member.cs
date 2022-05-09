using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Member : IEntityBase
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Member First Name is Required")]
    public string MemberFirstName { get; set; }

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Member Last Name is Required")]
    public string MemberLastName { get; set; }

    [Display(Name = "Address")]
    [Required(ErrorMessage = "Member Address is Required")]
    public string MemberAddress { get; set; }


    [Display(Name = "DOB")]
    [Required(ErrorMessage = "Member DOB is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime MemberDob { get; set; }


    // Relationship

    public int MembershipCategoryNumber { get; set; }

    [ForeignKey("MembershipCategoryNumber")]

    public MembershipCategory MembershipCategory { get; set; }


    public List<Loan> Loans { get; set; }

    [Key] public int Id { get; set; }
}