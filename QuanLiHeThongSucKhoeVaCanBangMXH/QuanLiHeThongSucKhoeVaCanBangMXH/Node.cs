using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class Node
    {
        public NguoiDung Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public int height { get; set; }
        public Node (NguoiDung data)
        {
            Data = data;
            Left = null;
            Right = null;
            height = 1;
        }
    }
}
