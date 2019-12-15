using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuangDemoAPI
{
    public class ThongBao
    {
        public ThongBao(int soLoi, string noidung)
        {
            this.soLoi = soLoi;
            this.noidung = noidung;
        }

        public int soLoi { get; set; }
        public string noidung { get; set; }
        
    }
}
