using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AIS.Repositories;
using AIS.Models;

namespace AIS
{
    public partial class LoginForm : Form
    {
        UserRepository repo = new UserRepository();

        public LoginForm()
        {
            InitializeComponent();   
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtUsername.Text;
            string password = txtPassword.Text;

            var user = repo.GetAllUsers()
                           .FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user == null)
            {
                lblError.Text = "Invalid login or password!";
                return;
            }

            // SUCCESS LOGIN
            lblError.Text = "";
            MessageBox.Show($"Welcome, {user.FirstName}! Role: {user.Role}");

            // open different UI based on role
            //if (user.Role == "admin") new AdminForm().Show();
            //else if (user.Role == "teacher") new TeacherForm().Show();
            //else new StudentForm().Show();

            this.Hide();
        }
    }
}

