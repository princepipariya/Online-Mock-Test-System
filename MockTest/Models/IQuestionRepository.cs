using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockTest.Models
{
    public interface IQuestionRepository
    {
        Questions GetQuestions(string Subject, string Difficulty);

        void Add(Questions NewQuestion);

        List<Questions> GetAllQuestions();

        public List<Questions> GetExamQuestions(string subject, string difficulty);
        void DeleteQuestion(int id);
        Task<bool> SaveChangesAsync();

    }
}