using FIASApi.Model.Repositories.Abstract;

namespace FIASApi.Model
{
    public class DataManager
    {
        public IAreasRepository Areas { get; set; }

        public ICitiesRepository Cities { get; set; }

        public IFlatsRepository Flats { get; set; }

        public IHousesRepository Houses { get; set; }

        public IOfficesRepository Offices { get; set; }

        public IPlacesRepository Places { get; set; }

        public IRegionsRepository Regions { get; set; }

        public IStreetsRepository Streets { get; set; }

        public DataManager(IAreasRepository areas, ICitiesRepository cities, IFlatsRepository flats, IHousesRepository houses, IOfficesRepository offices, IPlacesRepository places, IRegionsRepository regions, IStreetsRepository streets)
        {
            Areas = areas;
            Cities = cities;
            Flats = flats;
            Houses = houses;
            Offices = offices;
            Places = places;
            Regions = regions;
            Streets = streets;
        }
    }
}
