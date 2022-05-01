using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupCoursework.Models;

public class DvdTitle
{
    [Key]
    public int  DVDNumber { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateReleased { get; set; }
    
    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public decimal StandardCharge { get; set; }
    
    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public decimal PenaltyCharge { get; set; }
    
    
    
   //  public ICollection<CastMember> CastMembers { get; set; }

    public List<CastMember> CastMembers { get; set; }
    
    public int ProducerNumber { get; set; }
    [ForeignKey("ProducerNumber")]
    public Producer Producer { get; set; }
    
    public int StudioNumber { get; set; }
    [ForeignKey("StudioNumber")]
    public Studio Studio { get; set; }
    
    public int CategoryNumber { get; set; }
    [ForeignKey("CategoryNumber")]
    public DvdCategory DvdCategory { get; set; }
    

}