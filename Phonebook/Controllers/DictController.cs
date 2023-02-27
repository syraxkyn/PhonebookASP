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
        public ActionResult AddSave(string LastName, string Phone)
        {
            HandbookRecord handbookRecord = new HandbookRecord
            {
                Id = 0,
                LastName = LastName, 
                Phone = Phone 
            };
            _handbookRecordRepository.Create(handbookRecord);
            try
            {
                _handbookRecordRepository.Save();
            }
            catch(Exception ex)
            {
                return Redirect("/Dict/Add");
            }
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
        [HttpPost]
        public ActionResult UpdateSave(string LastName, string Phone,int Id)
        {
            HandbookRecord handbookRecord = new HandbookRecord
            {
                Id = Id,
                LastName = LastName,
                Phone = Phone
            };
            _handbookRecordRepository.Update(handbookRecord);
            try
            {
                _handbookRecordRepository.Save();
            }
            catch(Exception ex)
            {
                return Redirect("/Dict/Index");
            }
            return Redirect("/Dict/Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var handbookRecord = _handbookRecordRepository.GetRecord(id);
            if (handbookRecord != null)
            {
                ViewBag.Id = handbookRecord.Id;
                return View();
            }
            else
            {
                return Redirect("/Dict/Index");
            }
        }
        [HttpPost]
        public ActionResult DeleteSave(int id) 
        { 
            _handbookRecordRepository.Delete(id);
            _handbookRecordRepository.Save();
            return Redirect("/Dict/Index");
        }
    }
}