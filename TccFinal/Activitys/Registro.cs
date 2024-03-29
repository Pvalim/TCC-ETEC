﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using TccFinal.Resources.Model;

namespace TccFinal.Activitys
{
    [Activity(Label = "Registro")]
    public class Registro : Activity
    {
        EditText txtNovoUsuario;
        EditText txtSenhaNovoUsuario;
        Button btnCriarNovoUsuario;
         
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TelaRegistrar);
            // Create your application here

            btnCriarNovoUsuario = FindViewById<Button>(Resource.Id.btnCadastrar);
            txtNovoUsuario = FindViewById<EditText>(Resource.Id.txtNovoUsuario);
            txtSenhaNovoUsuario = FindViewById<EditText>(Resource.Id.txtNovaSenha);

            btnCriarNovoUsuario.Click += BtnCriarNovoUsuario_Click; 
        }

        private void BtnCriarNovoUsuario_Click(object sender, System.EventArgs e)
        {
            try
            {
                //definindo caminho do banco de dados
                string dbPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Usuario.db"); // Cria o Banco de Dados
                //abre o banco se não existir
                var db = new SQLiteConnection(dbPath);

                //executa um 'create table if not exists' no banco de dados
                db.CreateTable<Login>();

                //cria uma instancia de login
                Login tblogin = new Login();

                //atribui nome e senha informados
                tblogin.Usuario = txtNovoUsuario.Text;
                tblogin.Senha = txtSenhaNovoUsuario.Text;

                //inclui na tabela
                db.Insert(tblogin);
                Toast.MakeText(this, "Cadastro feito com sucesso!!", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
            
        } 
    }
}