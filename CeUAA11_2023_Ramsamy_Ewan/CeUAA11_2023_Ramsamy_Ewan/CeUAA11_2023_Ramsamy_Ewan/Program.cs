using System;

namespace CeUAA11_2023_Ramsamy_Ewan
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodesDuProjet Outils = new MethodesDuProjet();

            int choix = 0;
            string[,] matrice =new string[0,0];
            string recom;
            string phClaire;
            string phClef;
            int a = 0;
            int b = 0;


            do
            {
                Console.WriteLine("Choisissez parmi les options suivantes : \n 1 = Cryptage de Vigenère \n 2 = Cryptage avec la méthode affine");
                choix = int.Parse(Console.ReadLine());

                if(choix == 1)
                {
                    Outils.DemanderPhraseAvecVerification("Quelle phrase voulez-vous crypter ?", out phClaire);
                    Outils.DemanderPhraseAvecVerification("Quelle clé voulez-vous utiliser ?", out phClef);
                    phClaire = Outils.RetireEspaces(phClaire);
                    phClef = Outils.RetireEspaces(phClef);
                    Outils.CryptVigenere(phClaire, phClef, ref matrice);
                }
                else if (choix == 2)
                {
                    Outils.DemanderPhraseAvecVerification("Quelle phrase voulez-vous crypter ?", out phClaire);
                    phClaire = Outils.RetireEspaces(phClaire);
                    Outils.CryptAffine(phClaire, a, b, ref matrice);
                }
                

                // Demande reprise
                Console.WriteLine("Un autre cryptage ? (oui = espace non = autre)");
                recom = Console.ReadLine();
            } while (recom == " ");

            Console.ReadLine();
        }
    }
}
