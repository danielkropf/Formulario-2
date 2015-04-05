using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Formulario_de_Funcionarios
{
    public partial class Form1 : Form
    {

        List<Funcionario> funcionarios = new List<Funcionario>();
        List<string> nomeFuncionarios = new List<string>();
        List<string> usuarios = new List<string>();
        List<string> senhas = new List<string>();
        List<string> funcoes = new List<string>();
        public int numFuncionarios = 0;
        public int numUsers = 0;
        public int userAtual;
        public bool existe = false;
        public string line;
        public bool loged = false;

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
        public void salvarTxt() {
            if (System.IO.File.Exists("@funcionarios.txt"))
            {
                System.IO.File.Delete("@funcionarios.txt");
            }
            System.IO.StreamWriter file = new System.IO.StreamWriter("@funcionarios.txt", false);
            for (int i = 0; i < numFuncionarios; i++)
            {
                file.WriteLine(funcionarios[i].toTxt());
            }
            file.Close();
        }
        public void carregarTxt() {
            System.IO.StreamReader fileSR = new System.IO.StreamReader("@funcionarios.txt");

            while ((line = fileSR.ReadLine()) != null)
            {
                string[] info = line.Split('#');
                funcionarios.Add(new Funcionario { nome = info[0], idade = info[1], sexo = info[2], tipoSanguineo = info[3], estadoCivil = info[4], pais = info[5], estado = info[6], cidade = info[7], bairro = info[8], rua = info[9], complemento = info[10], cargo = info[11], email = info[12], filhos = info[13], telefone = info[14], salario = info[15]});
                nomeFuncionarios.Add(info[0]);
                listaFuncionarios.AutoCompleteCustomSource.Add(info[0]);
                listaFuncionarios.Items.Add(info[0]);
                nomeTxtBox.AutoCompleteCustomSource.Add(info[0]);

                numFuncionarios++;
            }
            fileSR.Close();
        }
        public void carregarUsers() {
            System.IO.StreamReader fileSR2 = new System.IO.StreamReader("@login.txt");

            while ((line = fileSR2.ReadLine()) != null)
            {
                string[] info = line.Split('&');
                usuarios.Add(info[0]);
                senhas.Add(info[1]);
                funcoes.Add(info[2]);
                numUsers++;
            }
            fileSR2.Close();
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
                    MessageBox.Show("Funcionario adicionado.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    listBox.Items.Add("Nome: " + funcionarios[i].nome);
                    listBox.Items.Add("Idade: " + funcionarios[i].idade);
                    listBox.Items.Add("Sexo:           " + funcionarios[i].sexo);
                    listBox.Items.Add("Tipo Sanguineo: " + funcionarios[i].tipoSanguineo);
                    listBox.Items.Add("Estado Civil: " + funcionarios[i].estadoCivil);
                    listBox.Items.Add("País: " + funcionarios[i].pais);
                    listBox.Items.Add("Estado: " + funcionarios[i].estado);
                    listBox.Items.Add("Cidade: " + funcionarios[i].cidade);
                    listBox.Items.Add("Bairro: " + funcionarios[i].bairro);
                    listBox.Items.Add("Rua: " + funcionarios[i].rua);
                    listBox.Items.Add("Complemento: " + funcionarios[i].complemento);
                    listBox.Items.Add("Cargo: " + funcionarios[i].cargo);
                    listBox.Items.Add("E-Mail: " + funcionarios[i].email);
                    listBox.Items.Add("Filhos: " + funcionarios[i].filhos);
                    listBox.Items.Add("Telefone: " + funcionarios[i].telefone);
                    listBox.Items.Add("Salario: " + funcionarios[i].salario);
                }
            }
        }

        private void salvarButton(object sender, EventArgs e)
        {
            salvarTxt();
        }

        private void start(object sender, EventArgs e)
        {
            carregarTxt();
            carregarUsers();
        }

        private void atualizarButton(object sender, EventArgs e)
        {
            if (nomeTxtBox.Text != "" && idadeTxtBox.Text != "" && sexoTxtBox.Text != "" && tipoSanguineoTxtBox.Text != "" && estadoCivilTxtBox.Text != "" && paisTxtBox.Text != "" && estadoTxtBox.Text != "" && cidadeTxtBox.Text != "" && bairroTxtBox.Text != "" && ruaTxtBox.Text != "" && complementoTxtBox.Text != "" && cargoTxtBox.Text != "" && emailTxtBox.Text != "" && filhosTxtBox.Text != "" && telefoneTxtBox.Text != "" && salarioTxtBox.Text != "")
            {
                removeFuncionario();
                addFuncionario();
                MessageBox.Show("Funcionario atualizado.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Preencha todos os dados antes de atualizar um funcionário.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void limparButton(object sender, EventArgs e)
        {
            nomeTxtBox.Text = "";
            idadeTxtBox.Text = "";
            sexoTxtBox.Text = "";
            tipoSanguineoTxtBox.Text = "";
            estadoCivilTxtBox.Text = "";
            paisTxtBox.Text = "";
            estadoTxtBox.Text = "";
            cidadeTxtBox.Text = "";
            bairroTxtBox.Text = "";
            ruaTxtBox.Text = "";
            complementoTxtBox.Text = "";
            cargoTxtBox.Text = "";
            emailTxtBox.Text = "";
            filhosTxtBox.Text = "";
            telefoneTxtBox.Text = "";
            salarioTxtBox.Text = "";
        }

        private void delArquivoTxt(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("@funcionarios.txt"))
            {
                System.IO.File.Delete("@funcionarios.txt");
            }
        }

        private void fazerLogin(object sender, EventArgs e)
        {
            for (int i = 0; i < numUsers; i++) {
                if (userTxtBox.Text == usuarios[i]) {
                    userAtual = i;
                    i = numUsers;
                    Debug.WriteLine(userAtual);
                }
            }
            if (senhaTxtBox.Text == senhas[userAtual])
            {
                tabLogin.Visible = false;
                mainTab.Visible = true;
            }
            else
            {
                MessageBox.Show("Usuario ou senha invalido.", "My Application", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                senhaTxtBox.Text = "";
            }
        }

    }
}
