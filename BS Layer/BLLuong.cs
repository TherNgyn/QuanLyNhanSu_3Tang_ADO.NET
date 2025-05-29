using QuanLyNhanSu_3Tang_ADO.DB_Layer;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;

namespace QuanLyNhanSu_3Tang_ADO.BS_Layer
{
    class BLLuong
    {
        DBMain db = null;

        public BLLuong()
        {
            db = new DBMain();
        }

        public DataTable TinhLuongTheoThang(string maNV, string maThang, ref string err)
        {
            try
            {
                DataTable dtResult = new DataTable("LuongNhanVien");
                dtResult.Columns.Add("MaNV", typeof(string));
                dtResult.Columns.Add("Ho", typeof(string));
                dtResult.Columns.Add("Ten", typeof(string));
                dtResult.Columns.Add("LuongCoBan", typeof(int));
                dtResult.Columns.Add("BH01", typeof(float));
                dtResult.Columns.Add("BH02", typeof(float)); 
                dtResult.Columns.Add("BH03", typeof(float)); 
                dtResult.Columns.Add("TongTienBaoHiem", typeof(float));
                dtResult.Columns.Add("SoNgayCongChuan", typeof(int));
                dtResult.Columns.Add("SoNgayCong", typeof(float));
                dtResult.Columns.Add("TongPhuCap", typeof(int));
                dtResult.Columns.Add("GiamTruGiaCanh", typeof(int));
                dtResult.Columns.Add("TongThuongPhat", typeof(int));
                dtResult.Columns.Add("LuongChiuThue", typeof(int));
                dtResult.Columns.Add("Thue", typeof(int));
                dtResult.Columns.Add("LuongThucLanh", typeof(int));

                // Lấy thông tin nhân viên và lương cơ bản
                string sqlNV = "SELECT nv.MaNV, nv.Ho, nv.Ten, hd.LuongCoBan " +
                               "FROM NhanVien nv JOIN HopDong hd ON nv.MaNV = hd.MaNV " +
                               "WHERE nv.MaNV = @MaNV";
                SqlCommand cmdNV = new SqlCommand(sqlNV);
                cmdNV.Parameters.AddWithValue("@MaNV", maNV);
                DataTable dtNV = db.ExecuteQueryDataTableWithCmd(cmdNV, CommandType.Text);

                if (dtNV.Rows.Count == 0)
                {
                    err = "Không tìm thấy thông tin nhân viên";
                    return null;
                }

                //số ngày công chuẩn của tháng
                int soNgayCongChuan = 0;
                string sqlThang = "SELECT SoNgayCongChuan FROM Thang WHERE MaThang = @MaThang";
                SqlCommand cmdThang = new SqlCommand(sqlThang);
                cmdThang.Parameters.AddWithValue("@MaThang", maThang);
                object soNgayCongChuanObj = db.ExecuteScalar(cmdThang, CommandType.Text);
                if (soNgayCongChuanObj != null)
                {
                    soNgayCongChuan = Convert.ToInt32(soNgayCongChuanObj);
                }

                //tính số ngày công thực tế
                float soNgayCong = 0;
                string sqlCong = "SELECT SUM(cc.HeSo) AS TongNgayCong " +
                                "FROM ctChamCong ct JOIN ChamCong cc ON ct.MaCC = cc.MaCC " +
                                "WHERE ct.MaNV = @MaNV AND ct.MaThang = @MaThang";
                SqlCommand cmdCong = new SqlCommand(sqlCong);
                cmdCong.Parameters.AddWithValue("@MaNV", maNV);
                cmdCong.Parameters.AddWithValue("@MaThang", maThang);
                object soNgayCongObj = db.ExecuteScalar(cmdCong, CommandType.Text);
                if (soNgayCongObj != null && soNgayCongObj != DBNull.Value)
                {
                    soNgayCong = Convert.ToSingle(soNgayCongObj);
                }

                // Tính tổng phụ cấp
                int tongPhuCap = 0;
                string sqlPhuCap = "SELECT ISNULL(SUM(SoTien), 0) AS TongPhuCap " +
                                  "FROM ctPhuCap WHERE MaNV = @MaNV AND MaThang = @MaThang";
                SqlCommand cmdPhuCap = new SqlCommand(sqlPhuCap);
                cmdPhuCap.Parameters.AddWithValue("@MaNV", maNV);
                cmdPhuCap.Parameters.AddWithValue("@MaThang", maThang);
                object tongPhuCapObj = db.ExecuteScalar(cmdPhuCap, CommandType.Text);
                if (tongPhuCapObj != null && tongPhuCapObj != DBNull.Value)
                {
                    tongPhuCap = Convert.ToInt32(tongPhuCapObj);
                }

                // giảm trừ gia cảnh
                int soNguoiPhuThuoc = 0;

                string sqlNPT = "SELECT COUNT(*) FROM NguoiPhuThuoc WHERE MaNV = @MaNV";
                SqlCommand cmdNPT = new SqlCommand(sqlNPT);
                cmdNPT.Parameters.AddWithValue("@MaNV", maNV);
                object soNPTObj = db.ExecuteScalar(cmdNPT, CommandType.Text);
                if (soNPTObj != null)
                {
                    soNguoiPhuThuoc = Convert.ToInt32(soNPTObj);
                }
                int giamTruGiaCanh = soNguoiPhuThuoc * 4400000+11000000;

                // Tính tổng thưởng phạt
                int tongThuongPhat = 0;
                string sqlTP = "SELECT ISNULL(SUM(SoTien), 0) AS TongThuongPhat " +
                               "FROM ctThuongPhat ctp " +
                               "JOIN ThuongPhat tp ON ctp.MaThuongPhat = tp.MaThuongPhat " +
                               "WHERE ctp.MaNV = @MaNV AND ctp.MaThang = @MaThang";
                SqlCommand cmdTP = new SqlCommand(sqlTP);
                cmdTP.Parameters.AddWithValue("@MaNV", maNV);
                cmdTP.Parameters.AddWithValue("@MaThang", maThang);
                object tongTPObj = db.ExecuteScalar(cmdTP, CommandType.Text);
                if (tongTPObj != null && tongTPObj != DBNull.Value)
                {
                    tongThuongPhat = Convert.ToInt32(tongTPObj);
                }

                // Tính bảo hiểm
                float bhyt = 0, bhxh = 0, bhtn = 0;
                int luongCoBan = Convert.ToInt32(dtNV.Rows[0]["LuongCoBan"]);

                string sqlBH = "SELECT MaLoai FROM ctBaoHiem WHERE MaNV = @MaNV";
                SqlCommand cmdBH = new SqlCommand(sqlBH);
                cmdBH.Parameters.AddWithValue("@MaNV", maNV);
                DataTable dtBH = db.ExecuteQueryDataTableWithCmd(cmdBH, CommandType.Text);

                foreach (DataRow row in dtBH.Rows)
                {
                    string maLoai = row["MaLoai"].ToString();
                    switch (maLoai)
                    {
                        case "BH01": 
                            bhyt = luongCoBan * 0.015f;
                            break;
                        case "BH02": 
                            bhxh = luongCoBan * 0.08f;
                            break;
                        case "BH03": 
                            bhtn = luongCoBan * 0.01f;
                            break;
                    }
                }
                float tongBaoHiem = bhyt + bhxh + bhtn;
                float luongThucTe = 0;
                int luongChiuThue = 0;
                if (soNgayCong == 0)
                {
                    luongThucTe = 0;
                    luongChiuThue = 0;
                }
                else
                {
                    luongThucTe = (float)(luongCoBan * soNgayCong) / soNgayCongChuan;
                    luongChiuThue = (int)(luongThucTe + tongPhuCap + tongThuongPhat - tongBaoHiem - giamTruGiaCanh);
                }
                
               
                /*string message =
                    $"Lương cơ bản: {luongCoBan}\n" +
                    $"Số ngày công: {soNgayCong}\n" +
                    $"Số ngày công chuẩn: {soNgayCongChuan}\n" +
                    $"Lương thực tế: {luongThucTe:N2}\n" +
                    $"Tổng phụ cấp: {tongPhuCap}\n" +
                    $"Tổng thưởng/phạt: {tongThuongPhat}\n" +
                    $"Tổng bảo hiểm: {tongBaoHiem}\n" +
                    $"Giảm trừ gia cảnh: {giamTruGiaCanh}\n" +
                    $"Lương chịu thuế: {luongChiuThue}";

                MessageBox.Show(message);*/
                //  thuế TNCN
                int thue=0;
                if (luongChiuThue <= 0) 
                {
                    thue = 0;
                }
                else
                if(luongChiuThue > 0)
                {
                    if (luongChiuThue <= 5000000)
                        thue = (int)(luongChiuThue * 0.05);
                    else if (luongChiuThue <= 10000000)
                        thue = (int)(luongChiuThue * 0.1);
                    else if (luongChiuThue <= 18000000)
                        thue = (int)(luongChiuThue * 0.15);
                    else if (luongChiuThue <= 32000000)
                        thue = (int)(luongChiuThue * 0.2);
                    else if (luongChiuThue <= 52000000)
                        thue = (int)(luongChiuThue * 0.25);
                    else if (luongChiuThue <= 80000000)
                        thue = (int)(luongChiuThue * 0.3);
                    else
                        thue = (int)(luongChiuThue * 0.35);
                }

                int luongThucLanh = 0;
                if (soNgayCong == 0)
                {
                    luongThucLanh = 0;
                }
                else
                {
                    luongThucLanh = (int)(luongThucTe + tongPhuCap + tongThuongPhat - tongBaoHiem - thue);

                }
                /*MessageBox.Show("" + luongThucLanh);*/
                // kết quả
                DataRow newRow = dtResult.NewRow();
                newRow["MaNV"] = dtNV.Rows[0]["MaNV"];
                newRow["Ho"] = dtNV.Rows[0]["Ho"];
                newRow["Ten"] = dtNV.Rows[0]["Ten"];
                newRow["LuongCoBan"] = luongCoBan;
                newRow["BH01"] = bhyt;
                newRow["BH02"] = bhxh;
                newRow["BH03"] = bhtn;
                newRow["TongTienBaoHiem"] = tongBaoHiem;
                newRow["SoNgayCongChuan"] = soNgayCongChuan;
                newRow["SoNgayCong"] = soNgayCong;
                newRow["TongPhuCap"] = tongPhuCap;
                newRow["GiamTruGiaCanh"] = giamTruGiaCanh;
                newRow["TongThuongPhat"] = tongThuongPhat;
                newRow["LuongChiuThue"] = luongThucTe;
                newRow["Thue"] = thue;
                newRow["LuongThucLanh"] = luongThucLanh;

                dtResult.Rows.Add(newRow);
                return dtResult;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }
        public DataTable TinhLuongTheoThangAll(string maThang, ref string err)
        {
            try
            {
                DataTable dtResult = new DataTable("LuongNhanVien");
                dtResult.Columns.Add("MaNV", typeof(string));
                dtResult.Columns.Add("Ho", typeof(string));
                dtResult.Columns.Add("Ten", typeof(string));
                dtResult.Columns.Add("LuongCoBan", typeof(int));
                dtResult.Columns.Add("LuongChiuThue", typeof(int));
                dtResult.Columns.Add("Thue", typeof(int));
                dtResult.Columns.Add("LuongThucLanh", typeof(int));

                // Lấy thông tin nhân viên và lương cơ bản
                string sqlNV = "SELECT nv.MaNV, nv.Ho, nv.Ten, hd.LuongCoBan " +
                               "FROM NhanVien nv JOIN HopDong hd ON nv.MaNV = hd.MaNV ";
                SqlCommand cmdNV = new SqlCommand(sqlNV);
                DataTable dtNV = db.ExecuteQueryDataTableWithCmd(cmdNV, CommandType.Text);


                //số ngày công chuẩn của tháng
                int soNgayCongChuan = 0;
                string sqlThang = "SELECT SoNgayCongChuan FROM Thang WHERE MaThang = @MaThang";
                SqlCommand cmdThang = new SqlCommand(sqlThang);
                cmdThang.Parameters.AddWithValue("@MaThang", maThang);
                object soNgayCongChuanObj = db.ExecuteScalar(cmdThang, CommandType.Text);
                if (soNgayCongChuanObj != null)
                {
                    soNgayCongChuan = Convert.ToInt32(soNgayCongChuanObj);
                }

                foreach (DataRow row in dtNV.Rows)
                {
                    string maNV = row["MaNV"].ToString();
                    string ho = row["Ho"].ToString();
                    string ten = row["Ten"].ToString();
                    int luongCoBan = Convert.ToInt32(row["LuongCoBan"]);

                    // số ngày công
                    float soNgayCong = 0;
                    string sqlCong = "SELECT SUM(cc.HeSo) AS TongNgayCong FROM ctChamCong ct " +
                        "JOIN ChamCong cc ON ct.MaCC = cc.MaCC " +
                        "WHERE ct.MaThang = @MaThang AND ct.MaNV = @MaNV";
                    SqlCommand cmdCong = new SqlCommand(sqlCong);
                    cmdCong.Parameters.AddWithValue("@MaThang", maThang);
                    cmdCong.Parameters.AddWithValue("@MaNV", maNV);
                    object soNgayCongObj = db.ExecuteScalar(cmdCong, CommandType.Text);
                    if (soNgayCongObj != null && soNgayCongObj != DBNull.Value)
                    {
                        soNgayCong = Convert.ToSingle(soNgayCongObj);
                    }

                    // phụ cấp
                    int tongPhuCap = 0;
                    string sqlPhuCap = "SELECT ISNULL(SUM(SoTien), 0) " +
                        "FROM ctPhuCap WHERE MaThang = @MaThang AND MaNV = @MaNV";
                    SqlCommand cmdPhuCap = new SqlCommand(sqlPhuCap);
                    cmdPhuCap.Parameters.AddWithValue("@MaThang", maThang);
                    cmdPhuCap.Parameters.AddWithValue("@MaNV", maNV);
                    object tongPhuCapObj = db.ExecuteScalar(cmdPhuCap, CommandType.Text);
                    if (tongPhuCapObj != null)
                    {
                        tongPhuCap = Convert.ToInt32(tongPhuCapObj);
                    }

                    // thưởng phạt
                    int tongThuongPhat = 0;
                    string sqlTP = "SELECT ISNULL(SUM(SoTien), 0) " +
                        "FROM ctThuongPhat ctp " +
                        "JOIN ThuongPhat tp ON ctp.MaThuongPhat = tp.MaThuongPhat " +
                        "WHERE ctp.MaThang = @MaThang AND ctp.MaNV = @MaNV";
                    SqlCommand cmdTP = new SqlCommand(sqlTP);
                    cmdTP.Parameters.AddWithValue("@MaThang", maThang);
                    cmdTP.Parameters.AddWithValue("@MaNV", maNV);
                    object tongTPObj = db.ExecuteScalar(cmdTP, CommandType.Text);
                    if (tongTPObj != null)
                    {
                        tongThuongPhat = Convert.ToInt32(tongTPObj);
                    }

                    float bhyt = 0, bhxh = 0, bhtn = 0;
                    

                    string sqlBH = "SELECT MaLoai FROM ctBaoHiem WHERE MaNV = @MaNV";
                    SqlCommand cmdBH = new SqlCommand(sqlBH);
                    cmdBH.Parameters.AddWithValue("@MaNV", maNV);
                    DataTable dtBH = db.ExecuteQueryDataTableWithCmd(cmdBH, CommandType.Text);

                    foreach (DataRow rows in dtBH.Rows)
                    {
                        string maLoai = rows["MaLoai"].ToString();
                        switch (maLoai)
                        {
                            case "BH01":
                                bhyt = luongCoBan * 0.015f;
                                break;
                            case "BH02":
                                bhxh = luongCoBan * 0.08f;
                                break;
                            case "BH03":
                                bhtn = luongCoBan * 0.01f;
                                break;
                        }
                    }
                    float tongBaoHiem = bhyt + bhxh + bhtn;

                    // giảm trừ
                    int soNguoiPhuThuoc = 0;
                    string sqlNPT = "SELECT COUNT(*) " +
                        "FROM NguoiPhuThuoc " +
                        "WHERE MaNV = @MaNV";
                    SqlCommand cmdNPT = new SqlCommand(sqlNPT);
                    cmdNPT.Parameters.AddWithValue("@MaNV", maNV);
                    object soNPTObj = db.ExecuteScalar(cmdNPT, CommandType.Text);
                    if (soNPTObj != null)
                    {
                        soNguoiPhuThuoc = Convert.ToInt32(soNPTObj);
                    }
                    int giamTruGiaCanh = soNguoiPhuThuoc * 4400000+11000000;
                    float luongThucTe = 0;
                    int luongChiuThue = 0;
                    if (soNgayCong == 0)
                    {
                        luongThucTe = 0;
                    }
                    else
                    {
                        luongThucTe = (float)(luongCoBan * soNgayCong) / soNgayCongChuan;
                        luongChiuThue = (int)(luongThucTe + tongPhuCap + tongThuongPhat - tongBaoHiem - giamTruGiaCanh);
                    }
                     
                    

                    int thue = 0;
                    if (luongChiuThue <= 0) thue= 0;
                    else
                    if (luongChiuThue > 0)
                    {
                        if (luongChiuThue <= 5000000)
                            thue = (int)(luongChiuThue * 0.05);
                        else if (luongChiuThue <= 10000000)
                            thue = (int)(luongChiuThue * 0.1);
                        else if (luongChiuThue <= 18000000)
                            thue = (int)(luongChiuThue * 0.15);
                        else if (luongChiuThue <= 32000000)
                            thue = (int)(luongChiuThue * 0.2);
                        else if (luongChiuThue <= 52000000)
                            thue = (int)(luongChiuThue * 0.25);
                        else if (luongChiuThue <= 80000000)
                            thue = (int)(luongChiuThue * 0.3);
                        else
                            thue = (int)(luongChiuThue * 0.35);
                    }
                    int luongThucLanh = 0;
                    if (soNgayCong == 0)
                    {
                        luongThucLanh = 0;
                    }
                    else
                    {
                        luongThucLanh = (int)(luongThucTe + tongPhuCap + tongThuongPhat - tongBaoHiem) - thue;
                    }
                    DataRow newRow = dtResult.NewRow();
                    newRow["LuongCoBan"] = luongCoBan;
                    newRow["MaNV"] = maNV;
                    newRow["Ho"] = ho;
                    newRow["Ten"] = ten;
                    newRow["LuongChiuThue"] = luongChiuThue;
                    newRow["Thue"] = thue;
                    newRow["LuongThucLanh"] = luongThucLanh;
                    
                    dtResult.Rows.Add(newRow);
                }

                return dtResult;
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return null;
            }
        }

        

    }
}