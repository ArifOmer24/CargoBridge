using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace CARGOBRIDGE
{
    public partial class CargosForm : Form
    {
        CargoBridgeDBEntities db = new CargoBridgeDBEntities();
        public CargosForm()
        {
            InitializeComponent();
        }

        //VERİ EKLEME METHODU
        private void addBtn_Click(object sender, EventArgs e)
        {
           
            // KARGO VERİ İŞLEME BÖLÜMÜ
            Cargos cargos = new Cargos();
            cargos.CargoPrice = cargoPriceTxt.Text; //KARGO FİYATI
            cargos.DeliveryName = deliveryNameTxt.Text; //KARGO TESLİM TÜRÜ
            cargos.IsActive = true; //AKTİFLİK DURUMU
            cargos.OrderTotal = orderTotalTxt.Text; //ÜRÜN TOPLAMI
            cargos.TrackingNo = cargoTrackingNoTxt.Text; //KARGO TAKİP NUMARASI
            cargos.InvoiceNo = invoiceNoTxt.Text; ; //FATURA NUMARASI
            cargos.Description = descriptionRchtxtbox.Text;
            cargos.DeliveryStatus = shippingStatusCbox.Text;

            //ŞİRKET ID ALINAN YER / ŞİRKET ID ' Sİ COMPANIES TABLOSUNDAN ALINIR

            int companyId; // INT BİÇİMİNDE companyId ADINDA DEĞİŞKEN OLUŞTURUR

            // COMBOBOX'TA BİR DEĞER SEÇİLMİŞ VE BU DEĞER GEÇERLİ BİR TAM SAYI OLARAK AYRIŞTIRILABİLİYORSA
            if (companyNameCmbxTxt.SelectedValue != null && int.TryParse(companyNameCmbxTxt.SelectedValue.ToString(), out companyId))
            {
                // AYRILAN SAYIYI CARGOS TABLOSUNUN İÇİNDEKİ CompanyId ÖZELLİĞİNE YAZAR
                cargos.CompanyId = companyId;
            }
            else
            {
                // YUKARIDAKİ ŞARTLARIN TERSİ DURUMDA GÖSTERİLECEK MESAJ
                MessageBox.Show("geçersiz giriş.");
            }

            //FATURA TARİHİ 

            // invoiceDate ADINDA TARİH VERİ FORMATINDA BİR DEĞİŞKEN OLUŞTURUR
            DateTime invoiceDate;

            // TEXT BİÇİMİNDE GİRİLEN VERİYİ DateTime.Parse METHODUYLA DATETİME BİÇİMİNE DÖNÜŞTÜRÜR.
            if (DateTime.TryParse(invoiceDateTimeTxt.Text, out invoiceDate))
            {
                // DÖNÜŞTÜRÜLEN DATA YAZDIRILIR
                cargos.InvoiceDate = invoiceDate;
            }
            else
            {
                // BİR SORUN VARSA HATA DÖNDÜRÜR
                MessageBox.Show("geçersiz tarih");
            }


            /*//TEXTBOXLARIN BOŞ OLMASI DURUMUNDA ALINACAK AKSİYONLAR
            bool atLeastOneEmpty = false;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox txtBox = ctrl as TextBox;
                    if (string.IsNullOrWhiteSpace(txtBox.Text))
                    {
                        MessageBox.Show("Lütfen " + txtBox.Name + " alanını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        atLeastOneEmpty = true;
                        break; // ilk boş TextBox'u bulduğumuzda döngüyü durdur
                    }
                }
                else if (ctrl is ComboBox)
                {
                    ComboBox comboBox = ctrl as ComboBox;
                    if (comboBox.SelectedIndex == -1)
                    {
                        MessageBox.Show("Lütfen " + comboBox.Name + " seçim yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        atLeastOneEmpty = true;
                        break; // ilk boş ComboBox'u bulduğumuzda döngüyü durdur
                    }
                }
            }
            if (!atLeastOneEmpty)
            {

            }

            */


            db.Cargos.Add(cargos);
            db.SaveChanges();
            Clear();
            List();
            // Veri işleme kodları buraya gelir

        }

        // GÜNCELLEME METHODU
        private void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DataViewList.CurrentRow.Cells[0].Value.ToString());
            Cargos cargos = db.Cargos.FirstOrDefault(x => x.CargoId == id);
            cargos.DeliveryName = deliveryNameTxt.Text;
            cargos.OrderTotal = orderTotalTxt.Text;
            cargos.InvoiceNo = invoiceNoTxt.Text;
            cargos.CargoPrice = cargoPriceTxt.Text;
            cargos.TrackingNo = cargoTrackingNoTxt.Text;
            cargos.Description = descriptionRchtxtbox.Text;
            cargos.DeliveryStatus = shippingStatusCbox.Text;
            int companyId = (int)companyNameCmbxTxt.SelectedValue;

            // ilgili Company tablosundan veriyi al
            Companies company = db.Companies.FirstOrDefault(c => c.CompanyId == companyId);
            // Eğer company null değilse yani böyle bir şirket varsa, işlemi yap
            if (company != null)
            {
                // Cargos tablosundaki şirket adını ComboBox'tan seçilen şirket adıyla güncelle
                cargos.CompanyId = company.CompanyId;
            }


            DateTime invoiceDate;

            // TEXT BİÇİMİNDE GİRİLEN VERİYİ DateTime.Parse METHODUYLA DATETİME BİÇİMİNE DÖNÜŞTÜRÜR.
            if (DateTime.TryParse(invoiceDateTimeTxt.Text, out invoiceDate))
            {
                // DÖNÜŞTÜRÜLEN DATA YAZDIRILIR
                cargos.InvoiceDate = invoiceDate;
            }
            else
            {
                // BİR SORUN VARSA HATA DÖNDÜRÜR
                MessageBox.Show("geçersiz tarih");
            }
            db.SaveChanges();
            Clear();
            List();
        }

        // DELETE BUTTON
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DataViewList.CurrentRow.Cells[0].Value.ToString());
            Cargos cargos = db.Cargos.FirstOrDefault(x => x.CargoId == id);
            cargos.IsActive = false;
            db.SaveChanges();
            Clear();
            List();
        }

        // LİST BUTTON
        private void listBtn_Click(object sender, EventArgs e)
        {
            List();
            Clear();
        }

        //FORM YÜKLEME
        private void Form1_Load(object sender, EventArgs e)
        {
            var data = db.Companies.Where(s=> s.IsActive == true).ToList();
            companyNameCmbxTxt.DataSource = data;
            companyNameCmbxTxt.DisplayMember = "CompanyName";
            companyNameCmbxTxt.ValueMember = "CompanyId";
            List();
        }

        // SIRAYA ÇİFT TIKLAMA SONUCU VERİLERİN KUTULARA GELMESİ
        private void DataViewList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataViewList.CurrentRow != null)
            {
                if (DataViewList.CurrentRow.Cells["ŞirketAdı"].Value != null)
                    companyNameCmbxTxt.Text = DataViewList.CurrentRow.Cells["ŞirketAdı"].Value.ToString();
                else
                    companyNameCmbxTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["FaturaTarihi"].Value != null)
                    invoiceDateTimeTxt.Text = DataViewList.CurrentRow.Cells["FaturaTarihi"].Value.ToString();
                else
                    invoiceDateTimeTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["SiparişToplam"].Value != null)
                    orderTotalTxt.Text = DataViewList.CurrentRow.Cells["SiparişToplam"].Value.ToString();
                else
                    orderTotalTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["TeslimatTürü"].Value != null)
                    deliveryNameTxt.Text = DataViewList.CurrentRow.Cells["TeslimatTürü"].Value.ToString();
                else
                    deliveryNameTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["KargoFiyat"].Value != null)
                    cargoPriceTxt.Text = DataViewList.CurrentRow.Cells["KargoFiyat"].Value.ToString();
                else
                    cargoPriceTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["KargoTakipNo"].Value != null)
                    cargoTrackingNoTxt.Text = DataViewList.CurrentRow.Cells["KargoTakipNo"].Value.ToString();
                else
                    cargoTrackingNoTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["FaturaNo"].Value != null)
                    invoiceNoTxt.Text = DataViewList.CurrentRow.Cells["FaturaNo"].Value.ToString();
                else
                    invoiceNoTxt.Text = "";

                if (DataViewList.CurrentRow.Cells["ÜrünAçıklaması"].Value != null)
                    descriptionRchtxtbox.Text = DataViewList.CurrentRow.Cells["ÜrünAçıklaması"].Value.ToString();
                else
                    descriptionRchtxtbox.Text = "";

                if (DataViewList.CurrentRow.Cells["TeslimatDurumu"].Value != null)
                    shippingStatusCbox.Text = DataViewList.CurrentRow.Cells["TeslimatDurumu"].Value.ToString();
                else
                    shippingStatusCbox.Text = "";
            }

        }

        // Firmalar Sayfasına Giriş
        private void addCompanyBtn_Click(object sender, EventArgs e)
        {
            CompaniesForm companiesForm = new CompaniesForm();
            companiesForm.Show();
            this.Hide();
        }

        // Kargo Durumuna Göre Satır Renklendirme
        private void DataViewList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            Cargos cargos = new Cargos();
            DataGridViewRow row = DataViewList.Rows[e.RowIndex];

            // Veritabanından gelen verinin "TESLİMAT DURUMU" sütunu indeksi
            int teslimatDurumuColumnIndex = 9; // Örneğin, 10. sütun (0 tabanlı indeksle)

            // TESLİMAT DURUMU sütununun değerine göre renklendirme
            if (row.Cells[teslimatDurumuColumnIndex].Value != null || cargos.IsActive == true)
            {
                string teslimatDurumu = row.Cells[teslimatDurumuColumnIndex].Value.ToString();

                if (teslimatDurumu == "Teslim")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(227, 51, 0);
                }
                else if (teslimatDurumu == "Yeni")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
                else if (teslimatDurumu == "Hazırlanıyor")
                {
                    row.DefaultCellStyle.BackColor = Color.Blue;
                }
                else if (teslimatDurumu == "Yolda")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if  (cargos.IsActive == false)
                {
                    row.DefaultCellStyle.BackColor = Color.Purple;
                }
                else
                {
                    // Eğer yukarıdaki durumlar sağlanmıyorsa, varsayılan arka plan rengini ayarlayabilirsiniz
                    row.DefaultCellStyle.BackColor = DataViewList.DefaultCellStyle.BackColor;
                }
            }
            else
            {
                // Eğer hücre boşsa, varsayılan arka plan rengini ayarlayabilirsiniz
                row.DefaultCellStyle.BackColor = DataViewList.DefaultCellStyle.BackColor;
            }

        }

        // Durumu "Yeni" Olanları Listele
        private void newOrderList_Click(object sender, EventArgs e)
        {
            ListByStatus("Yeni");
        }

        // Durumu "Yolda" Olanları Listele
        private void onRoadList_Click(object sender, EventArgs e)
        {
            ListByStatus("Yolda");
        }

        // Durumu "Teslim" Olanları Listele
        private void deliveredList_Click(object sender, EventArgs e)
        {
            ListByStatus("Teslim");
        }

        // Durumu "Hazırlanıyor" Olanları Listele
        private void preparingList_Click(object sender, EventArgs e)
        {
            ListByStatus("Hazırlanıyor");
        }

        // İptal Olanları Listele
        private void cancelList_Click(object sender, EventArgs e)
        {
            var cargos = db.Cargos
                .Where(s => s.IsActive == false)
                .ToList();
            var dataList = cargos.Select(cargo => new {
                KargoNo = cargo.CargoId,
                ŞirketAdı = db.Companies
                                .Where(c => c.IsActive == true) // Şirketin IsActive özelliğini kontrol et
                                .SingleOrDefault(s => s.CompanyId == cargo.CompanyId)?.CompanyName,
                TeslimatTürü = cargo.DeliveryName,
                SiparişToplam = cargo.OrderTotal,
                FaturaNo = cargo.InvoiceNo,
                FaturaTarihi = cargo.InvoiceDate,
                KargoFiyat = cargo.CargoPrice,
                KargoTakipNo = cargo.TrackingNo,
                ÜrünAçıklaması = cargo.Description,
                TeslimatDurumu = cargo.DeliveryStatus,
            })
            .ToList();

            DataViewList.DataSource = dataList;
            DataViewList.Columns["ŞirketAdı"].HeaderText = "Şirket Adı";
            DataViewList.Columns["FaturaTarihi"].HeaderText = "Fatura Tarihi";
            DataViewList.Columns["SiparişToplam"].HeaderText = "Sipariş Toplamı";
            DataViewList.Columns["TeslimatTürü"].HeaderText = "Teslimat Türü";
            DataViewList.Columns["KargoFiyat"].HeaderText = "Kargo Ücreti";
            DataViewList.Columns["KargoTakipNo"].HeaderText = "Kargo Takip No";
            DataViewList.Columns["FaturaNo"].HeaderText = "Fatura No";
            DataViewList.Columns["TeslimatDurumu"].HeaderText = "Teslimat Durumu";
            DataViewList.Columns["ÜrünAçıklaması"].HeaderText = "Ürün Açıklaması";
        }



        // GENEL METHODLAR ---------------------------------------------------------------------------------------------------------------------------------------------

        // Kargo Durumuna Göre Listeleme
        void ListByStatus(string status)
        {
            var cargos = db.Cargos
   .Where(s => s.IsActive == true && s.DeliveryStatus.Equals(status))
   .ToList();
            var dataList = cargos.Select(cargo => new {
                KargoNo = cargo.CargoId,
                ŞirketAdı = db.Companies
                                .Where(c => c.IsActive == true) // Şirketin IsActive özelliğini kontrol et
                                .SingleOrDefault(s => s.CompanyId == cargo.CompanyId)?.CompanyName,
                TeslimatTürü = cargo.DeliveryName,
                SiparişToplam = cargo.OrderTotal,
                FaturaNo = cargo.InvoiceNo,
                FaturaTarihi = cargo.InvoiceDate,
                KargoFiyat = cargo.CargoPrice,
                KargoTakipNo = cargo.TrackingNo,
                ÜrünAçıklaması = cargo.Description,
                TeslimatDurumu = cargo.DeliveryStatus,
            })
            .ToList();

            DataViewList.DataSource = dataList;
            DataViewList.Columns["ŞirketAdı"].HeaderText = "Şirket Adı";
            DataViewList.Columns["FaturaTarihi"].HeaderText = "Fatura Tarihi";
            DataViewList.Columns["SiparişToplam"].HeaderText = "Sipariş Toplamı";
            DataViewList.Columns["TeslimatTürü"].HeaderText = "Teslimat Türü";
            DataViewList.Columns["KargoFiyat"].HeaderText = "Kargo Ücreti";
            DataViewList.Columns["KargoTakipNo"].HeaderText = "Kargo Takip No";
            DataViewList.Columns["FaturaNo"].HeaderText = "Fatura No";
            DataViewList.Columns["TeslimatDurumu"].HeaderText = "Teslimat Durumu";
            DataViewList.Columns["ÜrünAçıklaması"].HeaderText = "Ürün Açıklaması";
        }

        // VERİ LİSTELEME METHODU
        void List()
        {
            var cargos = db.Cargos
                 .Where(s => s.IsActive == true)
                 .ToList();
            var dataList = cargos.Select(cargo => new {
                KargoNo = cargo.CargoId,
                ŞirketAdı = db.Companies
                                .Where(c => c.IsActive == true) // Şirketin IsActive özelliğini kontrol et
                                .SingleOrDefault(s => s.CompanyId == cargo.CompanyId)?.CompanyName,
                TeslimatTürü = cargo.DeliveryName,
                SiparişToplam = cargo.OrderTotal,
                FaturaNo = cargo.InvoiceNo,
                FaturaTarihi = cargo.InvoiceDate,
                KargoFiyat = cargo.CargoPrice,
                KargoTakipNo = cargo.TrackingNo,
                ÜrünAçıklaması = cargo.Description,
                TeslimatDurumu = cargo.DeliveryStatus,
            })
            .ToList();

            DataViewList.DataSource = dataList;
            DataViewList.Columns["ŞirketAdı"].HeaderText = "Şirket Adı";
            DataViewList.Columns["FaturaTarihi"].HeaderText = "Fatura Tarihi";
            DataViewList.Columns["SiparişToplam"].HeaderText = "Sipariş Toplamı";
            DataViewList.Columns["TeslimatTürü"].HeaderText = "Teslimat Türü";
            DataViewList.Columns["KargoFiyat"].HeaderText = "Kargo Ücreti";
            DataViewList.Columns["KargoTakipNo"].HeaderText = "Kargo Takip No";
            DataViewList.Columns["FaturaNo"].HeaderText = "Fatura No";
            DataViewList.Columns["TeslimatDurumu"].HeaderText = "Teslimat Durumu";
            DataViewList.Columns["ÜrünAçıklaması"].HeaderText = "Ürün Açıklaması";
        }

        //FORM VERİ GİRİŞLERİNİ TEMİZLEME METHODU
        void Clear()
        {
            cargoPriceTxt.Text = string.Empty;
            deliveryNameTxt.Text = string.Empty;
            orderTotalTxt.Text = string.Empty;
            cargoTrackingNoTxt.Text = string.Empty;
            invoiceNoTxt.Text = string.Empty;
            shippingStatusCbox.Text = string.Empty;
            invoiceDateTimeTxt.Text = string.Empty;
            descriptionRchtxtbox.Text = string.Empty;
        }

    }
}
