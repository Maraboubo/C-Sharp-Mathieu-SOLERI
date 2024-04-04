namespace Porjet_vierge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
        }
        private char nbentré;
        private char opération;
        private string totalnb;
        private string total;
        /*private int nb;
        private int nb1;
        private string resultat;*/
        private int nb;
        private string[] tab = new string[100];
        private int i = 0;
        private int p = 0;
        private int k = 0;


        private void button5_Click(object sender, EventArgs e)
        {
            // bouton 5
            nbentré = '5';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // bouton 0
            nbentré = '0';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // bouton 1
            nbentré = '1';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // bouton 2
            nbentré = '2';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // bouton 3
            nbentré = '3';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // bouton 4
            nbentré = '4';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // bouton 6
            nbentré = '6';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // bouton 7
            nbentré = '7';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // bouton 8
            nbentré = '8';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // bouton 9
            nbentré = '9';
            totalnb = totalnb + nbentré;
            total = total + nbentré;
            textBox1.Text = total;
            i++;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            // bouton +
            opération = '+';
            tab[i] = totalnb;
            tab[i + 1] = "+";
            totalnb = "0";
            total = total + opération;
            textBox1.Text = total;
            i++;
            i++;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // bouton -
            opération = '-';
            tab[i] = totalnb;
            tab[i + 1] = "-";
            totalnb = "0";
            total = total + opération;
            textBox1.Text = total;
            i++;
            i++;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // bouton /
            opération = '/';
            tab[i] = totalnb;
            tab[i + 1] = "/";
            totalnb = "0";
            total = total + opération;
            textBox1.Text = total;
            i++;
            i++;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // bouton x
            opération = '*';
            tab[i] = totalnb;
            tab[i + 1] = "*";
            totalnb = "0";
            total = total + opération;
            textBox1.Text = total;
            i++;
            i++;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //Bouton (
            opération = '(';
            tab[i] = "(";

            total = total + opération;
            textBox1.Text = total;
            i++;

        }
        private void button17_Click(object sender, EventArgs e)
        {
            //Bouton )
            opération = ')';
            tab[i] = totalnb;
            tab[i + 1] = ")";
            total = total + opération;
            textBox1.Text = total;
            i++;
            i++;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            //button ^
            opération = '^';
            //tab[i] = "^";
            //totalnb = "0";
            total = total + opération;
            textBox1.Text = total;
            i++;

        }
        private void button15_Click(object sender, EventArgs e)
        {
            // bouton =
            try
            {
                i++;
                tab[i - 1] = totalnb;
                for (int n = 0; n < 2; n++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (tab[j] == "(")
                        {
                            while (tab[p] != ")")
                            {

                                if (tab[p] == "*")
                                {
                                    nb = Convert.ToInt32(tab[p - 1]) * Convert.ToInt32(tab[p + 1]);
                                    tab[p] = Convert.ToString(nb);
                                    //On remplace les valeurs inutile en";"
                                    tab[p - 1] = ";";
                                    tab[p + 1] = ";";
                                }
                                else if (tab[p] == "/")
                                {
                                    nb = Convert.ToInt32(tab[p - 1]) / Convert.ToInt32(tab[p + 1]);
                                    tab[p] = Convert.ToString(nb);
                                    //On remplace les valeurs inutile en";"
                                    tab[p - 1] = ";";
                                    tab[p + 1] = ";";
                                }
                                else if (tab[p] == "+")
                                {
                                    nb = Convert.ToInt32(tab[p - 1]) + Convert.ToInt32(tab[p + 1]);
                                    tab[p] = Convert.ToString(nb);
                                    //On remplace les valeurs inutile en";"
                                    tab[p - 1] = ";";
                                    tab[p + 1] = ";";
                                }
                                else if (tab[p] == "-")
                                {
                                    nb = Convert.ToInt32(tab[p - 1]) - Convert.ToInt32(tab[p + 1]);
                                    tab[p] = Convert.ToString(nb);
                                    //On remplace les valeurs inutile en";"
                                    tab[p - 1] = ";";
                                    tab[p + 1] = ";";
                                }
                                for (int m = j; m < k; m++) // i allant au bout du tableau...
                                {
                                    if (tab[m] == ";") //...pour chercher la valeur demander
                                    {
                                        tab[m] = tab[m + 1]; //On remplace la valeur qu'on veut supprimer par la valeur d'apres
                                        for (int l = m + 1; l < i; l++) //on commence la boucle apres la valeur enlever
                                        {

                                            tab[l - 1] = tab[l]; // On donne un aspect decalage de valeur


                                        }
                                    }
                                }
                                p++;
                            }
                            if (tab[p] == ")")
                            {
                                k = p;
                            }
                            tab[j] = ";";
                            tab[k] = ";";
                            //Et on ""enleve"" ces cases
                            for (int m = 0; m < i; m++) // i allant au bout du tableau...
                            {
                                if (tab[m] == ";") //...pour chercher la valeur demander
                                {
                                    tab[m] = tab[m + 1]; //On remplace la valeur qu'on veut supprimer par la valeur d'apres
                                    for (int h = m + 1; h < i; h++) //on commence la boucle apres la valeur enlever
                                    {

                                        tab[h - 1] = tab[h]; // On donne un aspect decalage de valeur

                                        if (h == i) //Une fois qu'on aura atteind la derniere case du tableau
                                        {
                                            tab[h] = " "; //On mets 0
                                        }

                                    }
                                }
                            }
                        }
                    }
                    for (int a = 0; a < 2; a++)
                    {
                        for (int l = 0; l < i; l++)
                        {
                            if (tab[l] == "*")
                            {
                                nb = Convert.ToInt32(tab[l - 1]) * Convert.ToInt32(tab[l + 1]);
                                tab[l] = Convert.ToString(nb);
                                //On remplace les valeurs inutile en";"
                                tab[l - 1] = ";";
                                tab[l + 1] = ";";
                            }
                            else if (tab[l] == "/")
                            {
                                nb = Convert.ToInt32(tab[l - 1]) / Convert.ToInt32(tab[l + 1]);
                                tab[l] = Convert.ToString(nb);
                                //On remplace les valeurs inutile en";"
                                tab[l - 1] = ";";
                                tab[l + 1] = ";";
                            }
                            //Et on ""enleve"" ces cases
                            for (int m = 0; m < i; m++) // i allant au bout du tableau...
                            {
                                if (tab[m] == ";") //...pour chercher la valeur demander
                                {
                                    tab[m] = tab[m + 1]; //On remplace la valeur qu'on veut supprimer par la valeur d'apres
                                    for (int h = m + 1; h < i; h++) //on commence la boucle apres la valeur enlever
                                    {

                                        tab[h - 1] = tab[h]; // On donne un aspect decalage de valeur



                                    }
                                }
                            }

                        }

                        for (int x = 0; x < i; x++)
                        {
                            if (tab[x] == "+")
                            {
                                nb = Convert.ToInt32(tab[x - 1]) + Convert.ToInt32(tab[x + 1]);
                                tab[x] = Convert.ToString(nb);
                                //On remplace les valeurs inutile en";"
                                tab[x - 1] = ";";
                                tab[x + 1] = ";";
                            }
                            else if (tab[x] == "-")
                            {
                                nb = Convert.ToInt32(tab[x - 1]) - Convert.ToInt32(tab[x + 1]);
                                tab[p] = Convert.ToString(nb);
                                //On remplace les valeurs inutile en";"
                                tab[x - 1] = ";";
                                tab[x + 1] = ";";
                            }
                            //Et on ""enleve"" ces cases
                            for (int m = 0; m < i; m++) // i allant au bout du tableau...
                            {
                                if (tab[m] == ";") //...pour chercher la valeur demander
                                {
                                    tab[m] = tab[m + 1]; //On remplace la valeur qu'on veut supprimer par la valeur d'apres
                                    for (int l = m + 1; l < i; l++) //on commence la boucle apres la valeur enlever
                                    {

                                        tab[l - 1] = tab[l]; // On donne un aspect decalage de valeur



                                    }
                                }
                            }
                        }
                    }
                }
                textBox1.Text = tab[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }


    }
}

