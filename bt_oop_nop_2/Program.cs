MenuSanPhamVaDonHang menu = new MenuSanPhamVaDonHang();
menu.LoadDSSP();
menu.HienThiChucNang();

while (true)
{
  int chon = menu.ChonChucNang();
  switch (chon)
  {
    case 1:
      {
        menu.ThemSanPham();
      };
      break;
    case 2:
      {
        menu.TimKiemSanPhamTheoTen();
      };
      break;
    case 3:
      {
        menu.CapNhatGiaBanHoacTonKho();
      };
      break;
    case 4:
      {
        menu.TinhTongGiaTriKhoHang();
      };
      break;
    case 5:
      {
        menu.XoaSanPham();
      };
      break;
    case 6:
      {
        menu.HienThiDanhSachSPCungTongGiaTriKhoHang();
      };
      break;
    case 7:
      {
        menu.HienThiGiaBanTangDan();
      };
      break;
    case 8:
      {
        menu.SapXepSPTheoTen();
      };
      break;
    case 11:
      {
        Console.WriteLine("Chương trình kết thúc. Tạm biệt!");
        return; // Thoát khỏi phương thức Main, dừng chương trình
      };
    case 12:
      {
        menu.ThemDonHang();
      };
      break;
    case 13:
      {
        menu.HienThiDanhSachDH();
      };
      break;
    case 14:
      {
        menu.CapNhatTrangThaiGiaoHang();
      };
      break;
    case 15:
      {
        menu.XoaDonHang();
      };
      break;
  }

  menu.HienThiChucNang();

}
