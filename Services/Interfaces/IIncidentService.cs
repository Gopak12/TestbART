using TestbART.Model;

namespace TestbART.Services.Interfaces
{
    public interface IIncidentService
    {
        Task CreateIncidentAsync(Incident incident);

        Task UpdateIncidentAsync(Incident incident);

        Task DeleteIncidentAsync(string incidentName);

        Incident? GetIncidentById(string name);

        List<Incident> GetAllIncidents();
    }
}
