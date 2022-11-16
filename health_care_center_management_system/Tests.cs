using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace health_care_center_management_system
{
    public partial class Tests : Form
    {
        Functions Con;
        public Tests()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTest();

        }

        private void ShowTest()
        {
            string Query = "Select * from TestTbl";
            TestList.DataSource = Con.GetData(Query);

        }
        private void Clear()
        {
            TNameTb.Text = "";
            TCostTb.Text = "";

        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (TNameTb.Text == "" || TCostTb.Text == "" )
            {
                MessageBox.Show("Missing Data!!!!");

            }
            else
            {
                string TName = TNameTb.Text;
                int Cost = Convert.ToInt32(TCostTb.Text);
                
                string Query = "insert into TestTb1 values('{0}','{1}')";
                Query = string.Format(Query, TName, Cost);
                Con.SetData(Query);
                ShowTest();
                Clear();
                MessageBox.Show("Patient Added!!!");

            }
        }
    }
}
