using Data.Entities;
using Data.Repositories;
using JonasTest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using JonasTest.Utils;

namespace JonasTest.Controllers
{
    public class QuestionnaireController : Controller
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionnaireController()
        {
            _questionRepository = new QuestionRepository();
        }

        // GET: Questionnaire
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListView()
        {
            var savedQuestions = _questionRepository.GetAll();

            foreach (var item in savedQuestions)
            {
                item.SetTypeDesc(GetTypeDesc(item.Type));
            }

            ViewBag.Questions = savedQuestions;

            return View();
        }

        private string GetTypeDesc(int type)
        {
            var description = Extensions.GetEnumDisplayName((DataTypeEnum)type);
            return description;
        }

        [HttpPost]
        public JsonResult Questionnaire(List<Question> questions)
        {
            try
            {
                _questionRepository.InsertAll(questions);
            }
            catch (System.Exception)
            {
                return Json(new { msg = "Error to save in DataBase" });
            }

            return Json(new { msg = "Questions saved" });
        }
    }
}