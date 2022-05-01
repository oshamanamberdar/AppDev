using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Actor:IEntityBase
{
    
    [Key]
    public int Id { get; set; }

    [Display(Name = "Sur Name")]
    [Required(ErrorMessage = "Actor Surname is Required")]
    public string ActorSurname { get; set; }

    [Display(Name = "First Name")]
    [Required(ErrorMessage = "Actor First Name is Required")]
    public string ActorFirstName { get; set; }
    
    
    //Relationship
    public List<CastMember> CastMembers { get; set; }

   
}