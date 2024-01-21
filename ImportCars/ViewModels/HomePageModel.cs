using ImportCars.Models;

namespace ImportCars.ViewModels;

public class HomePageModel
{
    public IEnumerable<Auctions> Auctions { get; set; } = default!;
}
