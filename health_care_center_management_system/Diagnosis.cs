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
    public partial class Diagnosis : Form
    {
        Functions Con;
        public Diagnosis()
        {
            InitializeComponent();
            Con = new Functions();
            Getpatients();
            GetTests();

        }

        private void GetCost()
        {
            string Query = "select * from TestTbl Where TestCode = {0}";
            Query = string.Format(Query, TestCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                CostTb.Text = dr["TestCost"].ToString();

            }
        }
        private void Getpatients()
        {
            string Query = "Select * from PatientTbl";
            PatientCb.DisplayMember = Con.GetData(Query).Columns["PatName"].ToString();
            PatientCb.ValueMember = Con.GetData(Query).Columns["PatCode"].ToString();
            PatientCb.DataSource = Con.GetData(Query);


        }
        private void GetTests()
        {
            string Query = "Select * from TestTbl";
            TestCb.DisplayMember = Con.GetData(Query).Columns["TestName"].ToString();
            TestCb.ValueMember = Con.GetData(Query).Columns["TestCode"].ToString();
            TestCb.DataSource = Con.GetData(Query);


        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {

        }

        private void TestCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCost();
       
        }
    }
}
