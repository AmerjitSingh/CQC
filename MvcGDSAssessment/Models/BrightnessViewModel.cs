using System.ComponentModel.DataAnnotations;

public class BrightnessViewModel
{

    [Required]
    [Display(Name = "brightness")]
    public string Brightness { get; set; }
}