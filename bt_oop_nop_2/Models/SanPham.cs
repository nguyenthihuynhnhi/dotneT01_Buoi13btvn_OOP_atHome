class SanPham
{
  public static int Id = 1;

  public int MaSanPham { get; set; }
  public string? TenSanPham { get; set; }
  public double GiaBan { get; set; }
  public int SoLuongTonKho { get; set; }

  public SanPham()
  {

  }
  public void NhapThongTinSP()
  {
    MaSanPham = Id;

    Console.WriteLine("Nhập tên sản phẩm: ");
    TenSanPham = Console.ReadLine();

    Console.WriteLine("Nhập giá bán: ");
    GiaBan = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Nhập số lượng sản phẩm tồn kho: ");
    SoLuongTonKho = Convert.ToInt32(Console.ReadLine());

    Id++;
  }
  public void XuatThongTin()
  {
    Console.WriteLine(@$"
      Ma san pham: {MaSanPham}
      Ten san pham: {TenSanPham}
      Gia ban: {GiaBan}
      So luong ton kho: {SoLuongTonKho}
    ");
  }

  public string GetLastName()
  {
    string[] arr = TenSanPham.Split(" ");
    return arr.Last();
  }
}