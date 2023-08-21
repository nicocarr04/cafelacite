using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace nicolascarriere
{
    public partial class MainWindow : Window
    {
        public SqlConnection conDB;
        public string? CodeSelectionner;
        public MainWindow()
        {

            InitializeComponent();
            // Mon lien de connection (un objet)
            conDB = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");

            // Important car il sont nécessaire d'être charger au début du programme.
            TailleInserer();
            ChargerCommande();

        }

        private void TailleInserer()
        {
            // Créer un item qui est utiliser temporairement.
            ComboBoxItem itemTempo = new ComboBoxItem();
            itemTempo.Content = "Selectionner..";
            itemTempo.IsEnabled = false;

            // Ici ont insère les items dans la comboBox type.
            cbTaille.Items.Insert(0, itemTempo);
            cbTaille.Items.Insert(1, "Petit");
            cbTaille.Items.Insert(2, "Moyen");
            cbTaille.Items.Insert(3, "Grand");
            cbTaille.SelectedIndex = 0;
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // Vérification importante et retourne erreur si jamais pas correcte.
            try
            {
                var conBD = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");
                string maRequete = "INSERT INTO Commande VALUES (@Boisson, @Prix, @Taille, @Type)";

                //Ma commande
                SqlCommand cmd = new SqlCommand(maRequete, conBD);

                cmd.CommandType = CommandType.Text; //Comment exécuter ma requête

                //Récupérer les informations à mettre dans les paramètres
                cmd.Parameters.AddWithValue("@Boisson", txtBoisson.Text);
                cmd.Parameters.AddWithValue("@Prix", txtPrix.Text);
                cmd.Parameters.AddWithValue("@Taille", cbTaille.Text);
                cmd.Parameters.AddWithValue("@Type", cbType.Text);

                conBD.Open(); //Ouvrir la connexion
                cmd.ExecuteNonQuery(); //Exécuter la requête
                conBD.Close(); //Fermer la connexion

                //Afficher un message de confirmation
                MessageBox.Show("Ajout fait avec succès!", "Confirmation");

                Reinitialiser();
                ChargerCommande();
            } catch
            {
                MessageBox.Show("Erreur s'il vous plaît remplir tous les textes, box ou c'est vide.", "Erreur");
            }
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            // Vérification importante et retourne erreur si jamais pas correcte.
            try
            {
                var conBD = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");
                string maRequete = "UPDATE Commande SET Boisson = '" + txtBoisson.Text + "' WHERE Code = '" + CodeSelectionner + "'";
                string maRequete2 = "UPDATE Commande SET Prix = '" + txtPrix.Text + "' WHERE Code = '" + CodeSelectionner + "'";
                string maRequete3 = "UPDATE Commande SET Taille = '" + cbTaille.Text + "' WHERE Code = '" + CodeSelectionner + "'";
                string maRequete4 = "UPDATE Commande SET Type = '" + cbType.Text + "' WHERE Code = '" + CodeSelectionner + "'";

                //Ma commande
                SqlCommand cmd = new SqlCommand(maRequete, conBD);
                SqlCommand cmd2 = new SqlCommand(maRequete2, conBD);
                SqlCommand cmd3 = new SqlCommand(maRequete3, conBD);
                SqlCommand cmd4 = new SqlCommand(maRequete4, conBD);

                cmd.CommandType = CommandType.Text; //Comment exécuter ma requête
                cmd2.CommandType = CommandType.Text; //Comment exécuter ma requête
                cmd3.CommandType = CommandType.Text; //Comment exécuter ma requête
                cmd4.CommandType = CommandType.Text; //Comment exécuter ma requête

                conBD.Open(); //Ouvrir la connexion
                cmd.ExecuteNonQuery(); // Exécuter la requête
                cmd2.ExecuteNonQuery(); // Exécuter la requête
                cmd3.ExecuteNonQuery(); // Exécuter la requête
                cmd4.ExecuteNonQuery(); // Exécuter la requête
                conBD.Close(); //Fermer la connexion

                //Afficher un message de confirmation
                MessageBox.Show("Modification fait avec succès!", "Confirmation");

                Reinitialiser();
                ChargerCommande();
            } catch
            {
                MessageBox.Show("Erreur s'il vous plaît remplir tous les textes, box ou c'est vide.", "Erreur");
            }
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            // Vérification importante et retourne erreur si jamais pas correcte.
            try
            {
                var conBD = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");
                //Ma requête
                string maRequete = "DELETE FROM Commande WHERE Code = " + CodeSelectionner;

                //Ma commande
                SqlCommand cmd = new SqlCommand(maRequete, conBD);

                conBD.Open(); //Ouvrir la connexion
                cmd.ExecuteNonQuery(); //Exécuter la requête
                conBD.Close(); //Fermer la connexion

                //Afficher un message de confirmation
                MessageBox.Show("Suppression faite avec succès!", "Confirmation");

                Reinitialiser();
                ChargerCommande();
            }
            catch
            {
                MessageBox.Show("Erreur s'il vous plaît remplir tous les textes, box ou c'est vide.", "Erreur");
            }
        }

        private void btnChercher_Click(object sender, RoutedEventArgs e)
        {
            // Vérification importante et retourne erreur si jamais pas correcte.
            try
            {
                if (txtCodeEcrivable.Text == "")
                {
                    ChargerCommande();
                }
                else
                {
                    conDB = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");
                    //Ma requête
                    string maRequete = "SELECT * FROM Commande WHERE Code = " + txtCodeEcrivable.Text;
                    //Ma commande
                    SqlCommand cmd = new SqlCommand(maRequete, conDB);

                    conDB.Open(); //Ouvrir la connexion

                    SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
                                                            //Stockage des données lus par DataReader dans DataTable
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    conDB.Close(); //Fermer la connexion

                    //Chargement du DataGrid avec les données stockées dans DataTable
                    dgCommande.ItemsSource = dt.DefaultView;
                }
            } catch (Exception exp)
            {
                // Oups, j'aurais du faire mieux ahah :) PS : Mais je l'ai intercepté! ;)
                MessageBox.Show($"Wow ta trouvé un bug! : {exp.Message}", "Erreur");
            }
        }

        private void Reinitialiser()
        {
            // Change leur les textes, index a leur valeur de base.
            txtCode.Text = String.Empty;
            txtBoisson.Text = String.Empty;
            txtPrix.Text = String.Empty;
            cbTaille.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
            CodeSelectionner = null;
        }

        public void ChargerCommande()
        {
            conDB = new SqlConnection(@"Data Source=DESKTOP-V0Q86QO;Initial Catalog=nicolascarriere;Integrated Security=True");
            //Ma requête
            string maRequete = "SELECT * FROM Commande";
            //Ma commande
            SqlCommand cmd = new SqlCommand(maRequete, conDB);

            conDB.Open(); //Ouvrir la connexion

            SqlDataReader dr = cmd.ExecuteReader(); //Lire les enregistrements collectés suite à l'exécution de la requête
            //Stockage des données lus par DataReader dans DataTable
            DataTable dt = new DataTable();
            dt.Load(dr);

            conDB.Close(); //Fermer la connexion

            //Chargement du DataGrid avec les données stockées dans DataTable
            dgCommande.ItemsSource = dt.DefaultView;
        }

        private void dgCommande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Un veux selectionnez la premier cellule seulement (Code)
            DataGridCellInfo cellInfo = dgCommande.SelectedCells[0];

            // Quand tu supprime un item de la base de donnée pendant qu'il est sélectionner il n'aime pas sa.
            try
            {
                // Ont store sont objet
                object cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);

                // Debug pour vérifier si bien textBlock et aussi ont regarde a l'intérieur pour utiliser sont code après
                if (cellContent is TextBlock textBlock)
                {
                    // Ont store le code dans la variable
                    CodeSelectionner = textBlock.Text;
                    // Ont l'affiche
                    txtCode.Text = textBlock.Text;
                    //Debug.WriteLine(CodeSelectionner);
                }
            } catch (Exception exp)
            {
                // Oups, j'aurais du faire mieux ahah :) PS : Mais je l'ai intercepté! ;)
                MessageBox.Show($"Wow ta trouvé un bug! : {exp.Message}", "Erreur");
            }
        }
    }
}
