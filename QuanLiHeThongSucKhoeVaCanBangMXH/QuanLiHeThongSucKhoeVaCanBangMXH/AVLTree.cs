using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class AVLTree
    {
        public Node Root { get; private set; }
        public AVLTree()
        {
            Root = null;
        }
        private int height(Node node)
        {
            return node == null ? 0 : node.height;
        }

        private int GetBalance(Node node)
        {
            return node == null ? 0 : height(node.Left) - height(node.Right);

        }
        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            y.height = 1 + Math.Max(height(y.Left), height(y.Right));

            return y;
        }
        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.height = 1 + Math.Max(height(y.Left), height(y.Right));
            x.height = 1 + Math.Max(height(x.Left), height(x.Right));
            return x;
        }
        public Node Insert(Node node, NguoiDung data)
        {
            if (node == null)
                return new Node(data);
            if (string.Compare(data.ten, node.Data.ten, StringComparison.OrdinalIgnoreCase) < 0)
                node.Left = Insert(node.Left, data);
            else if (string.Compare(data.ten, node.Data.ten, StringComparison.OrdinalIgnoreCase) > 0)
                node.Right = Insert(node.Right, data);
            else
                return node;

            node.height = 1 + Math.Max(height(node.Left), height(node.Right));
            int balance = GetBalance(node);
            //Trái Trái
            if (balance > 1 && string.Compare(data.ten, node.Left.Data.ten, StringComparison.OrdinalIgnoreCase) < 0)
                return RotateRight(node);
            //Phải Phải
            if (balance < -1 && string.Compare(data.ten, node.Right.Data.ten, StringComparison.OrdinalIgnoreCase) > 0)
                return RotateLeft(node);
            //Trái Phải
            if (balance > 1 && string.Compare(data.ten, node.Left.Data.ten, StringComparison.OrdinalIgnoreCase) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }
            //Phải Trái
            if (balance < -1 && string.Compare(data.ten, node.Right.Data.ten, StringComparison.OrdinalIgnoreCase) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }
            return node;
        }
        public NguoiDung Search(Node node, string ten)
        {
            if (node == null)
                return null;
            if (string.Equals(ten, node.Data.ten, StringComparison.OrdinalIgnoreCase))
                return node.Data;
            if (string.Compare(ten, node.Data.ten, StringComparison.OrdinalIgnoreCase) < 0)
                return Search(node.Left, ten);
            else
                return Search(node.Right, ten);
        }
        public void InOrder(Node node, List<NguoiDung> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.Data);
                InOrder(node.Right, list);
            }
        }
        public void Insert(NguoiDung data)
        {
            Root = Insert(Root, data);
        }
        public void SaveToText(Node node, string path)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                SaveToTextRecursive(node, sw);
            }
        }

        private void SaveToTextRecursive(Node node, StreamWriter sw)
        {
            if (node == null) return;
            SaveToTextRecursive(node.Left, sw);
            sw.WriteLine($"{node.Data.ten},{node.Data.diemSucKhoeTamThan}, {node.Data.thoiGianMXH},...)");
            SaveToTextRecursive(node.Right, sw);
        }

        public void SaveToBinary(Node node, string path)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                SaveToBinaryRecursive(node, bw);
            }    
        }

        private void SaveToBinaryRecursive(Node node, BinaryWriter bw)
        {
            if (node == null) return;
            SaveToBinaryRecursive(node.Left, bw);
            bw.Write(node.Data.ten);
            bw.Write(node.Data.tuoi);
            bw.Write(node.Data.gioiTinh);
            bw.Write(node.Data.thoiGianMXH);
            bw.Write(node.Data.diemSucKhoeTamThan);
            SaveToBinaryRecursive(node.Right, bw);
        }
    }
}
