using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanHo.Models
{
    public class CanHoModel
    {
        private string maCH;
        private string tenCH;

        public CanHoModel()
        {
        }

        public CanHoModel(string maCH, string tenCH)
        {
            this.MaCH = maCH;
            this.TenCH = tenCH;
        }

        public string MaCH { get => maCH; set => maCH = value; }
        public string TenCH { get => tenCH; set => tenCH = value; }
    }
}
