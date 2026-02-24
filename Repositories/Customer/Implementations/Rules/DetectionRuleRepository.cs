using FraudMonitoringSystem.Data;
using FraudMonitoringSystem.Models.Rules;
using FraudMonitoringSystem.Repositories.Customer.Interfaces.Rules;
using Microsoft.EntityFrameworkCore;

namespace FraudMonitoringSystem.Repositories.Customer.Implementations.Rules
{
    public class DetectionRuleRepository : IDetectionRuleRepository

    {

        private readonly WebContext _context;

        public DetectionRuleRepository(WebContext context)

        {

            _context = context;

        }

        public DetectionRule GetById(int id)

        {

            return _context.DetectionRules

                           .Include(r => r.Scenario)            // <-- load Scenario details

                           .FirstOrDefault(r => r.RuleId == id);

        }

        public IEnumerable<DetectionRule> GetAll()

        {

            return _context.DetectionRules

                           .Include(r => r.Scenario)   // <-- load Scenario details

                           .ToList();

        }

        public void Add(DetectionRule rule)

        {

            _context.DetectionRules.Add(rule);

            _context.SaveChanges();

        }

        public void Update(DetectionRule rule)

        {

            _context.DetectionRules.Update(rule);

            _context.SaveChanges();

        }

        public void Delete(int id)

        {

            var rule = _context.DetectionRules.Find(id);

            if (rule != null)

            {

                _context.DetectionRules.Remove(rule);

                _context.SaveChanges();

            }

        }

    }
}