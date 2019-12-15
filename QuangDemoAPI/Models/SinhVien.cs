using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuangDemoAPI.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public SinhVien(int id, string ten, int tuoi)
        {
            this.Id = id;
            this.Ten = ten;
            this.Tuoi = tuoi;
        }

        public SinhVien()
        {
        }

        public List<SinhVien> sinhViens()
        {
            List<SinhVien> ds = new List<SinhVien>();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SinhVien");
            DataTable danhsach = SQLDatabase.GetDataTable(sqlCommand);
            for (int i = 0; i < danhsach.Rows.Count; i++)
            {
                int Id = int.Parse(danhsach.Rows[i]["Id"].ToString().Trim());
                string Ten = danhsach.Rows[i]["Ten"].ToString().Trim();
                int Tuoi = int.Parse(danhsach.Rows[i]["Tuoi"].ToString().Trim());
                ds.Add(new SinhVien(Id, Ten, Tuoi));
            }
            return ds;
        }
        public int InsertSinhVien(SinhVien sinhVien)
        {
            var insert = 0;
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO SinhVien VALUES(@Ten,@Tuoi)");
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@Ten", sinhVien.Ten);
            sqlCommand.Parameters.AddWithValue("@Tuoi", sinhVien.Tuoi);
            SQLDatabase.ExcuteNoneQuery(sqlCommand);
            return insert;
        }
        public int UpdateSinhVien(SinhVien sinhVien)
        {
            var update = 0;
            SqlCommand sqlCommand = new SqlCommand("UPDATE SinhVien SET Ten = @Ten, Tuoi = @Tuoi WHERE Id = @Id");
            sqlCommand.Parameters.AddWithValue("@Ten", sinhVien.Ten);
            sqlCommand.Parameters.AddWithValue("@Tuoi", sinhVien.Tuoi);
            sqlCommand.Parameters.AddWithValue("@Id", sinhVien.Id);
            SQLDatabase.ExcuteNoneQuery(sqlCommand);
            return update;
        }
        public int DeleteSinhVien(int Id)
        {
            var delete = 0;
            SqlCommand sqlCommand = new SqlCommand("DELETE SinhVien WHERE Id = @Id");
            sqlCommand.Parameters.AddWithValue("@Id", Id);
            SQLDatabase.ExcuteNoneQuery(sqlCommand);
            return delete;
        }
    }
}
