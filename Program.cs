using System;
using System.IO;

// Utilitaire pour remplacer des chaines de caractere dans un fichier texte
namespace ReplaceInFile
{
    internal static class Program
    {
        private const string AJOUT_EXTENSION = ".old";

        static int Main(string[] args)
        {
            if (args?.Length >= 3)
            {
                // On a des arguments sur le ligne de commande

                try
                {
                    // Recuperer les arguments de la ligne de commande
                    string nomFichier = args[0];
                    string recherche = args[1];
                    string substitution = args[2];

                    Console.WriteLine("Fichier: " + nomFichier);
                    Console.WriteLine("Recherche: " + recherche);
                    Console.WriteLine("Substitution: " + substitution);

                    // Lire le contenu du fichier
                    string contenu = File.ReadAllText(nomFichier);

                    // sauvegarder le fichier
                    string fichierRenommé = Path.ChangeExtension(nomFichier, AJOUT_EXTENSION + Path.GetExtension(nomFichier));
                    File.Move(nomFichier, fichierRenommé);

                    // Substitutions
                    contenu = contenu.Replace(recherche, substitution);

                    //Reecrire le fichier
                    File.WriteAllText(nomFichier, contenu);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine("Erreur détectée");
                    Console.Error.WriteLine(e.ToString());
                    return 1;
                }

                // Tout est OK
                return 0;
            }

            Console.WriteLine("ReplaceInFile Usage: ");
            Console.WriteLine("ReplaceInFile <nom fichier> \"<chaine a chercher>\" \"<chaine de substitution>\"");
            return 1;
        }
    }
}
