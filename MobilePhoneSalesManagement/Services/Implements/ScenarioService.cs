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

        /// <summary>
        /// Lấy giá trị của một thuộc tính từ đối tượng của kiểu T dựa trên tên thuộc tính.
        /// Phương thức này sử dụng Reflection để tìm kiếm thuộc tính và trả về giá trị của nó.
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng mà từ đó sẽ lấy giá trị thuộc tính.</typeparam>
        /// <param name="obj">Đối tượng chứa thuộc tính cần lấy giá trị.</param>
        /// <param name="propertyName">Tên thuộc tính cần lấy giá trị.</param>
        /// <returns>Giá trị của thuộc tính nếu tìm thấy, hoặc null nếu không tìm thấy thuộc tính hoặc đối tượng.</returns>
        private object GetValue<T>(T obj, string propertyName)
        {
            // Tìm thuộc tính trong kiểu T với tên thuộc tính không phân biệt chữ hoa/thường
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // Nếu thuộc tính tồn tại, trả về giá trị của nó, nếu không trả về null
            return property?.GetValue(obj);
        }

        /// <summary>
        /// Cập nhật một đối tượng trong danh sách liên kết (SinglyLinkedList<T>) theo thuộc tính khóa và giá trị của nó.
        /// Phương thức duyệt qua danh sách, tìm đối tượng có thuộc tính khóa khớp với giá trị chỉ định, 
        /// và cập nhật các thuộc tính của đối tượng đó theo thông tin trong dictionary updates.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) chứa các đối tượng cần chỉnh sửa.</param>
        /// <param name="keyProperty">Tên thuộc tính khóa cần tìm để xác định đối tượng cần cập nhật.</param>
        /// <param name="keyValue">Giá trị của thuộc tính khóa để so sánh với các đối tượng trong danh sách.</param>
        /// <param name="updates">Một dictionary chứa tên thuộc tính làm khóa và giá trị cập nhật tương ứng.</param>
        /// <returns>Đối tượng đã được chỉnh sửa nếu tìm thấy và cập nhật thành công, hoặc giá trị mặc định của kiểu T nếu không tìm thấy hoặc không có thay đổi.</returns>
        public T EditListByProperty<T>(SinglyLinkedList<T> list, string keyProperty, object keyValue, Dictionary<string, object> updates)
        {
            // Kiểm tra các điều kiện đầu vào
            if (list == null || list.Head == null || updates == null || updates.Count == 0) return default;

            // Lấy thông tin về thuộc tính khóa cần tìm
            var keyProp = typeof(T).GetProperty(keyProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (keyProp == null) return default;

            int count = 0; // Biến đếm số đối tượng được cập nhật
            var node = list.Head;
            T updatedItem = default; // Biến lưu đối tượng đã được chỉnh sửa

            // Duyệt qua các phần tử trong danh sách
            while (node != null)
            {
                var key = keyProp.GetValue(node.Data);
                // Kiểm tra nếu thuộc tính khóa khớp với giá trị đã cho
                if (key != null && key.Equals(keyValue))
                {
                    // Cập nhật các thuộc tính theo dictionary updates
                    foreach (var kvp in updates)
                    {
                        var prop = typeof(T).GetProperty(kvp.Key, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        // Kiểm tra thuộc tính có tồn tại và giá trị cập nhật không null
                        if (prop != null && kvp.Value != null)
                        {
                            // Cập nhật giá trị thuộc tính với kiểu đúng
                            prop.SetValue(node.Data, Convert.ChangeType(kvp.Value, prop.PropertyType));
                        }
                    }
                    updatedItem = node.Data; // Lưu đối tượng đã chỉnh sửa
                    count++; // Tăng số lượng đối tượng đã cập nhật
                }
                node = node.Next; // Chuyển đến nút tiếp theo trong danh sách
            }

            // Trả về đối tượng đã được chỉnh sửa nếu có, hoặc giá trị mặc định nếu không có thay đổi
            return count > 0 ? updatedItem : default;
        }


        /// <summary>
        /// Tìm kiếm một đối tượng trong danh sách liên kết (SinglyLinkedList<T>) dựa trên giá trị của thuộc tính.
        /// Phương thức này sẽ duyệt qua từng phần tử trong danh sách, lấy giá trị thuộc tính dựa trên tên thuộc tính,
        /// và so sánh với giá trị tìm kiếm. Nếu tìm thấy, nó sẽ trả về đối tượng chứa thuộc tính đó.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) cần tìm kiếm đối tượng.</param>
        /// <param name="propertyName">Tên thuộc tính cần tìm kiếm trong đối tượng.</param>
        /// <param name="searchValue">Giá trị của thuộc tính cần so sánh.</param>
        /// <returns>Đối tượng tìm được nếu tìm thấy, hoặc giá trị mặc định của kiểu T nếu không tìm thấy.</returns>
        public T SearchObjectByAttribute<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            var node = list.Head;  // Bắt đầu từ phần tử đầu tiên trong danh sách

            // Duyệt qua các nút trong danh sách liên kết
            while (node != null)
            {
                // Sử dụng Reflection để lấy thông tin thuộc tính từ kiểu T
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // Kiểm tra xem thuộc tính có tồn tại không
                if (propertyInfo != null)
                {
                    // Lấy giá trị của thuộc tính và so sánh với giá trị tìm kiếm
                    var propertyValue = propertyInfo.GetValue(node.Data);
                    if (propertyValue != null && propertyValue.Equals(searchValue)) // So sánh nếu giá trị không phải null
                    {
                        return node.Data;  // Nếu tìm thấy, trả về đối tượng chứa thuộc tính khớp
                    }
                }

                // Chuyển đến nút tiếp theo trong danh sách
                node = node.Next;
            }

            // Nếu không tìm thấy đối tượng nào, trả về giá trị mặc định của kiểu T
            return default(T);
        }


        /// <summary>
        /// Tìm kiếm các đối tượng trong danh sách liên kết (SinglyLinkedList<T>) dựa trên giá trị của một thuộc tính.
        /// Phương thức này sẽ duyệt qua từng phần tử trong danh sách, lấy giá trị thuộc tính và so sánh với giá trị tìm kiếm.
        /// Nếu tìm thấy các đối tượng có thuộc tính khớp, chúng sẽ được thêm vào danh sách kết quả.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) cần tìm kiếm đối tượng.</param>
        /// <param name="propertyName">Tên thuộc tính cần tìm kiếm trong đối tượng.</param>
        /// <param name="searchValue">Giá trị của thuộc tính cần so sánh.</param>
        /// <returns>Danh sách các đối tượng tìm được nếu tìm thấy, hoặc danh sách trống nếu không có đối tượng nào khớp.</returns>
        public SinglyLinkedList<T> SearchObjectListByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            var node = list.Head;  // Bắt đầu từ phần tử đầu tiên trong danh sách
            SinglyLinkedList<T> foundItems = new SinglyLinkedList<T>();  // Tạo danh sách trống để lưu các đối tượng tìm được

            // Duyệt qua các nút trong danh sách liên kết
            while (node != null)
            {
                // Sử dụng Reflection để lấy thông tin thuộc tính từ kiểu T
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                // Kiểm tra xem thuộc tính có tồn tại không
                if (propertyInfo != null)
                {
                    // Lấy giá trị của thuộc tính
                    var propertyValue = propertyInfo.GetValue(node.Data);

                    // Kiểm tra nếu thuộc tính không phải null
                    if (propertyValue != null)
                    {
                        // Nếu thuộc tính là chuỗi, dùng Contains để tìm kiếm (so sánh không phân biệt chữ hoa/thường)
                        if (propertyValue is string propertyString && searchValue is string searchString)
                        {
                            if (propertyString.Contains(searchString, StringComparison.OrdinalIgnoreCase)) // So sánh không phân biệt chữ hoa/thường
                            {
                                foundItems.Add(node.Data);  // Thêm đối tượng vào danh sách kết quả
                            }
                        }
                        // Đối với các loại dữ liệu khác, so sánh trực tiếp với giá trị tìm kiếm
                        else if (propertyValue.Equals(searchValue))
                        {
                            foundItems.Add(node.Data);  // Thêm đối tượng vào danh sách kết quả
                        }
                    }
                }
                node = node.Next;  // Chuyển đến nút tiếp theo trong danh sách
            }

            return foundItems;  // Trả về danh sách các đối tượng tìm thấy
        }

        /// <summary>
        /// Sắp xếp danh sách liên kết (SinglyLinkedList<T>) theo một thuộc tính của các đối tượng trong danh sách.
        /// Phương thức này sử dụng thuật toán sắp xếp nổi bọt (Bubble Sort) để sắp xếp danh sách dựa trên giá trị của một thuộc tính cụ thể.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) cần sắp xếp.</param>
        /// <param name="propertyName">Tên thuộc tính dùng để sắp xếp.</param>
        /// <param name="ascending">Thứ tự sắp xếp, mặc định là true (tăng dần). Nếu false, sẽ sắp xếp giảm dần.</param>
        /// <returns>Danh sách đã sắp xếp theo thuộc tính và thứ tự chỉ định.</returns>
        public SinglyLinkedList<T> SortByAttributes<T>(SinglyLinkedList<T> list, string propertyName, bool ascending = true)
        {
            // Kiểm tra nếu danh sách rỗng, không cần sắp xếp
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng. Không cần sắp xếp.");
                return list; // Trả về danh sách không thay đổi nếu danh sách rỗng
            }

            bool swapped;
            do
            {
                swapped = false;
                var current = list.Head;

                // Duyệt qua các phần tử trong danh sách liên kết
                while (current != null && current.Next != null)
                {
                    // Dùng Reflection để lấy thông tin thuộc tính cần sắp xếp
                    var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (propertyInfo != null)
                    {
                        // Lấy giá trị của thuộc tính từ đối tượng hiện tại và đối tượng tiếp theo
                        var valueA = propertyInfo.GetValue(current.Data);
                        var valueB = propertyInfo.GetValue(current.Next.Data);

                        // So sánh giá trị thuộc tính
                        if (valueA != null && valueB != null)
                        {
                            // So sánh giá trị giữa 2 phần tử
                            int comparisonResult = Comparer<object>.Default.Compare(valueA, valueB);

                            // Hoán đổi các phần tử nếu cần
                            if ((ascending && comparisonResult > 0) || (!ascending && comparisonResult < 0))
                            {
                                // Hoán đổi dữ liệu giữa current và current.Next
                                T temp = current.Data;
                                current.Data = current.Next.Data;
                                current.Next.Data = temp;

                                swapped = true; // Đánh dấu là có sự thay đổi
                            }
                        }
                    }
                    current = current.Next; // Chuyển đến nút tiếp theo trong danh sách
                }
            }
            while (swapped); // Tiếp tục lặp cho đến khi không có sự thay đổi nào nữa

            // In ra thông báo về thứ tự sắp xếp
            Console.WriteLine($"Danh sách đã được sắp xếp theo thuộc tính: {propertyName}, thứ tự {(ascending ? "tăng dần" : "giảm dần")}");

            // Trả về danh sách đã sắp xếp
            return list;
        }


        /// <summary>
        /// Xóa một phần tử trong danh sách liên kết (SinglyLinkedList<T>) dựa trên giá trị của thuộc tính.
        /// Phương thức này sẽ duyệt qua danh sách và tìm phần tử có thuộc tính khớp với giá trị tìm kiếm.
        /// Nếu tìm thấy, nó sẽ xóa phần tử đó khỏi danh sách.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết (SinglyLinkedList<T>) chứa các đối tượng cần xóa.</param>
        /// <param name="propertyName">Tên thuộc tính dùng để tìm phần tử cần xóa.</param>
        /// <param name="searchValue">Giá trị của thuộc tính cần tìm và xóa phần tử.</param>
        /// <returns>Đối tượng đã xóa nếu tìm thấy, hoặc giá trị mặc định của kiểu T nếu không tìm thấy phần tử cần xóa.</returns>
        public T DeleteByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object searchValue)
        {
            // Kiểm tra nếu danh sách rỗng
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng. Không có phần tử để xóa.");
                return default;  // Trả về giá trị mặc định nếu danh sách rỗng
            }

            var node = list.Head;  // Khởi tạo node bắt đầu từ phần tử đầu tiên
            SinglyLinkedList<T>.Node previousNode = null;  // Khởi tạo biến để theo dõi nút trước đó
            bool found = false;  // Biến đánh dấu xem phần tử có được tìm thấy và xóa hay không

            // Duyệt qua các nút trong danh sách
            while (node != null)
            {
                // Dùng Reflection để lấy thông tin thuộc tính cần tìm
                var propertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    // Lấy giá trị của thuộc tính và so sánh với giá trị tìm kiếm
                    var propertyValue = GetValue(node.Data, propertyName);
                    if (propertyValue != null && propertyValue.Equals(searchValue))
                    {
                        // Nếu phần tử đầu tiên thì thay đổi Head
                        if (previousNode == null)
                        {
                            list.Head = node.Next;  // Thay đổi phần tử đầu tiên (Head) của danh sách
                        }
                        else
                        {
                            // Xoá phần tử giữa hoặc cuối
                            previousNode.Next = node.Next;  // Liên kết phần tử trước với phần tử sau phần tử cần xóa
                        }

                        Console.WriteLine($"Đã xóa phần tử với {propertyName} = {searchValue}");
                        found = true;  // Đánh dấu phần tử đã được xóa
                        break;  // Dừng vòng lặp sau khi tìm thấy và xóa phần tử
                    }
                }

                previousNode = node;  // Cập nhật previousNode thành node hiện tại
                node = node.Next;  // Chuyển đến nút tiếp theo trong danh sách
            }

            // Nếu không tìm thấy phần tử cần xóa
            if (!found)
            {
                Console.WriteLine($"❌ Không tìm thấy phần tử với {propertyName} = {searchValue}");
                return default;  // Trả về giá trị mặc định nếu không tìm thấy phần tử
            }
            else
            {
                return node.Data;  // Trả về đối tượng đã xóa (tức là đối tượng mà node hiện tại chứa)
            }
        }

        /// <summary>
        /// Tìm phần tử có giá trị lớn nhất theo thuộc tính được truyền vào.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách cần xử lý.</param>
        /// <param name="propertyName">Tên thuộc tính cần so sánh.</param>
        /// <returns>Phần tử có giá trị lớn nhất theo thuộc tính.</returns>
        public T FindMaxByAttributes<T>(SinglyLinkedList<T> list, string propertyName)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng.");
                return default;
            }

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
        /// Tìm phần tử có giá trị nhỏ nhất theo thuộc tính được truyền vào.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách cần xử lý.</param>
        /// <param name="propertyName">Tên thuộc tính cần so sánh.</param>
        /// <returns>Phần tử có giá trị nhỏ nhất theo thuộc tính.</returns>
        public T FindMinByAttributes<T>(SinglyLinkedList<T> list, string propertyName)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng.");
                return default;
            }

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
        /// Đếm số phần tử có giá trị thuộc tính bằng giá trị truyền vào.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách cần xử lý.</param>
        /// <param name="propertyName">Tên thuộc tính cần so sánh.</param>
        /// <param name="targetValue">Giá trị cần so sánh.</param>
        /// <returns>Số lượng phần tử thỏa mãn điều kiện.</returns>
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
        /// Tính trung bình cho thuộc tính trong danh sách liên kết đơn dựa trên điều kiện cho trước.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách.</typeparam>
        /// <param name="list">Danh sách đối tượng.</param>
        /// <param name="propertyName">Tên thuộc tính cần tính trung bình.</param>
        /// <param name="targetValue">Giá trị thuộc tính để so sánh.</param>
        /// <param name="propertyAverage">Giá trị thuộc tính cần tính trung bình (thực hiện với giá trị này).</param>
        /// <returns>Trung bình giá trị của thuộc tính.</returns>
        public double AverageByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue, string propertyAverage)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            var averageProperty = typeof(T).GetProperty(propertyAverage, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (averageProperty == null) return 0;

            int count = 0;
            double total = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null && value.Equals(targetValue))
                {
                    var averageValue = averageProperty.GetValue(node.Data);
                    if (averageValue != null)
                    {
                        total += Convert.ToDouble(averageValue);
                        count++;
                    }
                }
                node = node.Next;
            }

            return count > 0 ? total / count : 0;
        }

        /// <summary>
        /// Tính tổng cho thuộc tính trong danh sách liên kết đơn dựa trên điều kiện cho trước.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách.</typeparam>
        /// <param name="list">Danh sách đối tượng.</param>
        /// <param name="propertyName">Tên thuộc tính cần so sánh với giá trị mục tiêu.</param>
        /// <param name="targetValue">Giá trị thuộc tính để so sánh.</param>
        /// <param name="propertySum">Tên thuộc tính cần tính tổng.</param>
        /// <returns>Tổng giá trị của thuộc tính cần tính.</returns>
        public int SumByAttributes<T>(SinglyLinkedList<T> list, string propertyName, object targetValue, string propertySum)
        {
            if (list == null || list.Head == null) return 0;

            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;

            var sumProperty = typeof(T).GetProperty(propertySum, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (sumProperty == null) return 0;

            int total = 0;
            var node = list.Head;

            while (node != null)
            {
                var value = property.GetValue(node.Data);
                if (value != null && value.Equals(targetValue))
                {
                    var sumValue = sumProperty.GetValue(node.Data);
                    if (sumValue != null)
                    {
                        total += Convert.ToInt32(sumValue);
                    }
                }
                node = node.Next;
            }

            return total;
        }

        /// <summary>
        /// Đếm số phần tử trong danh sách liên kết (SinglyLinkedList<T>) theo từng nhóm thuộc tính.
        /// Phương thức này sẽ duyệt qua danh sách và nhóm các phần tử theo giá trị của một thuộc tính cụ thể.
        /// Sau đó, nó sẽ đếm số lượng phần tử trong mỗi nhóm và trả về kết quả dưới dạng một từ điển (Dictionary).
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết cần xử lý.</param>
        /// <param name="propertyName">Tên thuộc tính dùng để nhóm các phần tử.</param>
        /// <returns>Dictionary với key là giá trị thuộc tính và value là số lượng phần tử trong nhóm đó.</returns>
        public Dictionary<string, int> CountByGroup<T>(SinglyLinkedList<T> list, string propertyName)
        {
            // Khởi tạo một dictionary để lưu trữ các nhóm và số lượng phần tử trong nhóm
            Dictionary<string, int> data = new Dictionary<string, int>();

            // Kiểm tra nếu danh sách rỗng
            if (list == null || list.Head == null) return data;

            // Sử dụng Reflection để lấy thông tin thuộc tính từ kiểu T
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return data;  // Nếu không tìm thấy thuộc tính, trả về dictionary rỗng

            var node = list.Head;  // Bắt đầu duyệt từ phần tử đầu tiên trong danh sách

            // Duyệt qua danh sách
            while (node != null)
            {
                // Lấy giá trị thuộc tính cần nhóm và chuyển thành chuỗi
                var key = property.GetValue(node.Data)?.ToString();

                // Kiểm tra nếu giá trị thuộc tính không phải null hoặc rỗng
                if (!string.IsNullOrEmpty(key))
                {
                    // Kiểm tra nếu nhóm đã tồn tại trong dictionary
                    if (!data.ContainsKey(key))
                        data[key] = 1;  // Nếu nhóm chưa có, thêm nhóm vào và đặt số lượng là 1
                    else
                        data[key]++;  // Nếu nhóm đã có, tăng số lượng phần tử trong nhóm
                }
                node = node.Next;  // Chuyển đến nút tiếp theo trong danh sách
            }

            return data;  // Trả về dictionary với các nhóm và số lượng phần tử trong mỗi nhóm
        }

        /// <summary>
        /// Lọc danh sách liên kết (SinglyLinkedList<T>) theo thuộc tính và khoảng giá trị (min <= value <= max).
        /// Phương thức này duyệt qua danh sách và chỉ giữ lại các phần tử có giá trị thuộc tính nằm trong khoảng từ `min` đến `max`.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết cần lọc.</param>
        /// <param name="propertyName">Tên thuộc tính cần lọc.</param>
        /// <param name="min">Giá trị tối thiểu của thuộc tính cần lọc.</param>
        /// <param name="max">Giá trị tối đa của thuộc tính cần lọc.</param>
        /// <returns>Danh sách liên kết (SinglyLinkedList<T>) chứa các phần tử có giá trị thuộc tính nằm trong khoảng min và max.</returns>
        public SinglyLinkedList<T> FilterByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max)
        {
            // Tạo danh sách liên kết mới để lưu các phần tử đã lọc
            SinglyLinkedList<T> filteredList = new SinglyLinkedList<T>();

            // Kiểm tra nếu danh sách rỗng
            if (list == null || list.Head == null) return filteredList;

            // Sử dụng Reflection để lấy thuộc tính cần lọc từ kiểu T
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return filteredList;  // Nếu không tìm thấy thuộc tính, trả về danh sách trống

            var node = list.Head;  // Khởi tạo node bắt đầu từ phần tử đầu tiên trong danh sách

            // Duyệt qua các phần tử trong danh sách
            while (node != null)
            {
                // Lấy giá trị thuộc tính cần lọc
                var value = property.GetValue(node.Data);

                if (value != null)
                {
                    // Chuyển giá trị thuộc tính thành kiểu double và kiểm tra nếu trong khoảng giá trị min và max
                    double numericValue = Convert.ToDouble(value);
                    if (numericValue >= min && numericValue <= max)
                    {
                        // Nếu giá trị thuộc tính nằm trong khoảng min và max, thêm phần tử vào danh sách đã lọc
                        filteredList.Add(node.Data);
                    }
                }

                // Chuyển đến nút tiếp theo trong danh sách
                node = node.Next;
            }

            return filteredList;  // Trả về danh sách các phần tử đã lọc
        }

        /// <summary>
        /// Tính tổng giá trị của một thuộc tính trong danh sách liên kết (SinglyLinkedList<T>) theo từng nhóm thuộc tính.
        /// Phương thức này duyệt qua danh sách và nhóm các phần tử theo giá trị của một thuộc tính cụ thể.
        /// Sau đó, nó tính tổng giá trị của một thuộc tính khác trong mỗi nhóm và trả về kết quả dưới dạng một từ điển (Dictionary).
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết cần xử lý.</param>
        /// <param name="groupByProperty">Tên thuộc tính dùng để nhóm các phần tử.</param>
        /// <param name="sumProperty">Tên thuộc tính cần tính tổng trong mỗi nhóm.</param>
        /// <returns>Dictionary với key là giá trị thuộc tính dùng để nhóm, và value là tổng giá trị thuộc tính cần tính tổng trong mỗi nhóm.</returns>
        public Dictionary<string, double> SumByGroup<T>(SinglyLinkedList<T> list, string groupByProperty, string sumProperty)
        {
            // Tạo một dictionary để lưu trữ tổng giá trị cho mỗi nhóm
            Dictionary<string, double> result = new Dictionary<string, double>();

            // Kiểm tra nếu danh sách rỗng
            if (list == null || list.Head == null) return result;

            // Sử dụng Reflection để lấy thuộc tính cần nhóm
            var groupProp = typeof(T).GetProperty(groupByProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            // Sử dụng Reflection để lấy thuộc tính cần tính tổng
            var valueProp = typeof(T).GetProperty(sumProperty, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            // Kiểm tra nếu không tìm thấy một trong các thuộc tính
            if (groupProp == null || valueProp == null) return result;

            var node = list.Head;  // Bắt đầu duyệt từ phần tử đầu tiên trong danh sách

            // Duyệt qua danh sách
            while (node != null)
            {
                // Lấy giá trị của thuộc tính nhóm (groupByProperty)
                var key = groupProp.GetValue(node.Data)?.ToString();
                // Lấy giá trị của thuộc tính cần tính tổng (sumProperty)
                var value = valueProp.GetValue(node.Data);

                // Kiểm tra nếu giá trị thuộc tính nhóm và thuộc tính cần tính tổng hợp lệ
                if (!string.IsNullOrEmpty(key) && value != null)
                {
                    double numericValue = Convert.ToDouble(value);  // Chuyển giá trị thành kiểu double

                    // Kiểm tra nếu nhóm đã tồn tại trong dictionary, nếu không tạo nhóm mới
                    if (!result.ContainsKey(key))
                        result[key] = numericValue;  // Nếu nhóm chưa có, khởi tạo nhóm với giá trị tính tổng
                    else
                        result[key] += numericValue;  // Nếu nhóm đã có, cộng dồn tổng giá trị thuộc tính
                }

                node = node.Next;  // Chuyển đến nút tiếp theo trong danh sách
            }

            return result;  // Trả về dictionary chứa tổng giá trị theo từng nhóm
        }

        /// <summary>
        /// Đếm số phần tử trong danh sách liên kết (SinglyLinkedList<T>) có giá trị thuộc tính nằm trong khoảng từ min đến max (min <= value <= max).
        /// Phương thức này duyệt qua danh sách và kiểm tra nếu giá trị của thuộc tính nằm trong khoảng cho trước, sau đó đếm số lượng phần tử thỏa mãn điều kiện.
        /// </summary>
        /// <typeparam name="T">Kiểu của đối tượng trong danh sách liên kết.</typeparam>
        /// <param name="list">Danh sách liên kết cần xử lý.</param>
        /// <param name="propertyName">Tên thuộc tính cần kiểm tra.</param>
        /// <param name="min">Giá trị tối thiểu của thuộc tính cần kiểm tra.</param>
        /// <param name="max">Giá trị tối đa của thuộc tính cần kiểm tra.</param>
        /// <returns>Số lượng phần tử có giá trị thuộc tính nằm trong khoảng từ min đến max.</returns>
        public int CountByRange<T>(SinglyLinkedList<T> list, string propertyName, double min, double max)
        {
            // Kiểm tra nếu danh sách rỗng
            if (list == null || list.Head == null) return 0;

            // Sử dụng Reflection để lấy thuộc tính cần kiểm tra
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property == null) return 0;  // Nếu không tìm thấy thuộc tính, trả về 0

            int count = 0;  // Biến đếm số phần tử thỏa mãn điều kiện
            var node = list.Head;  // Bắt đầu duyệt từ phần tử đầu tiên trong danh sách

            // Duyệt qua danh sách
            while (node != null)
            {
                // Lấy giá trị thuộc tính cần kiểm tra
                var value = property.GetValue(node.Data);

                if (value != null)
                {
                    // Chuyển giá trị thuộc tính thành kiểu double và kiểm tra nếu nằm trong khoảng min và max
                    double numericValue = Convert.ToDouble(value);
                    if (numericValue >= min && numericValue <= max)
                    {
                        count++;  // Tăng số lượng phần tử thỏa mãn điều kiện
                    }
                }
                node = node.Next;  // Chuyển đến nút tiếp theo trong danh sách
            }

            return count;  // Trả về số lượng phần tử thỏa mãn điều kiện
        }


    }
}
