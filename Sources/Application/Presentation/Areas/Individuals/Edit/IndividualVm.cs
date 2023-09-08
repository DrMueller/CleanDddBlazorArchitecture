using System.ComponentModel.DataAnnotations;
using Mmu.CleanBlazor.Presentation.Areas.Individuals.Common.Models;

namespace Mmu.CleanBlazor.Presentation.Areas.Individuals.Edit;

public class IndividualVm
{
    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string FirstName { get; set; }

    public GenderVm Gender { get; set; }

    public long IndividualId { get; set; }

    [Required]
    public string LastName { get; set; }
}