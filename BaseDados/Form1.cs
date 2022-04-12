using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

// SQL Server Ce
using System.Data.SqlServerCe;

// SQLite
using System.Data.SQLite;

// MySql
using MySql.Data.MySqlClient;

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
            #region SQL Server CE
            /*
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
            */
            #endregion

            #region SQLite

            string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + baseDados + "; Version = 3";

            if (!File.Exists(baseDados))
            {
                SQLiteConnection.CreateFile(baseDados);
            }

            SQLiteConnection Conexao = new SQLiteConnection(strConection);
            //Conexao.ConnectionString = strConection;

            try
            {
                Conexao.Open();

                lblResult.Text = "Conectado ao SQLite";
            }
            catch (Exception ex)
            {
                lblResult.Text = "Erro ao Conectar ao SQLite \n" + ex.Message;
            }
            finally
            {
                Conexao.Close();
            }

            #endregion

            #region MySql

            #endregion
        }
    }
}