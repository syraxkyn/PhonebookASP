using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phonebook.Controllers
{
    public class DictController : Controller
    {
        readonly IRepository<HandbookRecord> _handbookRecordRepository;
        // GET: Dict
        public DictController(IRepository<HandbookRecord> repository)
        {
            _handbookRecordRepository = repository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.getall = _handbookRecordRepository.GetRecords();
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSave(HandbookRecord handbookRecord)
        {
            _handbookRecordRepository.Create(handbookRecord);
            return Redirect("/Dict/Index");
        }
        [HttpGet]
        public ActionResult Update(int id) 
        {
            var handbookRecord = _handbookRecordRepository.GetRecord(id);
            if(handbookRecord != null) 
            {
                ViewBag.handbookRecord = handbookRecord;
                return View();
            }
            else
            {
                return Redirect("/Dict/Index");
            }
        }
        //[HttpPost]
        //public ActionResult UpdateSave(HandbookRecord handbookRecord)
        //{

        //}
    }
}