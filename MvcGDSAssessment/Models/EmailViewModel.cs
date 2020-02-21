using System.ComponentModel.DataAnnotations;
public class EmailViewModel
{
    [EmailAddress]
    [Required]
    [Display(Name = "email")]
    public string Email { get; set; }
}