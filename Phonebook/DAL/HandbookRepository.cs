using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phonebook.DAL
{
    public class HandbookRepository : IRepository<HandbookRecord>
    {
        private ApplicationDbContext _context;
        public HandbookRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(HandbookRecord item)
        {
            _context.HandbookRecords.Add(item);
        }

        public void Delete(int id)
        {
            HandbookRecord handbookRecord = _context.HandbookRecords.Find(id);
            _context.HandbookRecords.Remove(handbookRecord);
        }

        public HandbookRecord GetRecord(int id)
        {
            return _context.HandbookRecords.Find(id);
        }

        public IEnumerable<HandbookRecord> GetRecords()
        {
            return _context.HandbookRecords.ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(HandbookRecord item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}