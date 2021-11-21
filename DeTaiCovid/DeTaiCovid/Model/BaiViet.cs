using System;
using System.Collections.Generic;

#nullable disable

namespace DeTaiCovid.Model
{
    public partial class BaiViet
    {
        public int BaiVietId { get; set; }
        public string TieuDe { get; set; }
        public string MoTa { get; set; }
        public string NoiDung { get; set; }
        public int? ChuDeid { get; set; }
        public string Anh { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual ChuDe ChuDe { get; set; }
    }
}
