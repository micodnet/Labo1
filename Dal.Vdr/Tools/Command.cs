using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Vdr.Tools
{
    public class Command
    {
        internal string Query { get; init; }
        internal bool IsStoredProcedure { get; init; }
        internal Dictionary<string, object> Parameters { get; init; }

        public Command(string query, bool isStoredProcedure)
        {
            Query = query;
            IsStoredProcedure = isStoredProcedure;
            Parameters = new Dictionary<string, object>();
        }

        public void AddParameter(string parameterName, object? value)
        {
            Parameters.Add(parameterName, value ?? DBNull.Value);
        }
    }
}
