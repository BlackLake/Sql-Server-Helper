# Sql-Server-Helper
Sql Server ile yapılan işlemlerde kolaylık sağlayan bir C# sınıfı

//////// KULLANIMI ////////

    SqlServerHelper helper = new SqlServerHelper();
    public FrmAna() //constuctor
    {

        InitializeComponent();//otomatik oluşan method
        helper.ConnectToDb("Data Source=< ServerAdi >;" + "Initial Catalog=< DatabaseAdi >;" + "Integrated Security=SSPI;");//düzenlenecek,
    }

    public void Method()
    {
       string metin="asd";

       //---------//Datatable'a veri çekme örneği
       DataTable Veri = helper.GetData("SELECT * FROM Kullanici");
       dataGridView1.DataSource = helper.GetData("SELECT * FROM Kullanici");//direk grid view'a

       //---------//Datarow'a a veri çekme örneği
       DataRow satir = helper.GetDataRow("SELECT * FROM Kullanici Where ID="+metin);

       //---------//Tek hücreden veri çekme örneği
       string veri = helper.GetScalarValue("SELECT Adi FROM Kullanici Where ID="+metin);


       //---------// Database'e veri ekleme örneği
       helper.InsertData("INSERT INTO Kullanici (Adi,Soyadi) VALUES("+metin+","+metin+")");

       //---------// Database de veri güncelleme örneği
       helper.UpdateData("UPDATE Kullanici SET Ad="+metin+",Soyad="+metin+" WHERE ID="+metin);


       //---------// Database de veri silme örneği
       helper.DeleteData("DELETE FROM Kullanici WHERE ID="+metin);// database de veri silme örneği
    }
