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
        string jsonData;
        public void Create(HandbookRecord item)
        {
            jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            if(handbookRecordList.Count != 0)
            {
                item.Id = handbookRecordList.Max(x => x.Id) + 1;
            }
            bool recordAlreadyExists = handbookRecordList.Exists(x => x.LastName == item.LastName && x.Phone == item.Phone);
            if (!recordAlreadyExists)
            {
                handbookRecordList.Add(item);
                jsonData = JsonConvert.SerializeObject(handbookRecordList);
                //File.WriteAllText(jsonFilePath, jsonData);
            }
        }

        public void Delete(int id)
        {
            jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            var handbookRecord = handbookRecordList.Where(x => x.Id == id).FirstOrDefault();
            if (handbookRecord != null)
            {
                handbookRecordList.Remove(handbookRecord);
                jsonData = JsonConvert.SerializeObject(handbookRecordList);
                //File.WriteAllText(jsonFilePath, jsonData);
            }
        }

        public HandbookRecord GetRecord(int id)
        {
            jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            HandbookRecord handbookRecord = handbookRecordList.Where(x => x.Id == id).FirstOrDefault();
            return handbookRecord;
        }

        public IEnumerable<HandbookRecord> GetRecords()
        {
            jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            var sortedList = handbookRecordList.OrderBy(x => x.LastName).ToList();
            return sortedList;
        }

        public void Update(HandbookRecord item)
        {
            jsonData = File.ReadAllText(jsonFilePath);
            var handbookRecordList = JsonConvert.DeserializeObject<List<HandbookRecord>>(jsonData) ?? new List<HandbookRecord>();
            var obj = handbookRecordList.Where(x => x.Id == item.Id).FirstOrDefault();
            if (obj != null)
            {
                if(obj.LastName == item.LastName)
                {
                    if (obj.Phone != item.Phone)
                    {
                        bool numberAlreadyExists = handbookRecordList.Count(x => x.Phone == item.Phone) == 1;
                        if (!numberAlreadyExists)
                        {
                            obj.Phone = item.Phone;
                            jsonData = JsonConvert.SerializeObject(handbookRecordList);
                            //File.WriteAllText(jsonFilePath, jsonData);
                        }
                    }
                }
                else
                {
                    obj.LastName = item.LastName;
                    if(obj.Phone != item.Phone)
                    {
                        bool numberAlreadyExists = handbookRecordList.Count(x => x.Phone == item.Phone) == 1;
                        if (!numberAlreadyExists)
                        {
                            obj.Phone = item.Phone;
                        }
                    }
                    jsonData = JsonConvert.SerializeObject(handbookRecordList);
                    //File.WriteAllText(jsonFilePath, jsonData);
                }
            }
        }
        public void Save()
        {
            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}