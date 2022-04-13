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
            /*
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
            */
            #endregion

            #region MySql
            //*
            string strConnection = "server=127.0.0.1;User Id=root;password=1234";
            //string strConection2 = "server=127.0.0.1;User Id=pma;database=curso_db;password=pmapass";

            MySqlConnection Conexao = new MySqlConnection(strConnection);

            try
            {
                Conexao.Open();

                lblResult.Text = "Conectado ao MySQL";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao;
                comando.CommandText = "CREATE DATABASE IF NOT EXISTS curso_db";

                comando.ExecuteNonQuery();
                lblResult.Text = "Conectado ao MySQL e base de dados criada com sucesso";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = "Erro ao Conectar ao MySQL \n" + ex.Message;
            }
            finally
            {
                Conexao.Close();
            }


            //*/
            #endregion
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            #region SQL Server CE
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource = " + baseDados + "; Password = '1234'";

            SqlCeEngine db = new SqlCeEngine(strConection);

            if (!File.Exists(baseDados))
            {
                db.CreateDatabase();
            }
            db.Dispose();

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand(strConection);
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE pessoas ( id INT NOT NULL PRIMARY KEY, nome NVARCHAR(50), email NVARCHAR(50))";
                comando.ExecuteNonQuery();

                lblResult.Text = "Tabela criada SqlServer CE";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region SQLite
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + baseDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConection);
            //Conexao.ConnectionString = strConection;

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand(strConection);
                comando.Connection = conexao;

                comando.CommandText = "CREATE TABLE pessoas ( id INT NOT NULL PRIMARY KEY, nome NVARCHAR(50), email NVARCHAR(50))";
                comando.ExecuteNonQuery();

                lblResult.Text = "Tabela criada Sqlite";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySql

            //string strConnection = "server=127.0.0.1;User Id=root;password=1234";
            string strConnection = "server=127.0.0.1;User Id=root;database=curso_db;password=1234";

            MySqlConnection Conexao = new MySqlConnection(strConnection);

            try
            {
                Conexao.Open();

                lblResult.Text = "Conectado ao MySQL";

                MySqlCommand comando = new MySqlCommand();
                comando.Connection = Conexao;

                comando.CommandText = "CREATE TABLE pessoas ( id INT NOT NULL, nome VARCHAR(50), email VARCHAR(50), PRIMARY KEY(id))";
                comando.ExecuteNonQuery();

                lblResult.Text = "Tabela criada MySql";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = "Erro ao Conectar ao MySQL \n" + ex.Message;
            }
            finally
            {
                Conexao.Close();
            }

            #endregion
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int id = new Random(DateTime.Now.Millisecond).Next(0,1000);
            string nome = textBoxName.Text;
            string email = textBoxEmail.Text;

            if (nome == null || nome == "" || email == "" || email == null)
            {
                MessageBox.Show("Preencha os campos necessários", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #region SQL Server CE
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource = " + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {
                conexao.Open();

                SqlCeCommand comando = new SqlCeCommand(strConection);
                comando.Connection = conexao;

                comando.CommandText = "INSERT INTO pessoas VALUES (" + id + ", '" + nome + "', '" + email + "')";
                comando.ExecuteNonQuery();

                lblResult.Text = "Registro Inserido SqlServer CE";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region Sqlite
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + baseDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConection);

            try
            {
                conexao.Open();

                SQLiteCommand comando = new SQLiteCommand(strConection);
                comando.Connection = conexao;

                comando.CommandText = "INSERT INTO pessoas VALUES (" + id + ", '" + nome + "', '" + email + "')";
                comando.ExecuteNonQuery();

                lblResult.Text = "Registro Inserido Sqlite";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySql
            ///*
            //string strConnection = "server=127.0.0.1;User Id=root;password=1234";
            string strConnection = "server=127.0.0.1;User Id=root;database=curso_db;password=1234";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {
                conexao.Open();

                MySqlCommand comando = new MySqlCommand(strConnection);
                comando.Connection = conexao;

                comando.CommandText = "INSERT INTO pessoas VALUES (" + id + ", '" + nome + "', '" + email + "')";
                comando.ExecuteNonQuery();

                lblResult.Text = "Registro Inserido MySql";
                comando.Dispose();
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            //*/
            #endregion

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lblResult.Text = "";
            lista.Rows.Clear();


            #region SQL Server CE
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLServer.sdf";
            string strConection = @"DataSource = " + baseDados + "; Password = '1234'";

            SqlCeConnection conexao = new SqlCeConnection(strConection);

            try
            {

                string query = "SELECT * FROM pessoas";

                if (textBoxName.Text != "")
                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + textBoxName.Text + "'";
                }

                DataTable dados = new DataTable();
                SqlCeDataAdapter adaptador = new SqlCeDataAdapter(query, strConection);

                conexao.Open();

                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    lista.Rows.Add(linha.ItemArray);
                }
            }
            catch (Exception ex)
            {
                lista.Rows.Clear();
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region SQLite
            /*
            string baseDados = Application.StartupPath + @"\db\DBSQLite.db";
            string strConection = @"Data Source = " + baseDados + "; Version = 3";

            SQLiteConnection conexao = new SQLiteConnection(strConection);

            try
            {

                string query = "SELECT * FROM pessoas";

                if (textBoxName.Text != "")
                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + textBoxName.Text + "'";
                }

                DataTable dados = new DataTable();
                SQLiteDataAdapter adaptador = new SQLiteDataAdapter(query, strConection);

                conexao.Open();

                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    lista.Rows.Add(linha.ItemArray);
                }
            }
            catch (Exception ex)
            {
                lista.Rows.Clear();
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            */
            #endregion

            #region MySql
            ///*
            string strConnection = "server=127.0.0.1;User Id=root;database=curso_db;password=1234";

            MySqlConnection conexao = new MySqlConnection(strConnection);

            try
            {

                string query = "SELECT * FROM pessoas";

                if (textBoxName.Text != "")
                {
                    query = "SELECT * FROM pessoas WHERE nome LIKE '" + textBoxName.Text + "'";
                }

                DataTable dados = new DataTable();
                MySqlDataAdapter adaptador = new MySqlDataAdapter(query, strConnection);

                conexao.Open();

                adaptador.Fill(dados);

                foreach (DataRow linha in dados.Rows)
                {
                    lista.Rows.Add(linha.ItemArray);
                }
            }
            catch (Exception ex)
            {
                lista.Rows.Clear();
                lblResult.Text = ex.Message;
            }
            finally
            {
                conexao.Close();
            }
            //*/
            #endregion
        }
    }
}