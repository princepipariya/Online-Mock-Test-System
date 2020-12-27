using MockTest.Data;
using MockTest.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTest.Models
{
    public class QuestionRepository : IQuestionRepository
    {
        private MockTestContext _context;
        public QuestionRepository(MockTestContext context)
        {
            _context = context;
        }
        public Questions GetQuestions(string Subject, string Difficulty)
        {
            Questions Question = _context.Questions.Find(Subject);
            if (Question != null)
            {
                return Question;
            }
            return null;

        }

        public List<Questions> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public void Add(Questions Question)
        {
            _context.Questions.Add(Question);
        }

        public List<Questions> GetExamQuestions(string subject, string difficulty)
        {
            Console.WriteLine(subject + "\n" + difficulty);
            var query = _context.Questions.Where(q => q.Subject == subject && q.Difficulty == difficulty).ToList();
            Random rnd = new Random();
            List<Questions> resultList = new List<Questions>();

            while (resultList.Count < 5)
            {
                Questions q = query[rnd.Next(query.Count)];
                if (!resultList.Contains(q))
                {
                    resultList.Add(q);
                }
            }
            Console.WriteLine(resultList[1].Answer);
            return resultList;
        }

        public Questions GetQuestion(int id)
        {
            return _context.Questions.FirstOrDefault(q => q.Question_Id == id);
        }
        public void DeleteQuestion(int id)
        {
            Console.WriteLine("in repo in delte que");
            _context.Questions.Remove(GetQuestion(id));
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}