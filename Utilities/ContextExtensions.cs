using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowGroupExcercise.Utilities
{
    public class ContextExtentions
    {
        private readonly ScenarioContext _context;

        public ContextExtentions(ScenarioContext scenarioContext)
        {
            _context = scenarioContext;
        }

        public void AddToContext(string key, string value)
        {
            _context.Add(key, value);
        }

        public void AddToContext(string key, int value)
        {
            _context.Add(key, value);
        }

        public void GetFromToContext(string key)
        {
            _context.Get<string>(key);
        }

        public string TryGetFromContext(string key)
        {
            var claimName = _context.TryGetValue(key, out dynamic email)
                ? email : key;
            return claimName;
        }
    }
}
