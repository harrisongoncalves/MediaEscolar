﻿using MediaEscolar.Apresentacao;
using MediaEscolar.SQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaEscolar.Modelo
{
    public class Controle
    {
        public bool tem;
        public String mensagem = "";
        public String nomeUsuario = "";
        public String matriculaUsuario = "";

        public bool acessar(String matricula, String senha)
        {
            Comandos comando = new Comandos();

            tem = comando.verificarLogin(matricula, senha);
            if (!comando.mensagem.Equals(""))
            {
                this.mensagem = comando.mensagem;
            }
            return tem;
        }

        public String cadastrar(String matricula, String senha, String confirmarSenha, bool isProfessor)
        {
            Comandos comando = new Comandos();
            this.mensagem = comando.cadastrar(matricula, senha, confirmarSenha, isProfessor);
            if (comando.tem)
            {
                return mensagem;
            }
            this.tem = true;
            return mensagem;
        }
        public int getTipoUsuario(string matricula)
        {
            int tipo = -1;
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT tipo FROM logins WHERE matricula = @matricula";
            cmd.Parameters.AddWithValue("@matricula", matricula);
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                tipo = Convert.ToInt32(dr["tipo"]);
            }

            dr.Close();
            conexao.Desconectar();

            return tipo;
        }

        public void PreencherComboBox(ComboBox cbxAlunos)
        {
            Conexao conexao = new Conexao();
            SqlConnection con = conexao.Conectar();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string query = "SELECT nome FROM logins WHERE tipo = 0";
            cmd.CommandText = query;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                cbxAlunos.Items.Add(reader["nome"].ToString());
            }

            reader.Close();
            conexao.Desconectar();
        }



    }
}
