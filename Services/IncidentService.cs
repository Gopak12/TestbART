using TestbART.Data;
using TestbART.Model;
using TestbART.Services.Interfaces;

namespace TestbART.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly TestbARTContext _context;

        public IncidentService(TestbARTContext context) 
        {
            _context = context;
        }

        public async Task CreateIncidentAsync(Incident incident) 
        {
            incident.Name = Guid.NewGuid().ToString();

            foreach (var account in incident.Accounts)
            {
                var accountExist = _context.Accounts.FirstOrDefault(x => x.Name == account.Name);
                if (accountExist == null)
                    throw new Exception("Account not found");
            }
            await _context.Incidents.AddAsync(incident);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateIncidentAsync(Incident incident)
        {
            var incidentToUpdate = _context.Incidents.FirstOrDefault(x => x.Name == incident.Name);
            if (incidentToUpdate == null)
            {
                throw new ArgumentNullException(nameof(incident));
            }
            incidentToUpdate.Decsription = incident.Decsription;
            incidentToUpdate.Accounts = incident.Accounts;

            _context.Update(incidentToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteIncidentAsync(string incidentName)
        {
            var incidentToDelete = _context.Incidents.FirstOrDefault(x => x.Name == incidentName);
            if (incidentToDelete == null)
            {
                throw new ArgumentNullException(nameof(incidentName));
            }
            
            _context.Incidents.Remove(incidentToDelete);
            await _context.SaveChangesAsync();
        }

        public List<Incident> GetAllIncidents()
        {
            return _context.Incidents.ToList();
        }

        public Incident? GetIncidentById(string name)
        {
            return _context.Incidents.FirstOrDefault(x => x.Name == name);
        }
    }
}
