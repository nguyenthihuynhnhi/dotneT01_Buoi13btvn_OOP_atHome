using System.Text.Json;

class MenuHocSinh
{
  public int chon { get; set; }
  public List<HocSinh> lstHocSinh = new List<HocSinh>();

  public void HienThiChucNang()
  {
    Console.WriteLine(@"
    ------------------Quản lý học viên------------------
            1/ Thêm thông tin học sinh
            2/ Tìm kiếm học sinh dựa theo tên
            3/ Cập nhật điểm số học sinh
            4/ Xóa học sinh khỏi danh sách
            5/ Hiển thị danh sách học sinh kèm xếp loại học lực
            6/ Hiển thị học sinh theo điểm trung bình tăng dần
            7/ Hiển thị học sinh theo tên
            8/ Lưu dữ liệu vào file
            9/ Đọc dữ liệu từ file
            10/ Thoát
        ");
  }

  public int ChonChucNang()
  {
    Console.WriteLine("Hãy chọn Chức năng: ");
    chon = Convert.ToInt32(Console.ReadLine());
    return chon;
  }

  // 1. Thêm thông tin học sinh
  public void ThemHocSinh()
  {
    //1. Khởi tạo 1 đối tượng học viên
    HocSinh hsNew = new HocSinh();
    //2. Nhập thông tin học viên
    hsNew.NhapThongTin();
    //3. Thêm học viên vào danh sách
    lstHocSinh.Add(hsNew);
    LuuDSHS();
  }

  // 2. Tìm kiếm học sinh dựa theo tên
  public void TimKiemHocSinh()
  {
    Console.WriteLine("Nhập từ khóa cần tìm: ");
    string? keyword = Console.ReadLine()?.ToLower();
    List<HocSinh>? lstHs = lstHocSinh?.Where(hs => hs.TenHocSinh.ToLower().Contains(keyword)).ToList();

    if (lstHs?.Count > 0)
    {
      Console.WriteLine($"Tìm thấy {lstHs.Count} có tên chứa từ khóa: {keyword}");
      foreach (HocSinh hs in lstHs)
      {
        hs.XuatThongTin();
      }
    }
  }

  // 3. Cập nhật điểm số học sinh
  public void CapNhatDiemSo()
  {
    Console.WriteLine("Nhập vào mã học sinh");
    int MaHocSinh = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Nhập vào điểm Toán");
    double DiemToanMoi = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Nhập vào điểm Văn");
    double DiemVanMoi = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Nhập vào điểm Anh");
    double DiemAnhMoi = Convert.ToDouble(Console.ReadLine());

    HocSinh? hs = lstHocSinh.Find(hs => hs.MaHocSinh == MaHocSinh);
    if (hs != null)
    {
      hs.DiemToan = DiemToanMoi;
      hs.DiemVan = DiemVanMoi;
      hs.DiemAnh = DiemAnhMoi;
      hs.XuatThongTin();
    }
    else
    {
      Console.WriteLine("Không tìm thấy học sinh có mã tương ứng");
    }
  }

  // 4. Xóa học sinh khỏi danh sách
  public void XoaHocSinh()
  {
    Console.WriteLine("Nhập vào mã học sinh cần xóa");
    int MaHSXoa = Convert.ToInt32(Console.ReadLine());

    HocSinh? hsXoa = lstHocSinh.Find(hs => hs.MaHocSinh == MaHSXoa);
    if (hsXoa != null)
    {
      lstHocSinh.Remove(hsXoa);
      LuuDSHS();
      Console.WriteLine(@"Xóa thành công!!!");
    }
  }

  // 5. Hiển thị danh sách học sinh kèm xếp loại học lực
  public void HienThiDanhSach()
  {
    if (lstHocSinh != null)
    {

      foreach (HocSinh hs in lstHocSinh)
      {
        hs.XuatThongTin();
      }

    }
  }

  // 6. Hiển thị học sinh theo điểm trung bình tăng dần
  public void HienThiHocSinhTheoDiemTrungBinh()
  {
    List<HocSinh> newList = lstHocSinh.OrderBy(hs => hs.TinhDiemTB()).ToList();
    if (newList != null)
    {
      newList.ForEach(hv => hv.XuatThongTin());
    }
  }

  // 7. Hiển thị học sinh theo tên
  public void HienThiHocSinhTheoTen()
  {
    List<HocSinh> newList = lstHocSinh.OrderBy(hs => hs.GetLastName()).ToList();
    Console.WriteLine("Danh sách học viên theo tên: ");
    if (newList != null)
    {
      newList.ForEach(hs => hs.XuatThongTin());
    }
  }

  // 8. Lưu dữ liệu vào file
  public async void LuuDSHS()
  {
    string sDSHS = JsonSerializer.Serialize(lstHocSinh);
    await File.WriteAllTextAsync("lstHocSinh.json", sDSHS);
  }

  // 9. Đọc dữ liệu từ file
  public async void LoadDSHS()
  {
    string? strDSHS = await File.ReadAllTextAsync("./lstHocSinh.json");
    lstHocSinh = JsonSerializer.Deserialize<List<HocSinh>>(strDSHS);
  }

  // 10. Thoát
  public void Thoat()
  {
    chon = 10;
  }
}