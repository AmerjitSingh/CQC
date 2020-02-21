using System.ComponentModel.DataAnnotations;

public class AddressViewModel
{

    [StringLength(250, MinimumLength = 3)]
    [Required]
    [Display(Name = "address")]
    public string Address { get; set; }
}