using Microsoft.AspNetCore.Mvc.RazorPages;
using FroniusCheatSheet.Models;

namespace FroniusCheatSheet.Pages;

public class IndexModel : PageModel
{
    public List<WeldingProcess> Processes => WeldingDatabase.Processes;
    public List<Characteristic> Characteristics => WeldingDatabase.Characteristics;
    public List<Scenario> Scenarios => WeldingDatabase.Scenarios;
    public List<Parameter> Parameters => WeldingDatabase.Parameters;
    public List<TipSection> TipSections => WeldingDatabase.TipSections;

    public void OnGet()
    {
    }
}
