using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanHo.Models
{
    public class NV_BT
    {
        private string maNV;
        private string maTB;
        private string maCH;
        private int lanThu;
        private DateTime ngBT;

        public NV_BT()
        {
        }

        public NV_BT(string maNV, string maTB, string maCH, int lanThu, DateTime ngBT)
        {
            this.MaNV = maNV;
            this.MaTB = maTB;
            this.MaCH = maCH;
            this.LanThu = lanThu;
            this.NgBT = ngBT;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string MaTB { get => maTB; set => maTB = value; }
        public string MaCH { get => maCH; set => maCH = value; }
        public int LanThu { get => lanThu; set => lanThu = value; }
        public DateTime NgBT { get => ngBT; set => ngBT = value; }
    }
}
