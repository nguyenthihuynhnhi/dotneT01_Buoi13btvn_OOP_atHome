class HocSinh
{
  public static int id { get; set; }
  public int MaHocSinh { get; set; }
  public string? TenHocSinh { get; set; }
  public double DiemToan { get; set; }
  public double DiemVan { get; set; }
  public double DiemAnh { get; set; }

  public HocSinh()
  {
  }

  public void NhapThongTin()
  {
    MaHocSinh = id;

    Console.WriteLine("Nhập Họ Tên Học Sinh");
    TenHocSinh = Console.ReadLine();

    Console.WriteLine("Nhập Điểm Toán");
    DiemToan = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Nhập Điểm Văn");
    DiemVan = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Nhập Điểm Anh");
    DiemAnh = Convert.ToDouble(Console.ReadLine());

    id++;
  }

  public void XuatThongTin()
  {
    Console.WriteLine(@$"
            --------- Thông tin học sinh: {TenHocSinh} -------------
            Mã số: {MaHocSinh}
            Họ tên: {TenHocSinh}
            Điểm Toán : {DiemToan}
            Điểm Văn: {DiemVan}
            Điểm Anh : {DiemAnh}
            Điểm trung bình: {TinhDiemTB()}
            Xếp loại: {XepLoai()}
        ");
  }

  public double TinhDiemTB()
  {
    double DiemTb = (DiemToan + DiemVan + DiemAnh) / 3;
    return DiemTb;
  }

  public string XepLoai()
  {
    double DiemTb = TinhDiemTB();

    if (DiemTb < 5)
    {
      return "Yếu";
    }
    else if (DiemTb >= 5 && DiemTb <= 6.5)
    {
      return "Trung bình";
    }
    else if (DiemTb > 6.5 && DiemTb <= 8)
    {
      return "Khá";
    }
    else
    {
      return "Giỏi";
    }
  }

  public string GetLastName()
  {
    string[] arr = TenHocSinh.Split(" ");
    return arr.Last();
  }
}