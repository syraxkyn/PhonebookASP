using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Phonebook.Models
{
    public class JsonRepository : IRepository<HandbookRecord>
    {
        readonly string jsonFilePath = @"D:/Labs/ASP/Phonebook/Phonebook/App_Data/database.json";
        public void Create(HandbookRecord item)
        {
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();

                handbookRecordList.Add(item);

                jsonData = JsonConvert.SerializeObject(handbookRecordList);
                File.WriteAllText(jsonFilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public void Delete(int id)
        {
            try
            {
                var jsonData = File.ReadAllText(jsonFilePath);
                var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();

                if (GetRecord(id) != null)
                {
                    handbookRecordList.RemoveAt(id - 1);

                    jsonData = JsonConvert.SerializeObject(handbookRecordList);
                    File.WriteAllText(jsonFilePath, jsonData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Add Error : " + ex.Message.ToString());
            }
        }

        public HandbookRecord GetRecord(int id)
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            var handbookRecord = handbookRecordList.ElementAtOrDefault(id-1);
            return handbookRecord;
        }

        public IEnumerable<HandbookRecord> GetRecords()
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            return handbookRecordList;
        }

        public void Update(HandbookRecord item, int id = 0)
        {
            var jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            var obj = handbookRecordList.ElementAtOrDefault(id - 1);
            if (obj != null)
            {
                obj.LastName = item.LastName;
                obj.Phone = item.Phone;
            }
        }
    }
}