MenuHocSinh menuHS = new MenuHocSinh();
menuHS.LoadDSHS();
menuHS.HienThiChucNang();


while (true)
{
  int Chon = menuHS.ChonChucNang();
  switch (Chon)
  {
    case 1:
      {
        menuHS.ThemHocSinh();
      };
      break;
    case 2:
      {
        menuHS.TimKiemHocSinh();
      };
      break;
    case 3:
      {
        menuHS.CapNhatDiemSo();
      };
      break;
    case 4:
      {
        menuHS.XoaHocSinh();
      };
      break;
    case 5:
      {
        menuHS.HienThiDanhSach();
      };
      break;
    case 6:
      {
        menuHS.HienThiHocSinhTheoDiemTrungBinh();
      };
      break;
    case 7:
      {
        menuHS.HienThiHocSinhTheoTen();
      };
      break;
    case 8:
      {
        menuHS.LuuDSHS();
      };
      break;

    case 9:
      {
        menuHS.LoadDSHS();
      };
      break;
  }

  if (Chon == 10)
  {
    break;
  }

  menuHS.HienThiChucNang();
}