using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MediaTekDocuments.model;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Fenêtre d'alerte affichant les revues dont l'abonnement expire dans moins de 30 jours
    /// </summary>
    public partial class FrmAlerte : Form
    {
        private readonly BindingSource bdgAlerteAbonnements = new BindingSource();

        /// <summary>
        /// Constructeur : initialise la fenêtre et affiche la liste des abonnements bientôt expirés
        /// </summary>
        /// <param name="lesAbonnements">liste des abonnements expirant dans moins de 30 jours</param>
        public FrmAlerte(List<AbonnementExpire> lesAbonnements)
        {
            InitializeComponent();
            RemplirAlerteAbonnementsListe(lesAbonnements);
        }

        /// <summary>
        /// Remplit le datagrid avec la liste des abonnements bientôt expirés
        /// </summary>
        /// <param name="abonnements">liste des abonnements</param>
        private void RemplirAlerteAbonnementsListe(List<AbonnementExpire> abonnements)
        {
            bdgAlerteAbonnements.DataSource = abonnements;
            dgvAlerteAbonnements.DataSource = bdgAlerteAbonnements;
            if (dgvAlerteAbonnements.Columns.Count > 0)
            {
                dgvAlerteAbonnements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvAlerteAbonnements.Columns["titre"].DisplayIndex = 0;
                dgvAlerteAbonnements.Columns["dateFinAbonnement"].DisplayIndex = 1;
            }
        }

        /// <summary>
        /// Fermeture de la fenêtre d'alerte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAlerteOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
