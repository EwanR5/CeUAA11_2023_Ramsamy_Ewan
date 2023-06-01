using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA11_2023_Ramsamy_Ewan
{
    public struct MethodesDuProjet
    {
        public string RetireEspaces(string chaine)
        {
            string newChaine = "";
            string carExt;
            int lg = chaine.Length;
            for (int i = 0; i < lg; i++)
            {
                carExt = chaine.Substring(i, 1);
                if (carExt != " ")
                {
                    newChaine += carExt;
                }
            }
            return newChaine;
        }
        public void CryptVigenere(string phClaire, string phClef, ref string[,] matVigenere)
        {
            string[,] matVigenere = new string[4, phClaire.Length];
            int j = 0;

            for (int i = 0; i < phClaire.Length-1; i++)
            {
                matVigenere[0, i] = Convert.ToChar(phClaire[i]).ToString();

                if (j == phClef.Length)
                {
                    j = 0;
                }

                matVigenere[1, i] = Convert.ToChar(phClaire[i]).ToString();
                matVigenere[2, i] = ((int)phClef[j] - 65).ToString();
                
                if (((int)phClaire[i] + int.Parse(matVigenere[2, i])) <= 90)
                {
                    int codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]);
                }
                else
                {
                    int codeAscii = (int)char.Parse(matVigenere[0, i]) + int.Parse(matVigenere[2, i]) - 26;
                }

                matVigenere[3, i] = Convert.ToChar(codeAscii).ToString();
                j = j + 1;
            }
        }
        public void CryptAffine(string phClaire, int a, int b, ref string[,] matAffine)
        {
            string[,] matAffine = new string[4, phClaire.Length];

            for (int i = 0; i < phClaire.Length - 1; i++)
            {
                matAffine[0, i] = Convert.ToChar(phClaire[i]).ToString();
                int x = (int)phClaire[i] - 65;
                matAffine[1, i] = Convert.ToChar(x).ToString();
                int y = (a * x + b) % 26;
                matAffine[2,i] = Convert.ToChar(y).ToString();
                matAffine[3, i] = Convert.ToChar(y).ToString() + 65;
            }
        }
        public void DemanderPhraseAvecVerification(string question, out string resultat)
        {
            bool uneFois = false; // Variable qui permet de savoir si l’utilisateur à déjà fait une erreur
            do
            {
                if (uneFois) Console.WriteLine("/!\\ Pouvez-vous recommencer, votre entrée n'était pas bonne (doit contenir uniquement MAJ, min et espace).");
                Console.WriteLine(question);
                resultat = Console.ReadLine();
                uneFois = true;
            } while (!EntreeEstBonne(resultat));
        }
        public bool EntreeEstBonne(string entree)
        {
            for (int i = 0; i <= entree.Length - 1; i++) // i = Variable qui s’incrémente dans une boucle for (place dans le string)
            {
                int ic = entree[i]; // Valeur du caractère à la place "i" dans le string
                if (!(ic >= 65 && ic <= 90) && !(ic >= 97 && ic <= 122) && ic != 32) return false;
            }
            return true;
        }
    }
}
