﻿using AcademiaGinastica.ClassPessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AcademiaGinastica
{
    public partial class FrmProfessor : Form
    {
        Academia _academia;
        int selecInde = -1;
        public FrmProfessor(Academia academia)
        {
            InitializeComponent();
            _academia = academia;
            BtnNovoProfessor.Hide();
            BtnDeletar.Hide();

        }

        private void LbxCadastrados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbxCadastrados.SelectedIndex >= 0)
            {
                BtnCadastrarProfessor.Text = "Atulizar";
                BtnNovo.Hide();
                BtnNovoProfessor.Show();
                BtnDeletar.Show();
                selecInde = LbxCadastrados.SelectedIndex;
                TxtNome.Text = _academia.ListaProfessores[LbxCadastrados.SelectedIndex].Nome;
                MtbCPF.Text = _academia.ListaProfessores[LbxCadastrados.SelectedIndex].CPF;
                MtbTelefone.Text = _academia.ListaProfessores[LbxCadastrados.SelectedIndex].Telefone;
                CmbTurno.SelectedItem = _academia.ListaProfessores[LbxCadastrados.SelectedIndex].Turno;
            }
        }

        private void BtnCadastrarProfessor_Click(object sender, EventArgs e)
        {
       
            if(selecInde <0)
            {
                _academia.AddProfessor(TxtNome.Text, MtbTelefone.Text, MtbCPF.Text, CmbTurno.Text);
                Limpar();

            }
            else
            {
                _academia.AtualizarProfessor(selecInde, TxtNome.Text, MtbTelefone.Text, MtbCPF.Text, CmbTurno.Text);
            }
            AtualizarLista();
        }
        private void AtualizarLista()
        {
            LbxCadastrados.Items.Clear();
            foreach(var itens in _academia.ListaProfessores)
            {
                LbxCadastrados.Items.Add(itens.ToString());
            }
        }
        private void Limpar()
        {
            TxtNome.Clear();
            MtbCPF.Clear();
            MtbTelefone.Clear();
            CmbTurno.SelectedItem = null;
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Limpar();
            LbxCadastrados.SelectedIndex = -1;
            selecInde = -1;
        }

        private void BtnNovoProfessor_Click(object sender, EventArgs e)
        {
            Limpar();
            LbxCadastrados.SelectedIndex = -1;
            selecInde = -1;
            BtnCadastrarProfessor.Text = "Cadastrar Professor";
            BtnNovo.Show();
            BtnDeletar.Hide();
            BtnNovoProfessor.Hide();
        }

        private void BtnDeletar_Click(object sender, EventArgs e)
        {
            if (LbxCadastrados.SelectedIndex >= 0)
            {
                _academia.DeletarProfessor(LbxCadastrados.SelectedIndex);
                AtualizarLista();
                if (LbxCadastrados.Items.Count == 0)
                {
                    BtnNovoProfessor_Click(sender, e);
                }
                else
                {
                    LbxCadastrados.SelectedIndex = 0;
                }
            }
        }
    }
}
