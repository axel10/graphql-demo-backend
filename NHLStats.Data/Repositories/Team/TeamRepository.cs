using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHLStats.Core.Models;

namespace NHLStats.Data
{
    public class TeamRepository : ITeamRepository
    {
        private readonly NHLStatsContext _db;

        public TeamRepository(NHLStatsContext db)
        {
            _db = db;
        }

        public async Task<List<Team>> All()
        {
            return await _db.Teams.ToListAsync();
        }
    }
}