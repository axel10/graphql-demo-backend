using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHLStats.Core.Models;

namespace NHLStats.Data
{
    public interface ITeamRepository
    {
        Task<List<Team>> All();
    }
}