using MobilePhoneSalesManagement.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Interfaces
{
    public interface IScenarioService
    {
        T SearchObjectByAttribute<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim);
        T EditListByProperty<T>(SinglyLinkedList<T> list, string keyProperty, object keyValue, Dictionary<string, object> updates);
        SinglyLinkedList<T> SearchObjectListByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim);
        T DeleteByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim);
        SinglyLinkedList<T> SortByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, bool ascending = true);
        T FindMinByAttributes<T>(SinglyLinkedList<T> list, string propertyName);
        T FindMaxByAttributes<T>(SinglyLinkedList<T> list, string propertyName);
        int CountByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue);
        double AverageByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue, string propertyAverage);
        int SumByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue, string propertySum);
        int CountByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max);
        Dictionary<string, int> CountByGroup<T>(SinglyLinkedList<T> list, string propertyName);
        Dictionary<string, double> SumByGroup<T>(SinglyLinkedList<T> list, string groupByProperty, string sumProperty);
        SinglyLinkedList<T> FilterByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max);
    }
}
