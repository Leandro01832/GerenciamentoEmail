﻿using business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace DesktopEmail.Formulario.FormularioPessoa
{
    public partial class FrmAdmin : FrmCrud
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        // variavel para evitar bug
        bool condicao = false;

        public FrmAdmin(BaseModel modelo, bool deletar, bool atualizar, bool detalhes)
            : base(modelo, deletar, atualizar, detalhes)
        {
            InitializeComponent();
        }

        private void FrmAdmin_Load(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            lstPermissoes.DataSource = BaseModel.modelos.OfType<Permissao>().ToList();
            lstPermissoes.SetSelected(0, false);

            if(admin.Id != 0)
            {
                txtEmail.Text = admin.Email;
                txtNome.Text = admin.Nome;
                txtSenha.Text = admin.Senha;
                foreach (var item in admin.Permissao)
                {
                    var indice = lstPermissoes.Items.IndexOf(item.Permissao);
                    lstPermissoes.SetSelected(indice, true);
                }
            }

            condicao = true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Nome = txtNome.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Email = txtEmail.Text;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            admin.Senha = txtSenha.Text;
        }

        private void lstPermissoes_SelectedValueChanged(object sender, EventArgs e)
        {
            var admin = (Admin)Modelo;
            try
            {
                if (condicao)
                {
                    SelectedObjectCollection valor = lstPermissoes.SelectedItems;
                    var objetos = valor.OfType<Permissao>().ToList();
                    admin.Permissao = new List<PermissaoFuncionario>();
                    foreach (var item in objetos)
                        admin.Permissao.Add(new PermissaoFuncionario { PermissaoId = item.Id }); 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Um erro aconteceu" + ex.Message);
            }
        }
    }
}
