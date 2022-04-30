using System.ComponentModel.DataAnnotations;

namespace GroupCoursework.Models;

public class Actor
{
    [Key]
    public int ActorNumber { get; set; }
    
    public string ActorSurname { get; set; }
    
    public string ActorFirstName { get; set; }
    
    
    //Relationship
    public List<CastMember> CastMembers { get; set; }

}