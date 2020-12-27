using MockTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTest.Models
{
    public class ScoreRepository : IScoreRepository
    {
        private MockTestContext _context;

        public ScoreRepository(MockTestContext context)
        {
            _context = context;
        }

        public List<Score> GetScores()
        {
            return _context.Score.ToList();
        }

        public void Add(Score score)
        {
            _context.Score.Add(score);
        }

        public bool SaveChanges()
        {
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}