using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExAviaoVetoresBiETri
{
    public partial class Form1 : Form
    {
        Button[,] btnLugares;
        Button btnOk, btnReservar;
        ComboBox cbDias;
        bool[,,] reservado = new bool[31,4,25];
        public Form1()
        {
            InitializeComponent();
            IniciarMeusComponentes();
        }
        public void IniciarMeusComponentes()
        {
            //incializar combo 
            cbDias = new ComboBox();
            cbDias.Parent = this;
            cbDias.Top = 10;
            cbDias.Left = 5;
            for (int i = 0; i < 31 ; i++)
            {
                cbDias.Items.Insert(i, i+1);
            }
            
            //incializar botões comuns
            btnOk = new Button();
            btnOk.Parent = this;
            btnOk.Text = "OK";
            btnOk.Top = 10;
            btnOk.Left = 150;
            btnOk.Click += new EventHandler(ClickBtnOk); //evento Click
    
            btnReservar = new Button();
            btnReservar.Parent = this;
            btnReservar.Text = "Reservar";
            btnReservar.Top = 10;
            btnReservar.Left = 250;
            btnReservar.Click += new EventHandler(ClickBtnReservar);

            //vetor bidimensional de botão Lugares
            btnLugares = new Button[4, 25];
            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 25; j++)
                {
                    btnLugares[i,j] = new Button();//estancia cada um
                    btnLugares[i, j].Parent = this;//designa o pai
                    btnLugares[i, j].Width = 25; // tamanhos
                    btnLugares[i, j].Height = 25;
                    btnLugares[i, j].Top = 100 + (i * 25); // posições
                    btnLugares[i, j].Left = 5 + (j * 25);
                    btnLugares[i, j].Visible = false; // invisiveis
                    btnLugares[i, j].Click += new EventHandler(ClickBtnLugares); // evento Click
                }
            }
        }
        public void ClickBtnOk(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (reservado[cbDias.SelectedIndex, i, j])
                        {
                            btnLugares[i, j].Text = "R";
                            btnLugares[i, j].Enabled = false;
                        }
                        else
                        {
                            btnLugares[i, j].Text = "L";
                            btnLugares[i, j].Enabled = true;
                        }
                        btnLugares[i, j].Visible = true;
                    }
                }
            } catch { MessageBox.Show("Selecione um dia!"); }
        }

        public void ClickBtnLugares(object sender, EventArgs e)
        {
            for (int k = 0; k < 31; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 25; j++)
                    {
                        if (btnLugares[i, j].Text == "X") btnLugares[i, j].Text = "L";
                        else ((Button)sender).Text = "X";
                    }
                }
            }
        }
        public void ClickBtnReservar(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if (btnLugares[i, j].Text == "X")
                    {
                        reservado[cbDias.SelectedIndex, i, j] = true;
                        btnLugares[i, j].Enabled = false;
                        btnLugares[i, j].Text = "R";
                    }
                }
            }
        }
    }
}
