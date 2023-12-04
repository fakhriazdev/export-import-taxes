using Microsoft.EntityFrameworkCore;
using taxex_api.context;
using taxex_api.dto.harbour;
using taxex_api.model;

namespace taxex_api.service;

public class HarbourService
{
    private readonly DbSet<Country> repositoryCountry;
    private readonly DbSet<Harbour> repositoryHarbour;

    public HarbourService(MainContext mainContext)
    {
        this.repositoryCountry = mainContext.m_country;
        this.repositoryHarbour = mainContext.m_harbour;
    }

    public List<HarbourResponse> getall()
    {
        var response = repositoryHarbour.Select(harbour => new HarbourResponse()
        {
            id_harbour = harbour.id,
            id_country = repositoryHarbour.FirstOrDefault(country => country.id_country == harbour.id_country)
                .id_country,
            kd_country = repositoryHarbour
                .FirstOrDefault(country => country.Country.kd_country == harbour.Country.kd_country).Country.kd_country,
            name = harbour.name,
        }).ToList();
        return response;
    }

    public HarbourResponse getByName(string name, string kd_country)
    {
        var country = repositoryCountry.FirstOrDefault(country => country.kd_country.ToLower() == kd_country.ToLower());
        
        if (country == null)
            return null;
        {

            var harbour = repositoryHarbour.FirstOrDefault(harbour =>
                harbour.id_country == country.id && harbour.name.ToLower().Contains(name.ToLower()));

            if (harbour != null)
            {
                var response = new HarbourResponse
                {
                    id_harbour = harbour.id,
                    id_country = harbour.id,
                    kd_country = harbour.Country.kd_country,
                    name = harbour.name,
                };
                return response;
            }
            else {
                return null;
            }
        }
    }
}