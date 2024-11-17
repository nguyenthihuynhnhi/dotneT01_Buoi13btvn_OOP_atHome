class DonHang
{
  public static int idDonHang { get; set; }
  public int MaDonHang { get; set; }
  public int MaSanPham { get; set; }
  public int SoLuongBan { get; set; }
  public string? TenNguoiDat { get; set; }
  public bool DaGiao { get; set; }


  public DonHang()
  {
    DaGiao = false;
  }

  public void NhapThongTinDH()
  {
    MaDonHang = idDonHang;

    Console.WriteLine("Nhập mã sản phẩm: ");
    MaSanPham = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Nhập số lượng bán: ");
    SoLuongBan = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Nhập tên người đặt: ");
    TenNguoiDat = Console.ReadLine();

    idDonHang++;
  }

  public void XuatThongTinDH()
  {
    Console.WriteLine(@$"
      Ma don hang: {MaDonHang}
      Ma san pham: {MaSanPham}
      So luong ban: {SoLuongBan}
      Ten nguoi dat: {TenNguoiDat}
      Da giao: {DaGiao}
    ");
  }

}