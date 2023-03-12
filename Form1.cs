using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecrypteGame
{
    public partial class Form1 : Form
    {
        string idLabelClick = "";
        string idRectangleClick = "";
        Dictionary<char, char> dico = new Dictionary<char, char>();

        string texteOriginal = "";
        string texte = "";
        

        public Form1()
        {
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            InitializeComponent();
            //tb_text.BackColor
            //potentiellement important, je n'ai jamais fini cet endroit (note de moi du 12/03/2023)



            //tb_text.
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //tb_text.BackColor = System.Drawing.Color.Transparent;
            

            //tb_text.Focused = false;
            tb_text.Text = "Il court, il court le furet. Le furet du bois jolie. Il est passe par ici, il repassera par la. \n wesh".ToUpper();
            texteOriginal = tb_text.Text;

            //on choisit un nombre aléatoire entre 1 et 10 (ce qui permet de choisir l'un des 10 textes

            //On randomize ensuite chaque lettre pour créer un nouveau dictionnaire
            if (true)
            {
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                Dictionary<char, char> dicoGeneration = new Dictionary<char, char>();
                Random alea = new Random();
                int aleat = alea.Next(3, 10);

                for (int i = 0; i < alphabet.Length; i++)
                {
                    char lettre = alphabet[i];
                    char lettreEncode = alphabet[(i + aleat) % alphabet.Length];
                    dicoGeneration.Add(lettre, lettreEncode);
                }

                string res = "";
                for (int i = 0; i < texteOriginal.Length; i++)
                {
                    char c = texteOriginal[i];
                    char cEncode = c;
                    if (dicoGeneration.ContainsKey(c))
                    {
                         dicoGeneration.TryGetValue(c, out cEncode);
                    }
                    res += cEncode;
                }

                tb_text.Text = res;
                texte = res;
            }


            //Ajouter la possibiliter de rajouter un texte (il va falloir gérer les accents (é, è, à, ô, ê, etc))
            //Et aussi de définir s'il est randomize de base ou non (donc si on applique l'algorithme de randomize ou non)
            //Ajouter la possibiliter de choisir l'un des textes
        }

        public Dictionary<char, char> equivalent(Dictionary<char, char> dico, char lettreKey, char lettreValue)
        {
            //Dictionary<char, char> dico = new Dictionary<char, char>();
            if (dico.ContainsKey(lettreKey))
            {
                dico.Remove(lettreKey);
                dico.Add(lettreKey, lettreValue);
            }
            else
            {
                dico.Add(lettreKey, lettreValue);
            }
            return dico;
        }

        public string modification(string text, Dictionary<char, char> dico)
        {
            //string text = tb_text.Text;
            string res = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (dico.ContainsKey(text[i]))
                {
                    char c;
                    dico.TryGetValue(text[i], out c);
                    res += c;
                    
                    //res += dico.
                }
                else
                {
                    res += text[i];
                }
                
            }
            return res;
        }

        private void selection_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            //Test si le label appartient au premier triangle ou non
            /*if (rectangle1.Contains(lbl))
            {
                tb_test2.Text = "rectangle1";
                idRectangleClick = "rectangle1";
            }
            else
            {
                tb_test2.Text = "rectangle2";
                idRectangleClick = "rectangle2";
            }

            if (idLabelClick == "")
            {
                //tb_test.Text = sender.ToString();
                /*tb_test.Text = sender.ToString.Text;
                sender.ToString().*/


            //lbl.Text = "P";
            /* tb_test.Text = lbl.Text;
             idLabelClick = lbl.Text;
             lbl.ForeColor = System.Drawing.Color.Blue;
             }
             else if (idLabelClick == lbl.Text)
             {
                 idLabelClick = "";
                 //lbl.ForeColor = System.Drawing.Color.Black;
                 lbl.ForeColor = System.Drawing.Color.Pink;
             }*/

            //Test si le lable fait partit du triangle 1 (sinon 2)
            if (rectangle1.Contains(lbl))
            {
                tb_test2.Text = "rectangle1";
                idRectangleClick = "rectangle1";

                if (idLabelClick == "")
                {
                    //l.ForeColor = System.Drawing.Color.Blue;
                    idLabelClick = lbl.Text;
                    lbl.ForeColor = System.Drawing.Color.Aqua;
                }
                else if (idLabelClick == lbl.Text)
                {
                    idLabelClick = "";
                    idRectangleClick = "";
                    lbl.ForeColor = System.Drawing.Color.Black;
                }
            }
            else if(idRectangleClick == "rectangle1")
            {
                tb_test2.Text = "rectangle2";
                idRectangleClick = "rectangle2";

                char idLabel1 = idLabelClick[0];
                char idLabel2 = lbl.Text[0];
                //string idLabel2 = lbl.Text;

                if (idLabel2 != idLabel1)
                {
                    idLabelClick = "";
                    idRectangleClick = "";
                    lbl.ForeColor = System.Drawing.Color.Aqua;
                    equivalent(dico, idLabel1, idLabel2);
                    tb_text.Text = modification(texte, dico);
                    //tb_text.Text = "";

                    if (texte == texteOriginal)
                    {
                        MessageBox.Show("Vous eavez reussi ! Bien joué !");
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //this.Text;
            //Dictionary<char, char> dico = new Dictionary<char, char>();
            string text = "bonjour. ceci est un test qui test.".ToUpper();

            text = modification(text, dico);

            tb_text.Text = text;

            label1.ForeColor = System.Drawing.Color.Red;
            //ctxMenu.Show();
        }

        private void bt_dico_Click(object sender, EventArgs e)
        {
            //Lire les valeurs du dictionnaire
            string res = "";
            foreach(var item in dico)
            {
                res += item.Key;
                res += " = ";
                res += item.Value;
                res += "\n";
            }
            tb_dico.Text = res;
        }
    }
}
