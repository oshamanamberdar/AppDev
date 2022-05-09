using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GroupCoursework.Models;

public class ApplicationUser : IdentityUser
{
    [Display(Name = "Full name")] public string FullName { get; set; }
}