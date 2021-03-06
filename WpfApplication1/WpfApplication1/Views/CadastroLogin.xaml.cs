﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.Model;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for CadastroLogin.xaml
    /// </summary>
    public partial class CadastroLogin : Window
    {
        public CadastroLogin()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Principal frm = new Principal();

            Controle controle = new Controle();

            var erro = string.Empty;
            if(String.IsNullOrEmpty(txtNome.Text)) {
                erro += "Por gentileza preencha o nome. \r\n";
            }

            if (String.IsNullOrEmpty(txtLogin.Text)) {
                erro += "Por gentileza preencha o login. \r\n";
            }

            if (String.IsNullOrEmpty(pwdSenha.Password) || String.IsNullOrEmpty(pwdSenhaConf.Password)) {
                erro += "Por gentileza preencha todos os campos de senha. \r\n";
            }

            if(pwdSenha.Password != pwdSenhaConf.Password) {
                erro += "Senha e confirmação de senha não confere. \r\n";
            }

            if(erro.Length > 0)
                MessageBox.Show(erro);//mensagem de erro
            else
            {
                string mensagem = controle.cadastrar(txtNome.Text, txtLogin.Text, pwdSenha.Password, pwdSenhaConf.Password);
                if (controle.tem) {
                    MessageBox.Show(mensagem, "Cadastro", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    MessageBox.Show(controle.mensagem);//mensagem de erro
                }
            }            
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
