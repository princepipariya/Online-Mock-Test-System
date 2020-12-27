using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MockTest.Data;
using MockTest.Models;

namespace MockTest.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly MockTestContext _context;
        private IQuestionRepository _QuestionRepository;
        private IScoreRepository _ScoreRepository;

        public QuestionsController(MockTestContext context, IQuestionRepository questionRepository, IScoreRepository scoreRepository)
        {
            _context = context;
            _QuestionRepository = questionRepository;
            _ScoreRepository = scoreRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Questions.ToListAsync());
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Questions que)
        {

            Console.WriteLine("in the adding if\n");
            Console.WriteLine(que.Subject);
            _QuestionRepository.Add(que);
            if (await _QuestionRepository.SaveChangesAsync())
            {
                ViewBag.msg = "Question Added Successfully";
                return View();
            }
            else
                return View(que);
        }
        [HttpGet]
        public IActionResult Delete()
        {
            var allquestions = _QuestionRepository.GetAllQuestions();
            return View(allquestions);
        }

        public async Task<IActionResult> DeleteConfirm(int id)
        {
            Console.WriteLine("in controller delte with id:" + id + "\n");
            _QuestionRepository.DeleteQuestion(id);
            await _QuestionRepository.SaveChangesAsync();
            return RedirectToAction("Delete");
        }

        [HttpGet]
        public IActionResult Score()
        {
            Console.WriteLine("11111111111");
            var allscore = _ScoreRepository.GetScores();
            Console.WriteLine(allscore[0].Username);
            Console.WriteLine("2222222222");
            return View(allscore);
        }
    }
}