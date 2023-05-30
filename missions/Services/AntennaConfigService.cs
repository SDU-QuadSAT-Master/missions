using missions.Controllers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public interface IAntennaConfigService
{
    IEnumerable<AntennaConfig> GetAll();
    AntennaConfig GetById(int id);
    AntennaConfig Create(AntennaConfigCreateRequest model);
    AntennaConfig Update(int id, AntennaConfigUpdateRequest model);
    void Delete(int id);
}

public class AntennaConfigService : IAntennaConfigService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public AntennaConfigService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<AntennaConfig> GetAll()
    {
        return _context.AntennaConfigs.Include(ac => ac.Mission).ToList();
    }

    public AntennaConfig GetById(int id)
    {
        return getAntennaConfig(id);
    }
    public AntennaConfig Create(AntennaConfigCreateRequest model)
    {
        var antennaConfig = _mapper.Map<AntennaConfig>(model);
        _context.Add(antennaConfig);
        _context.SaveChanges();

        return antennaConfig;
    }

    public AntennaConfig Update(int id, AntennaConfigUpdateRequest model)
    {
        var antennaConfig = getAntennaConfig(id);

        _mapper.Map(model, antennaConfig);
        _context.AntennaConfigs.Update(antennaConfig);
        _context.SaveChanges();

        return antennaConfig;
    }

    public void Delete(int id)
    {
        var antennaConfig = getAntennaConfig(id);
        _context.AntennaConfigs.Remove(antennaConfig);
        _context.SaveChanges();
    }



    // Helper Function
    private AntennaConfig getAntennaConfig(int id)
    {
        var antennaConfig = _context.AntennaConfigs.Find(id);
        if (antennaConfig == null) throw new KeyNotFoundException("AntennaConfig not found");
        return antennaConfig;
    }
}