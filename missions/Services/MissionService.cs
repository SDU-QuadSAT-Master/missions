using missions.Controllers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

public interface IMissionService
{
    IEnumerable<Mission> GetAll();
    Mission GetById(int id);
    Mission Create(MissionCreateRequest model);
    Mission Update(int id, MissionUpdateRequest model);
    void Delete(int id);
}

public class MissionService : IMissionService
{

    private DataContext _context;
    private readonly IMapper _mapper;
    public MissionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Mission> GetAll()
    {
        return _context.Missions.Include(mission => mission.AntennaConfig).ToList();
    }

    public Mission GetById(int id)
    {
        return getMission(id);
    }
    public Mission Create(MissionCreateRequest model)
    {
        var mission = _mapper.Map<Mission>(model);
        _context.Add(mission);
        _context.SaveChanges();

        return mission;
    }

    public Mission Update(int id, MissionUpdateRequest model)
    {
        var mission = getMission(id);

        _mapper.Map(model, mission);
        _context.Missions.Update(mission);
        _context.SaveChanges();

        return mission;
    }

    public void Delete(int id)
    {
        var mission = getMission(id);
        _context.Missions.Remove(mission);
        _context.SaveChanges();
    }



    // Helper Function
    private Mission getMission(int id)
    {
        var mission = _context.Missions.Find(id);
        if (mission == null) throw new KeyNotFoundException("Mission not found");
        return mission;
    }
}