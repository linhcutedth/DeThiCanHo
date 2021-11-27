using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanHo.Models
{
    public class NhanVienModel
    {
        private string maNV;
        private string tenNV;
        private string soDT;
        private string gTinh;

        public NhanVienModel()
        {
        }

        public NhanVienModel(string maNV, string tenNV, string soDT, string gTinh)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.SoDT = soDT;
            this.GTinh = gTinh;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string GTinh { get => gTinh; set => gTinh = value; }

        public int SoLan { get; set; }
    }
}
