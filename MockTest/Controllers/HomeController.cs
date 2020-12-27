using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MockTest.Data;
using MockTest.Models;

namespace MockTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MockTestContext _context;
        private IQuestionRepository _QuestionRepository;
        private IScoreRepository _ScoreRepository;

        public HomeController(ILogger<HomeController> logger, MockTestContext context, IQuestionRepository questionRepository, IScoreRepository scoreRepository)
        {
            _logger = logger;
            _context = context;
            _QuestionRepository = questionRepository;
            _ScoreRepository = scoreRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Exam(string subject, string difficulty)
        {
            Console.WriteLine("in controller index");
            Console.WriteLine(subject + difficulty);
            var examQuestions = _QuestionRepository.GetExamQuestions(subject, difficulty);

            return View(examQuestions);
        }

        public IActionResult Marks()
        {
            string[] useranswer = new string[6];
            string[] answer = new string[6];
            string[] question = new string[6];
            string[] tempcorrect = new string[6];
            string[] tempuser = new string[6];

            int marks = 0, i = 1;
            while (i < 6)
            {
                question[i] = "question" + i;
                useranswer[i] = "useranswer" + i;
                answer[i] = "answer" + i;
                i++;
            }
            i = 1;

            while (i < 6)
            {
                question[i] = HttpContext.Request.Form[question[i]];
                useranswer[i] = HttpContext.Request.Form[useranswer[i]];
                answer[i] = HttpContext.Request.Form[answer[i]];
                i++;
            }

            i = 1;
            while (i < 6)
            {
                if (useranswer[i] == answer[i])
                {
                    marks++;
                }
                else
                {
                    tempcorrect[i] = "Correct answer is: " + answer[i];
                    tempuser[i] = "Your answer is: " + useranswer[i];
                }
                i++;
            }
            ViewBag.question = question;
            ViewBag.tempcorrect = tempcorrect;
            ViewBag.tempuser = tempuser;
            ViewBag.marks = marks;

            Score score = new Score();
            string subject, difficulty, username;
            subject = HttpContext.Request.Form["subject"];
            difficulty = HttpContext.Request.Form["difficulty"];
            username = HttpContext.Request.Form["username"];
            score.Subject = subject;
            score.Difficulty = difficulty;
            score.Mark = marks;
            score.Username = username;
            _ScoreRepository.Add(score);
            if (_ScoreRepository.SaveChanges())
            {
                Console.WriteLine("score added");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}