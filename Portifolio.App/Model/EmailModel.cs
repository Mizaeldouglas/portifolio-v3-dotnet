using System.ComponentModel.DataAnnotations;

namespace Portifolio.App.Model;

public class EmailModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Message { get; set; }

}