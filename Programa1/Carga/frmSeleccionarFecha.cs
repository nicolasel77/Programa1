namespace Programa1.Carga
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class frmSeleccionarFecha : Form
    {
        public DateTime FechaSeleccionada { get; set; }
        public string StoreProcedure { get; set; }
        public int IdFacura { get; set; }
        public int Sucursal { get; internal set; }

        public frmSeleccionarFecha()
        {
            InitializeComponent();
            FechaSeleccionada = DateTime.Now;
            monthCalendar1.SelectionStart = DateTime.Now;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            FechaSeleccionada = monthCalendar1.SelectionStart;
            lblFechaSeleccionada.Text = $"Fecha seleccionada: {FechaSeleccionada:dd/MM/yyyy}";
        }

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(StoreProcedure))
            {
                MessageBox.Show("No se especificó el nombre del stored procedure.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                using (SqlConnection conexion = new SqlConnection(Programa1.Properties.Settings.Default.dbDatosConnectionString))
                {
                    using (SqlCommand comando = new SqlCommand(StoreProcedure, conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros
                        comando.Parameters.AddWithValue("@F", FechaSeleccionada);
                        comando.Parameters.AddWithValue("@S", Sucursal);
                        
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                    }
                }

                MessageBox.Show("Fecha actualizada correctamente.", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el stored procedure: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Cursor = Cursors.Default;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}