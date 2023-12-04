using Microsoft.EntityFrameworkCore;
using taxex_api.context;
using taxex_api.dto.country;
using taxex_api.model;

namespace taxex_api.service;

public class CountryService
{
    private readonly DbSet<Country> repositoryCountry;
    private readonly DbSet<Harbour> repositoryHarbour;

    public CountryService(MainContext mainContext)
    {
        this.repositoryCountry = mainContext.m_country;
        this.repositoryHarbour = mainContext.m_harbour;
    }

    public List<CountryResponse> getall()
    {
        var response = repositoryCountry.ToList();
        var countryResponse = response.Select(country => new CountryResponse
        {
            id = country.id,
            kd_country = country.kd_country,
            name = country.name
        }).ToList();
        return countryResponse;
    }

    public CountryResponse getByName(string name)
    {
        var getCountry = repositoryCountry.FirstOrDefault(res => res.name.ToLower().Contains(name.ToLower()));

        return new CountryResponse
        {
            id = getCountry.id,
            kd_country = getCountry.kd_country,
            name = getCountry.name
        };
    }
}