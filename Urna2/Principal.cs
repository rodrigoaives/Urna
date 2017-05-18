using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Urna2
{
    public partial class Principal : Form
    {
        int eneias = 0, levi = 0, osama = 0, marina = 0, lula = 0, branco = 0, nulo = 0;
        int candidato = 0;
        private SoundPlayer fimSound;
        int tempo;

        private void btnConf_Click(object sender, EventArgs e)
        {
            timerFim_Voto.Start();

            if (brancoImagem.Visible == true)
            {
                candidato = 0;
            }
            else 

                candidato = Convert.ToInt32(numCandidato.Text);

                switch (candidato)
                {
                    case 0:
                        branco = branco + 1;
                        totalBranco.Text = Convert.ToString(branco);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;

                    case 1:
                        eneias = eneias + 1;
                        totalEneias.Text = Convert.ToString(eneias);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;

                    case 2:
                        levi = levi + 1;
                        totalLevi.Text = Convert.ToString(levi);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;

                    case 3:
                        osama = osama + 1;
                        totalOsama.Text = Convert.ToString(osama);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;

                    case 4:
                        marina = marina + 1;
                        totalMarina.Text = Convert.ToString(marina);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;

                    case 5:
                        lula = lula + 1;
                        totalLula.Text = Convert.ToString(lula);
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;


                    default:
                        nuloImagem.Visible = true;
                        nulo = nulo + 1;
                        totalNulo.Text = Convert.ToString(nulo);
                        nuloImagem.Visible = false;
                        fimImagem.Visible = true;
                        numCandidato.Visible = false;
                        fimSound.Play();
                    break;
                }           

            if (eneias > levi && eneias > osama && eneias > marina && eneias > lula)
            {
                nomeMaisVotado.Text = "Eneias";
            }
            else if (levi > eneias && levi > osama && levi > marina && levi > lula)
            {
                nomeMaisVotado.Text = "Levi";
            }
            else if (osama > eneias && osama > levi && osama > marina && levi > lula)
            {
                nomeMaisVotado.Text = "Osama";
            }
            else if (marina > eneias && marina > levi && marina > osama && marina > lula)
            {
                nomeMaisVotado.Text = "Marina";
            }
            else if (lula > eneias && lula > levi && lula > osama && lula > marina)
            {
                nomeMaisVotado.Text = "Lula";
            }
        }

        private void timerFim_Voto_Tick(object sender, EventArgs e)
        {
            timerFim_Voto.Stop();
            panel1.Visible = true;
            exibeNome.Text = "";
            numCandidato.Text = "";
            exibePartido.Text = "";
            fotoCandidato.Image = null;
            nuloImagem.Visible = false;
            brancoImagem.Visible = false;
            fimImagem.Visible = false;
            numCandidato.Visible = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Votação reiniciada!");
            timerEncerrar.Start();
            panel1.Visible = true;
            exibeNome.Text = "";
            numCandidato.Text = "";
            exibePartido.Text = "";
            fotoCandidato.Image = null;
            nuloImagem.Visible = false;
            brancoImagem.Visible = false;
            fimImagem.Visible = false;
            panel2.Visible = false;
            
        }

        private void timerTempoRestante_Tick(object sender, EventArgs e)
        {
            if (tempo > 0)
            {
                tempo = tempo - 1;
                lblTempo.Text = tempo + "seconds";
            }
            else
            {
                timerTempoRestante.Stop();
                lblTempo.Text = ("Acabou");
            }        
    }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            timerEncerrar.Start();
            MessageBox.Show("Votação iniciada!");
        }        
        private void timerEncerrar_Tick(object sender, EventArgs e)
        {
            timerEncerrar.Stop();
            MessageBox.Show ("Votação encerrada!");
            panel2.Visible = true;
            exibeNome.Text = "";
            numCandidato.Text = "";
            exibePartido.Text = "";
            fotoCandidato.Image = null;
            nuloImagem.Visible = false;
            brancoImagem.Visible = false;
            fimImagem.Visible = false;
            numCandidato.Visible = true;
            btnConf.Enabled = false;
            btnBranco.Enabled = false;
            btnCorrige.Enabled = false;
       }
        

        public Principal()
        {
            InitializeComponent();
            fimSound = new SoundPlayer("fim.wav");
        }

        private void btnBranco_Click(object sender, EventArgs e)
        {
            brancoImagem.Visible = true;
            numCandidato.Visible = false;
        }

        private void btnCorrige_Click(object sender, EventArgs e)
        {
            exibeNome.Text = "";
            numCandidato.Text = "";
            exibePartido.Text = "";
            fotoCandidato.Image = null;
            nuloImagem.Visible = false;
            brancoImagem.Visible = false;
            fimImagem.Visible = false;
        }

        private void btnNumerador_Click(object sender, EventArgs e)
        {
            if (timerEncerrar.Enabled)
            {
                Button bt = (Button)sender;
                numCandidato.Text = numCandidato.Text + bt.Text;
                candidato = Convert.ToInt16(numCandidato.Text);

                switch (candidato)
                {
                    case 1:
                        exibeNome.Text = "Eneias";
                        exibePartido.Text = "Doidos";
                        fotoCandidato.Image = Urna2.Properties.Resources.eneias;
                        break;

                    case 2:
                        exibeNome.Text = "Levi";
                        exibePartido.Text = "Aerotrem";
                        fotoCandidato.Image = Urna2.Properties.Resources.levi;
                        break;

                    case 3:
                        exibeNome.Text = "Osama";
                        exibePartido.Text = "Clan Loco";
                        fotoCandidato.Image = Urna2.Properties.Resources.osama;
                        break;

                    case 4:
                        exibeNome.Text = "Marina";
                        exibePartido.Text = "Arvorezinha";
                        fotoCandidato.Image = Urna2.Properties.Resources.marina;
                        break;

                    case 5:
                        exibeNome.Text = "Lula";
                        exibePartido.Text = "Meu coração \n deu PT";
                        fotoCandidato.Image = Urna2.Properties.Resources.lula;
                        break;

                    default:
                        nuloImagem.Visible = true;
                        numCandidato.Visible = false;
                        break;
                }
            }
            else
                MessageBox.Show("Clique em Iniciar votação.");
            }
        }
   }
