using System.ComponentModel.DataAnnotations;
public class FullNameViewModel
{

    [StringLength(50, MinimumLength = 3)]
    [Required]
    [Display(Name = "fullname")]
    public string FullName { get; set; }
}