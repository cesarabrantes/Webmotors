namespace Webmotors.Mediator.Api.Models
{
    public class Vehicles
    {
        private string vYearFab;

            public int ID { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Version { get; set; }
            public string Image { get; set; }
            public long KM { get; set; }
            public string Price { get; set; }
            public int YearModel { get; set; }
            public string YearFab { get { return $"Ano de fabricação {vYearFab}"; } set { vYearFab = value; } }
            public string Color { get; set; }        

    }
}
