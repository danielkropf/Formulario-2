using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_de_Funcionarios
{
    public partial class Form1 : Form
    {

        List<Funcionario> funcionarios = new List<Funcionario>();
        List<string> nomeFuncionarios = new List<string>();
        public int numFuncionarios = 0;
        public bool existe = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void addFuncionario() {

            funcionarios.Add(new Funcionario { nome = nomeTxtBox.Text, idade = idadeTxtBox.Text, sexo = sexoTxtBox.Text, tipoSanguineo = tipoSanguineoTxtBox.Text, estadoCivil = estadoCivilTxtBox.Text, pais = paisTxtBox.Text, estado = estadoCivilTxtBox.Text, cidade = cidadeTxtBox.Text, bairro = bairroTxtBox.Text, rua = ruaTxtBox.Text, complemento = complementoTxtBox.Text, cargo = cargoTxtBox.Text, email = emailTxtBox.Text, filhos = filhosTxtBox.Text, telefone = telefoneTxtBox.Text, salario = salarioTxtBox.Text });
            nomeFuncionarios.Add(nomeTxtBox.Text);
            listaFuncionarios.Items.Add(nomeTxtBox.Text);
            listaFuncionarios.AutoCompleteCustomSource.Add(nomeTxtBox.Text);
            nomeTxtBox.AutoCompleteCustomSource.Add(nomeTxtBox.Text);
            numFuncionarios++;
        }
        public void removeFuncionario() {

            funcionarios.Remove(new Funcionario { nome = nomeTxtBox.Text});
            nomeFuncionarios.Remove(nomeTxtBox.Text);
            listaFuncionarios.Items.Remove(nomeTxtBox.Text);
            listaFuncionarios.AutoCompleteCustomSource.Remove(nomeTxtBox.Text);
            nomeTxtBox.AutoCompleteCustomSource.Remove(nomeTxtBox.Text);
            numFuncionarios--;
        }

        private void addButton(object sender, EventArgs e)
        {
            existe = false;
            for (int i = 0; i < numFuncionarios; i++ )
            {
                if (nomeTxtBox.Text == nomeFuncionarios[i]) {
                    existe = true;
                    i = numFuncionarios;
                }
            }
            if (!existe)
            {
                if (nomeTxtBox.Text != "" && idadeTxtBox.Text != "" && sexoTxtBox.Text != "" && tipoSanguineoTxtBox.Text != "" && estadoCivilTxtBox.Text != "" && paisTxtBox.Text != "" && estadoTxtBox.Text != "" && cidadeTxtBox.Text != "" && bairroTxtBox.Text != "" && ruaTxtBox.Text != "" && complementoTxtBox.Text != "" && cargoTxtBox.Text != "" && emailTxtBox.Text != "" && filhosTxtBox.Text != "" && telefoneTxtBox.Text != "" && salarioTxtBox.Text != "")
                {
                    addFuncionario();
                }
                else
                {
                    MessageBox.Show("Preencha todos os dados antes de adicionar um funcionário.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Esse funcionário já existe.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void removeButton(object sender, EventArgs e)
        {
            if (nomeTxtBox.Text != "")
            {
                removeFuncionario();
            }
            else
            {
                MessageBox.Show("Preencha o nome do funcionário que deseja remover.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void verButton(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            for (int i = 0; i < numFuncionarios; i++ )
            {
                if (funcionarios[i].nome == listaFuncionarios.Text) {
                    listBox.Items.Add(funcionarios[i].nome);
                    listBox.Items.Add(funcionarios[i].idade);
                    listBox.Items.Add(funcionarios[i].sexo);
                    listBox.Items.Add(funcionarios[i].tipoSanguineo);
                    listBox.Items.Add(funcionarios[i].estadoCivil);
                    listBox.Items.Add(funcionarios[i].pais);
                    listBox.Items.Add(funcionarios[i].estado);
                    listBox.Items.Add(funcionarios[i].cidade);
                    listBox.Items.Add(funcionarios[i].bairro);
                    listBox.Items.Add(funcionarios[i].rua);
                    listBox.Items.Add(funcionarios[i].complemento);
                    listBox.Items.Add(funcionarios[i].cargo);
                    listBox.Items.Add(funcionarios[i].email);
                    listBox.Items.Add(funcionarios[i].filhos);
                    listBox.Items.Add(funcionarios[i].telefone);
                    listBox.Items.Add(funcionarios[i].salario);
                }
            }
        }

    }
}
