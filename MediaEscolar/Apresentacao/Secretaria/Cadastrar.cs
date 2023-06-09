﻿using MediaEscolar.Modelo;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MediaEscolar.Apresentacao.Secretaria
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void Cadastrar_Load(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.PreencherComboBoxTurmas(cbxTurmas);
            cbxTurmas.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            bool isProfessor = radProfessor.Checked;
            string turmaUsuario = cbxTurmas.SelectedItem.ToString();
            String mensagem = controle.CadastrarAluno(txbNome.Text, isProfessor, turmaUsuario);
            if (controle.tem)
            {
                MessageBox.Show(controle.mensagem, "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(controle.mensagem);

            }
        }

        private void cbxTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Point lastLocation;

        private void Cadastrar_MouseDown(object sender, MouseEventArgs e)
        {
            lastLocation = e.Location;
        }

        private void Cadastrar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastLocation.X;
                this.Top += e.Y - lastLocation.Y;
            }
        }
    }
}

