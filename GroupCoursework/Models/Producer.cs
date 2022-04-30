using System.ComponentModel.DataAnnotations;

namespace GroupCoursework.Models;

public class Producer
{
    [Key]
    public int ProducerNumber { get; set; }
    
    public string ProducerName { get; set; }
    
    
    // Relationship
    
    public List<Producer> Producers { get; set; }

}