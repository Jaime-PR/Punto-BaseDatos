using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("No se ingreso el usuario o contrasena.");
                return;
            }

            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.GetConnection())
                {
                    string sql = "SELECT COUNT(*) FROM usuarios WHERE username=@usuario AND password=@password";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@usuario", txtUser.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    int existe = Convert.ToInt32(cmd.ExecuteScalar());

                    if (existe > 0)
                    {
                        MessageBox.Show("Bienvenido.");

                        frmPrincipal principal = new frmPrincipal();
                        this.Hide();     
                        principal.Show();     
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos.\n" + ex.Message);
            }

            //frmPrincipal principal= new frmPrincipal();
            //this.Hide();
            //principal.Show();
        }
    }
}
