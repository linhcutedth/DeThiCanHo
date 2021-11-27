using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CanHo.Models
{
    public class CanHoContext
    {
        readonly IConfiguration configuration;
        public string ConnectionString { get; set; }

        public CanHoContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Them canHo

        public int Create(CanHoModel ch)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into CanHo value(?mach, ?tench)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mach", ch.MaCH.ToString());
                cmd.Parameters.AddWithValue("tench", ch.TenCH.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        // Liet ke can ho

        public List<NhanVienModel> getNhanVien(int soLan)
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select nv.manv, tennv, sum(a.lanthu) as solan" +
                               " from nhanvien nv,  (select manv, matb, mach, max(lanthu) as lanthu from nv_bt group by manv, matb, mach) a" +
                               " where nv.manv=a.manv" +
                               "  group by nv.manv, tennv" +
                               " having sum(a.lanthu) >= @solan";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@solan",soLan);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienModel()
                        {
                            MaNV = reader["manv"].ToString(),
                            TenNV = reader["tennv"].ToString(),
                            SoLan = Convert.ToInt32(reader["solan"].ToString()),
                        });

                    }
                }
            }
            return list;
        }

        // Liet ke ten nhan vien
        public List<NhanVienModel> getTenNhanVien()
        {
            List<NhanVienModel> list = new List<NhanVienModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select manv, tennv from nhanvien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NhanVienModel()
                        {
                            MaNV = reader["manv"].ToString(),
                            TenNV = reader["tennv"].ToString(),
                        });

                    }
                }
            }
            return list;
        }

        // Liet ke danh sach thiet bi nhan vien da sua
        public List<NV_BT> getListTB(string maNV)
        {
            List<NV_BT> list = new List<NV_BT>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from nv_bt where manv =@manv";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", maNV);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new NV_BT()
                        {
                            MaNV = reader["manv"].ToString(),
                            MaTB = reader["matb"].ToString(),
                            MaCH = reader["mach"].ToString(),
                            LanThu = Convert.ToInt32(reader["lanthu"]),
                            NgBT = Convert.ToDateTime(reader["ngbt"].ToString())
                        }) ; 

                    }
                }
            }
            return list;
        }

        public NV_BT getNVBT(string manv, string matb, string mach, int lanthu)
        {
            NV_BT nv = new NV_BT();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from nv_bt where  manv = @manv and matb =@matb and mach = @mach and lanthu=@lanthu  ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", manv); //Binding
                cmd.Parameters.AddWithValue("@matb", matb);
                cmd.Parameters.AddWithValue("@mach", mach);
                cmd.Parameters.AddWithValue("@lanthu", lanthu);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nv.MaNV = reader["manv"].ToString();
                        nv.MaTB = reader["matb"].ToString();
                        nv.MaCH = reader["mach"].ToString();
                        nv.LanThu =Convert.ToInt32(reader["lanthu"]);
                        nv.NgBT = Convert.ToDateTime(reader["ngbt"]);
                    }
                }
            }
            return nv;
        }

        public int Update(NV_BT nv)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update nv_bt set ngbt =@ngbt where manv = @manv and matb =@matb and mach = @mach and lanthu=@lanthu";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", nv.MaNV); //Binding
                cmd.Parameters.AddWithValue("@matb", nv.MaTB);
                cmd.Parameters.AddWithValue("@mach", nv.MaCH);
                cmd.Parameters.AddWithValue("@lanthu", nv.LanThu);
                cmd.Parameters.AddWithValue("ngbt",Convert.ToDateTime(nv.NgBT));
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }
        public int Delete(string manv, string matb, string mach, int lanthu)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from nv_bt where manv = @manv and matb =@matb and mach = @mach and lanthu=@lanthu  ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", manv); //Binding
                cmd.Parameters.AddWithValue("@matb", matb);
                cmd.Parameters.AddWithValue("@mach", mach);
                cmd.Parameters.AddWithValue("@lanthu", lanthu);
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }
    }
}
