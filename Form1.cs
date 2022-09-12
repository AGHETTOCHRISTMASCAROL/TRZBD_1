using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace trzbd_authorization_savrikov
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        static string connectionString = @"Data Source=CAROLMACHINE;Initial Catalog=MDK11-SAVRIKOV-20101;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        private void BtnStart_Click(object sender, EventArgs e) //нажатие на кнопку "Вход"
        {
                connection.Open();

                SqlCommand cmdAuthorization = new SqlCommand($"SELECT * FROM [User] WHERE login = '{tbLogin.Text}' AND password = '{tbPassword.Text}'", connection);

                if (cmdAuthorization.ExecuteScalar() != null) //Считываем значение первого столбца в первой строке результатов
                    lblResult.Text = "Вы вошли";
                else
                    lblResult.Text = "Попробуйте снова";

                connection.Close();
        }
    }
}