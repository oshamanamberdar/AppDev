using GroupCoursework.Models;

namespace GroupCoursework.ViewModel;

public class TestView
{
    public Actor Actor { get; set; }
    public DvdTitle DvdTitle { get; set; }
    public DvdCategory DvdCategory { get; set; }
    public Producer Producer { get; set; }
    
    public CastMember CastMember { get; set; }
    
    public Studio Studio { get; set; }
    
    public Member Member { get; set; }
    
    public Loan Loan { get; set; }
    
    public DvdCopy DvdCopy { get; set; }
    
    public MembershipCategory MembershipCategory { get; set; }
    
    public string? SearchString { get; set; }
}