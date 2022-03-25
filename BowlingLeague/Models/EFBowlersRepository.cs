using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class EFBowlersRepository : IBowlersRespository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
