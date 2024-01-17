using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.App.Abstract;

public interface IService<T>
{
    List<T> Items { get; } 
    List<T> GetAllItems();
    List<T> GetItemsByTypeId(int typeId);
    int GetLastId();
    T GetItemByID(int id);
    int AddItem(T item);
    int UpdateItem(T item);
    void RemoveItem(T item);

    // TODO: moving this method to a separate interface in the future
    string SerializeListToStringInJsonFormat();
    public void SaveSerializedStringInJsonToAFile(string serializedFormatJson);
    public void ReadDataFromJsonFileToList();
}
