using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GroupCoursework.Base;

namespace GroupCoursework.Models;

public class DvdTitle: IEntityBase
{
    [Key]
    public int  Id { get; set; }

    [Display(Name = "Date Released")]
    [Required(ErrorMessage ="Date Relaeased is Required")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateReleased { get; set; }


    [Display(Name = "Standard Charge")]
    [Required(ErrorMessage = "Standard Charge is Required")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "money")]
    public decimal StandardCharge { get; set; }


    [Display(Name = "Penalty Charge")]
    [Required(ErrorMessage = "Penalty Charge is Required")]
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