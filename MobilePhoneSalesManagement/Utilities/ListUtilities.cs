using MobilePhoneSalesManagement.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneSalesManagement.Utilities
{
    public class ListUtilities
    {
        // Tìm giá trị Min cho thuộc tính
        public static void TimMinTheoThuocTinh<T>(SinglyLinkedList<T> list, string thuocTinh)
        {
            var node = list.Head;
            bool found = false;
            double minValue = double.MaxValue;
            T minItem = default;

            while (node != null)
            {
                // Dùng Reflection để lấy giá trị của thuộc tính
                var propertyInfo = typeof(T).GetProperty(thuocTinh, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(node.Data);
                    if (propertyValue != null)
                    {
                        double value = Convert.ToDouble(propertyValue);

                        // Tìm giá trị min
                        if (value < minValue)
                        {
                            minValue = value;
                            minItem = node.Data;
                            found = true;
                        }
                    }
                }
                node = node.Next;
            }

            if (found)
            {
                Console.WriteLine($"\n📈 Giá trị nhỏ nhất theo {thuocTinh}: {minValue} ({minItem})");
            }
            else
            {
                Console.WriteLine($"❌ Không tìm thấy phần tử nào với thuộc tính {thuocTinh}");
            }
        }
    }
}
