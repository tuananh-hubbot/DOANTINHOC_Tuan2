using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    public partial class MainForm : Form
    {
        private AVLTree cayNguoiDung = new AVLTree();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDocCSV_Click(object sender, EventArgs e)
        {
            string filePath = @"E:\\DOANTINHOC\\QuanLiHeThongSucKhoeVaCanBangMXH\\QuanLiHeThongSucKhoeVaCanBangMXH\\Dataset.csv";
            if(!File.Exists(filePath))
            {
                MessageBox.Show("Không tìm thấy file CSV" + filePath);
                return;
            }
            //1. Đọc dữ liệu từ CSV
            List<NguoiDung> dsNguoiDung = DocFileCSV(filePath);

            //2.Chèn từng người dùng vào AVL
            foreach (var nd in dsNguoiDung) 
            {
                cayNguoiDung.Insert(nd);
            }

            //3.Duyệt cây(in-order) để lấy danh sách người dùng
            List<NguoiDung> dsSapXep = new List<NguoiDung>();
            cayNguoiDung.InOrder(cayNguoiDung.Root, dsSapXep);

            //4.Ghi file text và binary (Hàm đã có trong AVLTree)
            cayNguoiDung.SaveToText(cayNguoiDung.Root, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_clean.txt"));
            cayNguoiDung.SaveToBinary(cayNguoiDung.Root, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data_clean.bin"));

            //5.Hiện thị lên DataGridView - dgvKetQua
            dgvKetQua.DataSource = null;
            dgvKetQua.DataSource = dsSapXep;

            MessageBox.Show("Đã đọc CSV, lưu cây và ghi file sạch thành công!");
        }
        //Hàm đọc CSV - sửa theo cấu trúc file csv thực tế
        private List<NguoiDung> DocFileCSV(string path)
        {
            var ds = new List<NguoiDung>();

            //Đọc tất cả dòng, bỏ dòng tiêu đề
            var allLines = File.ReadAllLines(path); ;
            if (allLines.Length <= 1) return ds;

            //Giả sử file có tiêu đề ở dòng 0
            foreach ( var raw in allLines.Skip(1))
            {
                if(string.IsNullOrWhiteSpace(raw)) continue;
                //Tách theo dấu phẩy đơn giản
                var parts = raw.Split(',');

                //Kiểm tra đủ cột (ở đây giả sử bạn có 5 cột)
                if(parts.Length < 5 ) continue;

                try
                {
                    string ten = parts[0].Trim();
                    int tuoi = int.TryParse(parts[1].Trim(), out int t) ? t : 0;
                    string gioiTinh = parts[2].Trim();
                    double thoiGianMXH = double.TryParse(parts[3].Trim(), out double tg) ? tg : 0.0;
                    double diem = double.TryParse(parts[4].Trim(), out double d) ? d : 0.0;

                    var nd = new NguoiDung(ten, tuoi, gioiTinh, thoiGianMXH, diem);
                    ds.Add(nd);
                }
                catch 
                {
                    //nếu 1 dòng lỗi thì bỏ qua để chương trình không crash
                    continue;
                }
            }
            return ds;
        }
        //-Nếu muốn bổ sung OpenFileDialog để chọn file bằng giao diện
        private void btnDocFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV file (*.csv)|*.csv|All files (*.*)|*.*";
            ofd.Title = "Chọn file dữ liệu CSV";

            if(ofd.ShowDialog() == DialogResult.OK )
            {
                string filePath = ofd.FileName;

                if(!File.Exists(filePath)) 
                {
                    MessageBox.Show("Không tìm thấy file CSV: " + filePath);
                    return;
                }
                List<NguoiDung> dsNguoiDung = DocFileCSV(filePath);

                if (dsNguoiDung != null && dsNguoiDung.Count > 0)
                {
                    dgvKetQua.DataSource = dsNguoiDung;
                    MessageBox.Show("Đọc dữ liệu thành công!");
                }
                else
                {
                    MessageBox.Show("File không có dữ liệu hoặc đọc lỗi!");
                }
            }
        }   
    }
}
