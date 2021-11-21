using System;
using System.Collections.Generic;

#nullable disable

namespace DeTaiCovid.Model
{
    public partial class ChuDe
    {
        public ChuDe()
        {
            BaiViets = new HashSet<BaiViet>();
        }

        public int ChuDeid { get; set; }
        public string TenChuDe { get; set; }
        public int SoLuongBaiViet { get; set; }

        public virtual ICollection<BaiViet> BaiViets { get; set; }
    }
}
