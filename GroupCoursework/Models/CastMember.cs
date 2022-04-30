using System.ComponentModel.DataAnnotations.Schema;

namespace GroupCoursework.Models;

public class CastMember
{
    public int ActorNumber { get; set; }
    [ForeignKey("ActorNumber")]
    public Actor Actor { get; set; }
    
    public int DVDNumber { get; set; } 
    [ForeignKey("DVDNumber")]
    public DvdTitle DvdTitle { get; set; }
}