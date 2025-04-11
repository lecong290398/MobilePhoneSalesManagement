using MobilePhoneSalesManagement.DataStructures;
using MobilePhoneSalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Services.Implements
{
    public class ScenarioService : IScenarioService
    {
        public ScenarioService()
        {

        }
        private static object GetValue<T>(T obj, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return property?.GetValue(obj);
        }

        // Chỉnh sửa giá trị thuộc tính theo điều kiện khóa
        public static bool EditByProperty<T>(SinglyLinkedList<T> list, string keyProperty, object keyValue, string targetProperty, object newValue)
        {
            if (list == null || list.Head == null) return false;

            var keyProp = typeof(T).GetProperty(keyProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            var targetProp = typeof(T).GetProperty(targetProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (keyProp == null || targetProp == null) return false;

            var node = list.Head;
            while (node != null)
            {
                var key = keyProp.GetValue(node.Data);
                if (key != null && key.Equals(keyValue))
                {
                    targetProp.SetValue(node.Data, Convert.ChangeType(newValue, targetProp.PropertyType));
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        /// <summary>
        /// Tìm kiếm các đối tượng trong danh sách liên kết đơn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"> Danh sách cần tìm</param>
        /// <param name="propertyName">Thuộc tính cần tìm</param>
        /// <param name="searchValue">Giá trị cần so sánh</param>
        /// <returns>Đối tượng cần tìm có trong danh sách</returns>
        public T SearchObjectByAttribute<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            var node = list.Head;

            while (node != null)
            {
                // Dùng Reflection để lấy giá trị của thuộc tính
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính và so sánh
                    var propertyValue = propertyInfo.GetValue(node.Data);
                    if (propertyValue != null && propertyValue.Equals(searchValue)) // Đối với các loại dữ liệu khác, dùng Equals
                    {
                        return node.Data;
                    }
                }
                node = node.Next;
            }

            // Nếu không tìm thấy, trả về null
            return default(T);
        }

        /// <summary>
        /// Tìm kiếm các đối tượng trong danh sách liên kết đơn 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"> Danh sách cần tìm</param>
        /// <param name="propertyName">Thuộc tính cần tìm</param>
        /// <param name="searchValue">Giá trị cần so sánh</param>
        /// <returns>Danh sách đối tượng cần tìm có trong danh sách</returns>
        public SinglyLinkedList<T> SearchObjectListByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            var node = list.Head;
            SinglyLinkedList<T> foundItems = new SinglyLinkedList<T>();

            while (node != null)
            {
                // Dùng Reflection để lấy giá trị của thuộc tính
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính
                    var propertyValue = propertyInfo.GetValue(node.Data);

                    // Kiểm tra nếu thuộc tính không phải null
                    if (propertyValue != null)
                    {
                        // Nếu thuộc tính là chuỗi, dùng Contains để tìm kiếm
                        if (propertyValue is string propertyString && searchValue is string searchString)
                        {
                            if (propertyString.Contains(searchString, StringComparison.OrdinalIgnoreCase)) // So sánh không phân biệt chữ hoa/thường
                            {
                                foundItems.Add(node.Data);
                            }
                        }
                        else if (propertyValue.Equals(searchValue)) // Đối với các loại dữ liệu khác, dùng Equals
                        {
                            foundItems.Add(node.Data);
                        }
                    }
                }
                node = node.Next;
            }

            return foundItems; // Trả về danh sách các đối tượng tìm thấy
        }


        /// <summary>
        ///  SortByAttributes với thuật toán Bubble Sort
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"> Danh sách cần xử lý</param>
        /// <param name="propertyName">Thuộc tính muốn sắp xếp</param>
        /// <param name="ascending">true (tăng dần) || false (Giảm dần) </param>
        /// <returns></returns>
        public SinglyLinkedList<T> SortByAttributes<T>(SinglyLinkedList<T> list, string propertyName, bool ascending = true)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng. Không cần sắp xếp.");
                return list; // Trả về danh sách không thay đổi nếu rỗng
            }

            bool swapped;
            do
            {
                swapped = false;
                var current = list.Head;
                while (current != null && current.Next != null)
                {
                    // Dùng Reflection để lấy giá trị thuộc tính
                    var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo != null)
                    {
                        var valueA = propertyInfo.GetValue(current.Data);
                        var valueB = propertyInfo.GetValue(current.Next.Data);

                        // So sánh giá trị thuộc tính
                        if (valueA != null && valueB != null)
                        {
                            int comparisonResult = Comparer<object>.Default.Compare(valueA, valueB);

                            if ((ascending && comparisonResult > 0) || (!ascending && comparisonResult < 0))
                            {
                                // Hoán đổi dữ liệu giữa current và current.Next
                                T temp = current.Data;
                                current.Data = current.Next.Data;
                                current.Next.Data = temp;

                                swapped = true;
                            }
                        }
                    }
                    current = current.Next;
                }
            }
            while (swapped); // Tiếp tục lặp cho đến khi không có sự thay đổi nào nữa

            Console.WriteLine($"Danh sách đã được sắp xếp theo thuộc tính: {propertyName}, thứ tự {(ascending ? "tăng dần" : "giảm dần")}");
            // Trả về danh sách đã sắp xếp
            return list;
        }

        /// <summary>
        /// Xóa phần tử trong danh sách liên kết đơn theo thuộc tính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Danh sách cần xử lý</param>
        /// <param name="propertyName">Thuộc tính cần xóa</param>
        /// <param name="searchValue">Giá trị cần tìm để xóa</param>
        public T DeleteByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng. Không có phần tử để xóa.");
                return default;
            }

            var node = list.Head;
            SinglyLinkedList<T>.Node previousNode = null;
            bool found = false;

            // Duyệt qua danh sách
            while (node != null)
            {
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính và so sánh
                    var propertyValue = GetValue(node.Data, propertyName);
                    if (propertyValue != null && propertyValue.Equals(searchValue))
                    {
                        // Nếu phần tử đầu tiên thì thay đổi Head
                        if (previousNode == null)
                        {
                            list.Head = node.Next;
                        }
                        else
                        {
                            // Xoá phần tử giữa hoặc cuối
                            previousNode.Next = node.Next;
                        }

                        Console.WriteLine($"Đã xóa phần tử với {propertyName} = {searchValue}");
                        found = true;
                        break; // Dừng khi đã xóa xong
                    }
                }

                previousNode = node;
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine($"❌ Không tìm thấy phần tử với {propertyName} = {searchValue}");
                return default;
            }
            else
            {
                return node.Data; // Trả về phần tử đã xóa
            }
        }

        /// <summary>
        /// Tìm phần tử có giá trị lớn nhất theo thuộc tính được truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Danh sách xử lý</param>
        /// <param name="propertyName">Thuộc tính cần so sánh</param>
        /// <returns></returns>
        public T FindMaxByAttributes<T>(SinglyLinkedList<T> list, string propertyName)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng.");
                return default;
            }

            // Lấy thông tin thuộc tính từ kiểu T
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                Console.WriteLine($"Không tìm thấy thuộc tính: {propertyName}");
                return default;
            }

            var node = list.Head;
            T maxItem = node.Data;
            double maxValue = Convert.ToDouble(property.GetValue(node.Data));

            node = node.Next;
            while (node != null)
            {
                double value = Convert.ToDouble(property.GetValue(node.Data));
                if (value > maxValue)
                {
                    maxValue = value;
                    maxItem = node.Data;
                }
                node = node.Next;
            }

            return maxItem;
        }

        /// <summary>
        /// Tìm phần tử có giá trị nhỏ nhất theo thuộc tính được truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Danh sách xử lý</param>
        /// <param name="propertyName">Thuộc tính cần so sánh</param>
        /// <returns></returns>
        public T FindMinByAttributes<T>(SinglyLinkedList<T> list, string propertyName)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng.");
                return default;
            }

            // Lấy thông tin thuộc tính từ kiểu T
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null)
            {
                Console.WriteLine($"Không tìm thấy thuộc tính: {propertyName}");
                return default;
            }

            var node = list.Head;
            T minItem = node.Data;
            double minValue = Convert.ToDouble(property.GetValue(node.Data));

            node = node.Next;
            while (node != null)
            {
                double value = Convert.ToDouble(property.GetValue(node.Data));
                if (value < minValue)
                {
                    minValue = value;
                    minItem = node.Data;
                }
                node = node.Next;
            }

            return minItem;
        }

        /// <summary>
        /// Đếm số phần tử có giá trị thuộc tính bằng giá trị truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Danh sách cần xử lý</param>
        /// <param name="propertyName">Thuộc tính cần so sánh</param>
        /// <param name="targetValue">Giá trị cần so sánh</param>
        /// <returns>Giá trị điếm</returns>
        public int CountByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            int count = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null && value.Equals(targetValue))
                {
                    count++;
                }
                node = node.Next;
            }

            return count;
        }

        /// <summary>
        /// Tính giá trị trung bình của thuộc tính truyền vào
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Danh sách cần xử lý</param>
        /// <param name="propertyName">Thuộc tính cần tính trung bình</param>
        /// <param name="targetValue">Giá trị cần so sánh</param>
        /// <returns>Giá trị trung bình</returns>
        public double AverageByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            int count = 0;
            double total = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null && value.Equals(targetValue))
                {
                    total += Convert.ToDouble(value);
                    count++;
                }
                node = node.Next;
            }

            return count > 0 ? total / count : 0;
        }

        /// <summary>
        /// Tính tổng giá trị của thuộc tính truyền vào
        /// </summary>
        /// <param name="list">Danh sách cần xử lý</param>
        /// <param name="propertyName">Thuộc tính cần tính tổng</param>
        /// <param name="targetValue">Giá trị cần so sánh</param>
        /// <returns>Giá trị tổng</returns>
       // Tính tổng theo thuộc tính có giá trị bằng targetValue
        public double SumByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            double total = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null && value.Equals(targetValue))
                {
                    total += Convert.ToDouble(value);
                }
                node = node.Next;
            }

            return total;
        }


        /// <summary>
        /// Đếm số phần tử có giá trị thuộc tính nằm trong khoảng từ min đến max
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertyName"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public int CountByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            int count = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null)
                {
                    double numericValue = Convert.ToDouble(value);
                    if (numericValue >= min && numericValue <= max)
                    {
                        count++;
                    }
                }
                node = node.Next;
            }

            return count;
        }

        /// <summary>
        /// Đếm số phần tử theo từng nhóm thuộc tính
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public Dictionary<string, int> CountByGroup<T>(SinglyLinkedList<T> list, string propertyName)
        {
            Dictionary<string, int> thongKe = new Dictionary<string, int>();

            if (list == null || list.Head == null) return thongKe;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return thongKe;

            var node = list.Head;
            while (node != null)
            {
                var key = property.GetValue(node.Data)?.ToString();
                if (!string.IsNullOrEmpty(key))
                {
                    if (!thongKe.ContainsKey(key))
                        thongKe[key] = 1;
                    else
                        thongKe[key]++;
                }
                node = node.Next;
            }

            return thongKe;
        }


        /// <summary>
        /// Tính tổng giá trị thuộc tính theo từng nhóm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="groupByProperty"></param>
        /// <param name="sumProperty"></param>
        /// <returns></returns>
        public Dictionary<string, double> SumByGroup<T>(SinglyLinkedList<T> list, string groupByProperty, string sumProperty)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            if (list == null || list.Head == null) return result;

            var groupProp = typeof(T).GetProperty(groupByProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            var valueProp = typeof(T).GetProperty(sumProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (groupProp == null || valueProp == null) return result;

            var node = list.Head;
            while (node != null)
            {
                var key = groupProp.GetValue(node.Data)?.ToString();
                var value = valueProp.GetValue(node.Data);

                if (!string.IsNullOrEmpty(key) && value != null)
                {
                    double numericValue = Convert.ToDouble(value);
                    if (!result.ContainsKey(key))
                        result[key] = numericValue;
                    else
                        result[key] += numericValue;
                }

                node = node.Next;
            }

            return result;
        }

        // Lọc danh sách theo thuộc tính và khoảng giá trị (min <= value <= max)
        public SinglyLinkedList<T> FilterByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max)
        {
            SinglyLinkedList<T> filteredList = new SinglyLinkedList<T>();
            if (list == null || list.Head == null) return filteredList;
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return filteredList;
            var node = list.Head;
            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null)
                {
                    double numericValue = Convert.ToDouble(value);
                    if (numericValue >= min && numericValue <= max)
                    {
                        filteredList.Add(node.Data);
                    }
                }
                node = node.Next;
            }
            return filteredList;
        }

    }
}
