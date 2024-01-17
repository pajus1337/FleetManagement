using FleetManagement.App.Abstract;
using FleetManagement.Domain.Common;
using FleetManagement.App.Concrete;
using System.Text.Json;
using System.Numerics;
using FleetManagement.Domain.Entity;

namespace FleetManagement.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();

        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }
        public List<T> GetAllItems()
        {
            return Items;
        }

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }
        
        public List<T> GetItemsByTypeId(int typeId)
        {   
            return new(Items.Where(p => p.TypeId == typeId).ToList());
        }

        public int UpdateItem(T item)
        {
            var entity = Items.FirstOrDefault(p => p.Id == item.Id);
            if (entity != null)
            {
                entity = item;
            }
            return entity.Id;
        }

        public T GetItemByID(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }

        public string SerializeListToStringInJsonFormat()
        {
            string serializedList = JsonSerializer.Serialize(Items, new JsonSerializerOptions { WriteIndented = true });
            return serializedList;
        }

        public void SaveSerializedStringInJsonToAFile(string serializedFormatJson)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "data.json";
            File.WriteAllText($@"{basePath + fileName}", serializedFormatJson);
        }

        public void ReadDataFromJsonFileToList()
        {
            string fileName = "data.json";
            if (fileName != null)
            {
                return;
            }
            string jsonString = File.ReadAllText(fileName);
            Items = JsonSerializer.Deserialize<List<T>>(jsonString)!;            
        }
    }
}
