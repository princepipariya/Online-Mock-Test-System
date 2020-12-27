using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTest.Models
{
    public interface IScoreRepository
    {
        void Add(Score NewScore);
        bool SaveChanges();
        List<Score> GetScores();
    }
}