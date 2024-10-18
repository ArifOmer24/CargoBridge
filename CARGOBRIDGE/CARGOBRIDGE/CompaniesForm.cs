using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARGOBRIDGE
{
    public partial class CompaniesForm : Form
    {

        CargoBridgeDBEntities db = new CargoBridgeDBEntities();

        public CompaniesForm()
        {
            InitializeComponent();
        }



        // FORM LOADING
        private void CompaniesForm_Load(object sender, EventArgs e)
        {
            List();
        }

        // EKLEME METHODU
        private void addBtn_Click(object sender, EventArgs e)
        {
            string companyName = companyNameTxt.Text.Trim();

            // Aynı isimde başka bir şirket var mı kontrol ediyoruz
            bool companyExists = db.Companies.Any(c => c.CompanyName.Equals(companyName));

            if (string.IsNullOrWhiteSpace(companyName) || companyExists)
            {
                MessageBox.Show("Lütfen geçerli ve benzersiz bir şirket adı girin.");
            }
            else
            {
                Companies newCompany = new Companies
                {
                    CompanyName = companyName,
                    IsActive = true
                };

                db.Companies.Add(newCompany);
                db.SaveChanges();
                List();
                Clear();
            }
        }

        // SİL METHODU
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DataGridCompaniesList.CurrentRow.Cells[0].Value.ToString());
            Companies companies = db.Companies.FirstOrDefault(x => x.CompanyId == id);
            companies.IsActive = false;
            db.SaveChanges();
            List();
            Clear();
        }


        // TEMİZLEME METHODU
        void Clear()
        {
            companyNameTxt.Text = string.Empty;
        }

        // LİST METHODU
        void List()
        {
            var companies = db.Companies
               .Where(s => s.IsActive == true)
               .ToList();

            var dataList = companies.Select(company => new {
                ŞirketID = company.CompanyId,
                ŞirketAdı = company.CompanyName

            })
                            .ToList();

            DataGridCompaniesList.DataSource = dataList;
            DataGridCompaniesList.Columns["ŞirketAdı"].HeaderText = "Şirket Adı";
            DataGridCompaniesList.Columns["ŞirketID"].HeaderText = "Şirket No";
        }

        // ÇİFT TIK VERİ GETİRME
        private void DataGridCompaniesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            companyNameTxt.Text = DataGridCompaniesList.CurrentRow.Cells["ŞirketAdı"].Value.ToString();
        }

        // GÜNCELLEME METHODU
        private void updateBtn_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DataGridCompaniesList.CurrentRow.Cells[0].Value.ToString());
            Companies companies = db.Companies.FirstOrDefault(x => x.CompanyId == id);
            companies.CompanyName = companyNameTxt.Text;
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

        private void cargosbacktoviewBtn_Click(object sender, EventArgs e)
        {
            CargosForm cargosForm = new CargosForm();
            cargosForm.Show();
            this.Hide();
        }
    }
}
