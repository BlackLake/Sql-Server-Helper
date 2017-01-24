using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KriptoGünlük //burası projeye eklendikten sonra projenin namespace'i ile değiştirilecek
{
    class SqlServerHelper
    {
        private SqlConnection DbConnection; //baglanti
        public SqlConnection Baglanti	//baglanti get set edildi
        {
            get { return DbConnection; }
            set { DbConnection = value; }
        }

        private SqlCommand Command; //sql sorgusu
        public SqlCommand Komut // komut(sorgu) get set edildi 
        {
            get { return Command; }
            set { Command = value; }
        }

        public SqlDataAdapter DataAdapter; // data adapter 

        private SqlDataReader NtpDataReader; //data reader
        public SqlDataReader Reader // reader get set edildi
        {
            get { return NtpDataReader; }
            set { NtpDataReader = value; }
        }

        public void ConnectToDb(string connStr) // servera baglanma fonksiyonu, "sql server provider" parametre olarak girilmelidir
        {
            DbConnection = new SqlConnection(connStr); //bağlantı oluşturuldu
            Command = new SqlCommand();	//komut oluşturuldu
            Command.Connection = DbConnection; //komutun kullanacağı bağlantı atandı
            DataAdapter = new SqlDataAdapter(Command); //data adapter komut parametresi ile oluşturuldu
            DbConnection.Open(); //bağlantı kuruldu
        }
        
        public int InsertData(string cmdStr)//	veri ekleme komutu, parametre olarak sql sorgusu alır
        {
            Command.CommandText = cmdStr;// sql sorgusu komuta girildi
            return Command.ExecuteNonQuery();//komut çalıştırıldı ve sonuç döndürüldü
        }

        public int UpdateData(string cmdStr) //veri güncelleme komutu, parametre olarak sql sorgusu alır
        {
            Command.CommandText = cmdStr;// sql sorgusu komuta girildi
            return Command.ExecuteNonQuery();//komut çalıştırıldı ve sonuç döndürüldü
        }

        public int DeleteData(string cmdStr) // veri silme komutu, parametre olarak sql sorgusu alır
        {
            Command.CommandText = cmdStr;// sql sorgusu komuta girildi
            return Command.ExecuteNonQuery();//komut çalıştırıldı ve sonuç döndürüldü
        }

        public DataTable GetData(string cmdStr) //veri tablosu çekme komutu, parametre olarak sql sorgusu alır 
        {
            Command.CommandText = cmdStr;// sql sorgusu komuta girildi
            var tbl = new DataTable();// datatable oluşturuldu
            DataAdapter.Fill(tbl);//datatable data adaptör kullanılarak dolduruldu
            return tbl;// tablo döndürüldü
        }

        public DataRow GetDataRow(string sql) //veri satırı çekme komutu, parametre olarak sql sorgusu alır
        {
            Command.CommandText = sql; // sql sorgusu komuta girildi
            var tblVeri = new DataTable();// datatable oluşturuldu
            DataAdapter.Fill(tblVeri);//datatable data adaptör kullanılarak dolduruldu
            if (tblVeri.Rows.Count > 0)// sıfırdan fazla satır çekildi ise ilk satırı döndür 
            {
                return tblVeri.Rows[0];
            }
            else // null döndür
            {
                return null;
            }
        }

        public object GetScalarValue(string sql) //tekil veri çekme komutu, parametre olarak sql sorgusu alır
        {
            Command.CommandText = sql;// sql sorgusu komuta girildi
            return Command.ExecuteScalar();//komut çalıştırıldı ve sonuç döndürüldü
        }
    }
}
