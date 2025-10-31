using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiHeThongSucKhoeVaCanBangMXH
{
    internal class NguoiDung
    {
        public string ten {  get; set; }
        public int tuoi {  get; set; }
        public string gioiTinh { get; set; }
        public double thoiGianMXH { get; set; }
        public double diemSucKhoeTamThan {  get; set; }
        public NguoiDung(string ten, int tuoi, string gioiTinh, double thoiGianMXH, double diemSucKhoeTamThan)
        {
            this.ten = ten;
            this.tuoi = tuoi;
            this.gioiTinh = gioiTinh;
            this.thoiGianMXH = thoiGianMXH;
            this.diemSucKhoeTamThan = diemSucKhoeTamThan;
        }
        public override string ToString()
        {
            return $"{ten} ({tuoi}t, {gioiTinh}) - MXH: {thoiGianMXH}h Sức Khỏe: {diemSucKhoeTamThan}";
        }
    }
}
