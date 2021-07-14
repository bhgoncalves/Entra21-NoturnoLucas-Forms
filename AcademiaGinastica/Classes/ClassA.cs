﻿using AcademiaGinastica.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademiaGinastica.ClassPessoa
{
    public class Aluno : Pessoa
    {
        public string Turno { get; set; }
        public FrmModalidade Modalidade { get; set; }
        public string Pagou { get; set; }  

        public Aluno(string nome, string telefone, string cpf, string turno)
        {
            Nome = nome;
            Telefone = telefone;
            CPF = cpf;
            Turno = turno;
            Pagou = "Não.";
        }
        public override string ToString()
        {
            return $"{Nome} - {Turno} - {Modalidade} - Pagou: {Pagou}";
        }
    }
}
