using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Fenetre d'authentification
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Controleur de la fenêtre
        /// </summary>
        private FrmAuthentificationController controller;

        /// <summary>
        /// Construction des composants graphiques et appel des autres initialisations
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Initialisation : création du controleur 
        /// </summary>
        private void Init()
        {
            controller = new FrmAuthentificationController();
        }

        /// <summary>
        /// Demande au controleur de controler l'authentification
        /// </summary>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text;
            String pwd = txtPwd.Text;
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                Utilisateur utilisateur = controller.ControleAuthentification(login, pwd);
                if (utilisateur != null)
                {
                    if (utilisateur.Service != null && utilisateur.Service.Id == "CUL")
                    {
                        MessageBox.Show("Vos droits ne sont pas suffisants pour accéder à cette application.", "Accès refusé");
                        Application.Exit();
                    }
                    else
                    {
                        FrmMediatek frm = new FrmMediatek(utilisateur);
                        frm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Login ou mot de passe incorrect.", "Erreur d'authentification");
                }
            }
        }
    }
}