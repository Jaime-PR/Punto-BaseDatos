using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Punto.Forms
{
    public partial class frmProductos : Form
    {
        Conexion conexion = new Conexion();

        public frmProductos()
        {
            InitializeComponent();
        }//Fin

        //Categorias
        private void frmProductos_Load(object sender, EventArgs e)
        {
            cmbCategorias.Items.Clear();

            cmbCategorias.Items.Add("Bebidas");
            cmbCategorias.Items.Add("Botanas");
            cmbCategorias.Items.Add("Lácteos");
            cmbCategorias.Items.Add("Abarrotes");
            cmbCategorias.Items.Add("Limpieza");

            CargarDatos();
        }

        //Busqueda
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            CargarDatos(txtBusqueda.Text);
        }

        //Limpiar
        private void Limpiar()
        {
            lblId.Text = "0";

            txtCodigo.Clear();
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();

            cmbCategorias.SelectedIndex = -1;
        }

        //Metodo
        private void CargarDatos(string filtro = "")
        {
            try
            {
                using (MySqlConnection conn = conexion.GetConnection())
                {
                    string sql = @"SELECT * FROM productos WHERE descripcion LIKE @filtro OR codigo LIKE @filtro";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvProductos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Tabla 
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                lblId.Text = fila.Cells["producto_id"].Value.ToString();

                txtCodigo.Text = fila.Cells["codigo"].Value.ToString();

                txtNombre.Text = fila.Cells["descripcion"].Value.ToString();

                txtPrecio.Text = fila.Cells["precio"].Value.ToString();

                txtStock.Text = fila.Cells["stock"].Value.ToString();

                cmbCategorias.Text = fila.Cells["categoria"].Value.ToString();
            }
        }

        








    }//Fin


}
