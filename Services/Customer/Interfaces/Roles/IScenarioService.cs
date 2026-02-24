using FraudMonitoringSystem.Models.Rules;

namespace FraudMonitoringSystem.Services.Customer.Interfaces.Roles
{
    public interface IScenarioService
    {
        Scenario GetScenarioById(int id);
        IEnumerable<Scenario> GetAllScenarios();
        void CreateScenario(Scenario scenario);
        void UpdateScenario(Scenario scenario);
        void DeleteScenario(int id);
    }
}