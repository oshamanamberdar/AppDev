using System.ComponentModel.DataAnnotations;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class Actor:IEntityBase
{
    
    [Key]
    public int Id { get; set; }
    
    public string ActorSurname { get; set; }
    
    public string ActorFirstName { get; set; }
    
    
    //Relationship
    public List<CastMember> CastMembers { get; set; }

   
}