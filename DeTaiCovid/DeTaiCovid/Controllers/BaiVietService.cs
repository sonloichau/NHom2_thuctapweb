using DeTaiCovid.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeTaiCovid.Controllers

{
    public class BaiVietService
    {
        private TinTucCovidContext DbContext = new TinTucCovidContext();

        public List<BaiViet> LayDSBaiViet()
        {
            return DbContext.BaiViets.ToList();
        }
        
        public bool ThemBaiViet(BaiViet newBaiViet)
        {

            ChuDe currentChuDe = DbContext.ChuDes.SingleOrDefault(x => x.ChuDeid == newBaiViet.ChuDeid);
            if (currentChuDe == null)
            {
                return false;
            }
            else
            {
                DbContext.BaiViets.Add(newBaiViet);
                CapNhapSoLuong(currentChuDe);
                DbContext.SaveChanges();
                return true;
            }
           


        }
        public bool SuaBaiViet(BaiViet baiviet)
        {
            BaiViet currentBaiViet = DbContext.BaiViets.SingleOrDefault(x => x.BaiVietId == baiviet.BaiVietId);
            ChuDe currentChuDe = DbContext.ChuDes.SingleOrDefault(x => x.ChuDeid == baiviet.BaiVietId);
            if (currentBaiViet == null || currentChuDe == null)
            {
                return false;
            }
            else
            {
                currentBaiViet.TieuDe = baiviet.TieuDe;
                currentBaiViet.MoTa = baiviet.MoTa;
                currentBaiViet.NoiDung = baiviet.NoiDung;
                currentBaiViet.Anh = baiviet.Anh;
                currentBaiViet.NgayTao = baiviet.NgayTao;
                DbContext.BaiViets.Update(currentBaiViet);
                DbContext.SaveChanges();
                return true;
            }

        }
        public bool XoaBaiViet(BaiViet hocsinh)
        {

            BaiViet CurrentBaiViet = DbContext.BaiViets.SingleOrDefault(x => x.BaiVietId == hocsinh.BaiVietId);
            ChuDe currentChuDe = DbContext.ChuDes.SingleOrDefault(x => x.ChuDeid == hocsinh.ChuDeid);
            if (CurrentBaiViet == null)
            {
                return false;
            }
            else
            {
                DbContext.Remove(CurrentBaiViet);
                DbContext.SaveChanges();
                CapNhapSoLuong(cu);

                return true;
            }

        }
        public void CapNhapSoLuong(ChuDe currentChuDe)
        {
            List<BaiViet> lstChuDe = DbContext.BaiViets.ToList();
            int dem = 0;
            for (int i = 0; i < lstChuDe.Count; i++)
            {
                if (lstChuDe[i].ChuDeid == currentChuDe.ChuDeid)
                {
                    dem++;
                }

            }
            currentChuDe.SoLuongBaiViet = dem;
            DbContext.Update(currentChuDe);
            DbContext.SaveChanges();
        }
    }
}
