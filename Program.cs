using System;

namespace Labo_TDZ_Final00_Sol
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateurClasse generateurClasse = new GenerateurClasse();
            Acteur joueur = generateurClasse.GenererClasse();
            Console.Clear();
            joueur.AfficherEtat();
            Console.ReadKey();
        }
    }
}
