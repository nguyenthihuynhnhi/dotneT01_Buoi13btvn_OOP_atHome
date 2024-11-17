using System.Text.Json;

class MenuSanPhamVaDonHang
{
  public int Chon { get; set; }
  public List<SanPham> lstSanPham = new List<SanPham>();
  public List<DonHang> lstDonHang = new List<DonHang>();

  public void HienThiChucNang()
  {
    Console.WriteLine(@$"
     -----------------------------------------
    1. Thêm sản phẩm
    2. Tìm Kiếm sản phẩm theo tên
    3. Cập nhật giá bán hoặc số lượng tồn kho 
    4. Tính tổng giá trị kho hàng
    5. Xóa sản phẩm khỏi danh sách
    6. Hiển thị danh sách sản phẩm cùng tổng giá trị kho hàng
    7. Hiển thị sản phẩm theo giá bán tăng dần
    8. sắp xếp và hiển thị danh sách sản phẩm theo giá bán từ thấp đến cao
    9. Lưu lại dữ liệu
    10. Đọc dữ liệu cũ
    11.Thoát
    12. Thêm đơn hàng
    13. Hiển thị danh sách đơn hàng
    14. Cập nhật trạng thái giao hàng
    15. Xóa đơn hàng
   ");
  }

  public int ChonChucNang()
  {
    Console.WriteLine("Hãy chọn Chức năng: ");
    Chon = Convert.ToInt32(Console.ReadLine());
    return Chon;
  }

  // 1. Thêm sản phẩm
  public void ThemSanPham()
  {
    SanPham sp = new SanPham();
    sp.NhapThongTinSP();
    lstSanPham.Add(sp);
    LuuDSSP();
  }

  // 2. Tìm Kiếm sản phẩm theo tên
  public void TimKiemSanPhamTheoTen()
  {
    Console.WriteLine("Nhập từ khóa cần tìm: ");
    string? keyword = Console.ReadLine()?.ToLower();
    List<SanPham>? lstSP = lstSanPham.Where(sp => sp.TenSanPham.ToLower().Contains(keyword)).ToList();

    if (lstSP.Count > 0)
    {
      Console.WriteLine($"Tìm thấy {lstSP.Count} có tên chứa từ khóa: {keyword}");
      lstSP.ForEach(sp => sp.XuatThongTin());
    }
    else
    {
      Console.WriteLine("Không tìm thấy sản phẩm");
    }
  }

  // 3. Cập nhật giá bán hoặc số lượng tồn kho 
  public void CapNhatGiaBanHoacTonKho()
  {
    Console.WriteLine("Nhập vào mã học sinh: ");
    int MaHocSinh = Convert.ToInt32(Console.ReadLine());

    SanPham? sp = lstSanPham.Find(sp => sp.MaSanPham == MaHocSinh);

    if (sp != null)
    {
      Console.WriteLine("Nhập vào giá bán mới: ");
      int GiaBanMoi = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Nhập vào số lượng tồn kho mới: ");
      int SoLuongTonKhoMoi = Convert.ToInt32(Console.ReadLine());

      sp.GiaBan = GiaBanMoi;
      sp.SoLuongTonKho = SoLuongTonKhoMoi;
      LuuDSSP();
      Console.WriteLine("Cập nhật thành công !!!");
    }
    else
    {
      Console.WriteLine("Không tìm thấy sản phẩm: ");
    }
  }

  //  4. Tính tổng giá trị kho hàng 
  // (Viết hàm tách riêng vì còn phải sử dụng ở chức năng số 6)
  public void TinhTongGiaTriKhoHang()
  {
    Console.WriteLine($"Tổng giá trị kho hàng là: {TongGiaTriKhoHang()}");
  }
  public double TongGiaTriKhoHang()
  {
    double result = 0;
    foreach (SanPham sp in lstSanPham)
    {
      result += sp.GiaBan * sp.SoLuongTonKho;
    }

    return result;
  }

  //   5. Xóa sản phẩm khỏi danh sách
  public void XoaSanPham()
  {
    Console.WriteLine("Nhập mã sản phẩm xóa: ");
    int MaSanPhamXoa = Convert.ToInt32(Console.ReadLine());
    SanPham? spXoa = lstSanPham.Find(sp => sp.MaSanPham == MaSanPhamXoa);
    if (spXoa != null)
    {
      lstSanPham.Remove(spXoa);
      LuuDSSP();
      Console.WriteLine("Xóa Thành Công !!!");
    }
    else
    {
      Console.WriteLine("Không tìm thấy sản phẩm");
    }
  }
  //   6. Hiển thị danh sách sản phẩm cùng tổng giá trị kho hàng
  public void HienThiDanhSachSPCungTongGiaTriKhoHang()
  {
    if (lstSanPham != null)
    {
      lstSanPham.ForEach(sp => sp.XuatThongTin());
    }
    Console.WriteLine($"Tổng giá trị kho hàng là: {TongGiaTriKhoHang()}");
  }
  //   7. Hiển thị sản phẩm theo giá bán tăng dần
  public void HienThiGiaBanTangDan()
  {
    // b1 tạo 1 cái list<Sp> để chứa cái list sắp xếp orderBy
    // b2 Vòng lặp Foreach để xuất thông tin
    List<SanPham> newList = lstSanPham.OrderBy(sp => sp.GiaBan).ToList();
    if (newList != null)
    {
      newList.ForEach(sp => sp.XuatThongTin());
    }
  }

  //   8. Sắp xếp và hiển thị danh sách sản phẩm theo tên
  public void SapXepSPTheoTen()
  {
    List<SanPham> newList = lstSanPham.OrderBy(sp => sp.GetLastName()).ToList();
    if (newList != null)
    {
      newList.ForEach(sp => sp.XuatThongTin());
    }
    else
    {
      Console.WriteLine("Không tìm thấy sản phẩm");
    }
  }

  //   9. Lưu lại dữ liệu
  public async void LuuDSSP()
  {
    string sDSHS = JsonSerializer.Serialize(lstSanPham);
    await File.WriteAllTextAsync("lstSanPham.json", sDSHS);
  }

  //   10. Đọc dữ liệu cũ
  public async void LoadDSSP()
  {
    string? strDSHS = await File.ReadAllTextAsync("./lstSanPham.json");
    lstSanPham = JsonSerializer.Deserialize<List<SanPham>>(strDSHS);
  }

  //   12. Thêm đơn hàng
  public void ThemDonHang()
  {
    DonHang donHang = new DonHang();
    donHang.NhapThongTinDH();
    lstDonHang.Add(donHang);
  }

  //   13. Hiển thị danh sách đơn hàng
  public void HienThiDanhSachDH()
  {
    lstDonHang.ForEach(dh => dh.XuatThongTinDH());
  }

  // 14. Cập nhật trạng thái giao hàng
  public void CapNhatTrangThaiGiaoHang()
  {
    Console.WriteLine("Nhập vào mã đơn hàng: ");
    int MaDonHang = Convert.ToInt16(Console.ReadLine());
    DonHang? donHang = lstDonHang.Find(dh => dh.MaDonHang == MaDonHang);

    if (donHang != null)
    {
      Console.Write("Nhập trạng thái giao hàng(true/false): ");
      bool DaGiao = Convert.ToBoolean(Console.ReadLine());
      donHang.DaGiao = DaGiao;
      if (DaGiao)
      {
        SanPham? sp = lstSanPham.Find(sp => sp.MaSanPham == donHang.MaSanPham);
        if (sp != null)
        {
          sp.SoLuongTonKho -= donHang.SoLuongBan;
          LuuDSSP();
        }
        else
        {
          Console.WriteLine("Không tìm thấy sản phẩm");
        }
      }
    }
    else
    {
      Console.WriteLine("Không tìm thấy đơn hàng");
    }
  }

  // 15. Xóa đơn hàng
  public void XoaDonHang()
  {
    Console.WriteLine("Nhập vào mã đơn hàng xóa");
    int MaDonHangXoa = Convert.ToInt32(Console.ReadLine());
    DonHang? DonHangXoa = lstDonHang.Find(dh => dh.MaDonHang == MaDonHangXoa);
    if (DonHangXoa != null)
    {
      lstDonHang.Remove(DonHangXoa);
      Console.WriteLine("Xóa đơn hàng thành công !!!");
    }
    else
    {
      Console.WriteLine("Không tìm thấy đơn hàng");
    }
  }
}