using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public interface IBowlersRespository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
