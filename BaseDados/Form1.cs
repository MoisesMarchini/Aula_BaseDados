using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;

namespace BaseDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource = "+ baseDados +"; Password = '1234'";

            SqlCeEngine db = new SqlCeEngine(strConection);

            if (!File.Exists(baseDados))
            {
                db.CreateDatabase();
            }
            db.Dispose();

            SqlCeConnection Conexao = new SqlCeConnection(strConection);
            //Conexao.ConnectionString = strConection;

            try
            {
                Conexao.Open();

                lblResult.Text = "Conectado ao SQL Server Ce";
            }
            catch (Exception ex)
            {
                lblResult.Text = "Erro ao Conectar ao SQL Server Ce \n"+ex.Message;
            }
            finally
            {
                Conexao.Close();
            }
        }
    }
}
