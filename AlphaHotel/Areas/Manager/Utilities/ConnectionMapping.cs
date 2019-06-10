using System.Collections.Generic;
using System.Linq;

namespace AlphaHotel.Areas.Manager.Utilities
{
    public class ConnectionMapping
    {
        private readonly Dictionary<string, string> connections =
            new Dictionary<string, string>();

        public int Count
        {
            get
            {
                return connections.Count;
            }
        }

        public void Add(string key, string connectionId)
        {
            connections.Add(key, connectionId);
        }

        public void Remove(string key)
        {
            connections.Remove(key);
        }

        public IReadOnlyDictionary<string, string> GetConnections()
        {
            return connections;
        }
    }
}
