using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.DataStructures
{
    public class SinglyLinkedList<T>
    {
        public class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        public Node Head { get; set; }

        public SinglyLinkedList()
        {
            Head = null;
        }

        // Thêm phần tử vào danh sách
        public void Add(T data)
        {
            Node newNode = new Node(data);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                Node current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // In toàn bộ danh sách
        public void PrintAll()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        /// <summary>
        /// Tìm kiếm các đối tượng trong danh sách liên kết đơn
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"> Danh sách cần tìm</param>
        /// <param name="thuocTinh">Thuộc tính cần tìm</param>
        /// <param name="giaTriCanTim">Giá trị cần so sánh</param>
        /// <returns>Đối tượng cần tìm có trong danh sách</returns>
        public T SearchObjectByAttribute<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim)
        {
            var node = list.Head;

            while (node != null)
            {
                // Dùng Reflection để lấy giá trị của thuộc tính
                var propertyInfo = typeof(T).GetProperty(thuocTinh, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính và so sánh
                    var propertyValue = propertyInfo.GetValue(node.Data);
                    if (propertyValue != null && propertyValue.Equals(giaTriCanTim)) // Đối với các loại dữ liệu khác, dùng Equals
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
        /// <param name="thuocTinh">Thuộc tính cần tìm</param>
        /// <param name="giaTriCanTim">Giá trị cần so sánh</param>
        /// <returns>Danh sách đối tượng cần tìm có trong danh sách</returns>
        public SinglyLinkedList<T> SearchObjectListByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim)
        {
            var node = list.Head;
            SinglyLinkedList<T> foundItems = new SinglyLinkedList<T>();

            while (node != null)
            {
                // Dùng Reflection để lấy giá trị của thuộc tính
                var propertyInfo = typeof(T).GetProperty(thuocTinh, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính
                    var propertyValue = propertyInfo.GetValue(node.Data);

                    // Kiểm tra nếu thuộc tính không phải null
                    if (propertyValue != null)
                    {
                        // Nếu thuộc tính là chuỗi, dùng Contains để tìm kiếm
                        if (propertyValue is string propertyString && giaTriCanTim is string searchString)
                        {
                            if (propertyString.Contains(searchString, StringComparison.OrdinalIgnoreCase)) // So sánh không phân biệt chữ hoa/thường
                            {
                                foundItems.Add(node.Data);
                            }
                        }
                        else if (propertyValue.Equals(giaTriCanTim)) // Đối với các loại dữ liệu khác, dùng Equals
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
        /// <param name="thuocTinh">Thuộc tính muốn sắp xếp</param>
        /// <param name="ascending">true (tăng dần) || false (Giảm dần) </param>
        /// <returns></returns>
        public SinglyLinkedList<T> SortByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, bool ascending = true)
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
                    var propertyInfo = typeof(T).GetProperty(thuocTinh, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

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

            Console.WriteLine($"Danh sách đã được sắp xếp theo thuộc tính: {thuocTinh}, thứ tự {(ascending ? "tăng dần" : "giảm dần")}");
            // Trả về danh sách đã sắp xếp
            return list;
        }

        public void RemoveByAttributes<T>(SinglyLinkedList<T> list, string thuocTinh, object giaTriCanTim)
        {
            if (list == null || list.Head == null)
            {
                Console.WriteLine("Danh sách rỗng. Không có phần tử để xóa.");
                return;
            }

            var node = list.Head;
            SinglyLinkedList<T>.Node previousNode = null;
            bool found = false;

            // Duyệt qua danh sách
            while (node != null)
            {
                // Dùng Reflection để lấy giá trị thuộc tính
                var propertyInfo = typeof(T).GetProperty(thuocTinh, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propertyInfo != null)
                {
                    // Lấy giá trị thuộc tính và so sánh
                    var propertyValue = propertyInfo.GetValue(node.Data);
                    if (propertyValue != null && propertyValue.Equals(giaTriCanTim))
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

                        Console.WriteLine($"Đã xóa phần tử với {thuocTinh} = {giaTriCanTim}");
                        found = true;
                        break; // Dừng khi đã xóa xong
                    }
                }

                previousNode = node;
                node = node.Next;
            }

            if (!found)
            {
                Console.WriteLine($"❌ Không tìm thấy phần tử với {thuocTinh} = {giaTriCanTim}");
            }
        }
    }
}
