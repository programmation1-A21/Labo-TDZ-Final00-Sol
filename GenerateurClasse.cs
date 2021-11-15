using System;
using System.IO;

namespace Labo_TDZ_Final00
{
    class GenerateurClasse
    {
        public string[] Questions { get; set; }
        public Acteur[] Classes { get; set; }
        public int Guerrier { get; set; } = 0;
        public int Magicien { get; set; } = 0;
        public int Voleur { get; set; } = 0;

        public GenerateurClasse()
        {
            Questions = new string[3];
            Classes = new Acteur[3];
            StreamReader lecteur = new StreamReader(@"questions.txt");
            int i = 0;
            while (!lecteur.EndOfStream)
            {
                Questions[i] = lecteur.ReadLine();
                i++;
            }
            lecteur.Close();

            lecteur = new StreamReader(@"classes.txt");
            i = 0;
            while (!lecteur.EndOfStream)
            {
                Classes[i] = DecoderClasse(lecteur.ReadLine().Split(','));
                i++;
            }
            lecteur.Close();
        }

        private Acteur DecoderClasse(string[] classe)
        {
            int maxHp = 0;
            int maxArmure = 0;
            int regenArmure = 0;
            int agilite = 0;
            int dommage = 0;
            int.TryParse(classe[1], out maxHp);
            int.TryParse(classe[2], out maxArmure);
            int.TryParse(classe[3], out regenArmure);
            int.TryParse(classe[4], out agilite);
            int.TryParse(classe[5], out dommage);
            Acteur acteur = new Acteur(classe[0], maxHp, maxArmure, regenArmure, agilite, dommage);
            return acteur;
        }

        public Acteur GenererClasse()
        {
            string classeMagicien = "Tu es un maître de l'arcane et des éléments. Mais les années d'étude et de recherche ne t'ont pas laissé l'occasion de développer ton physique.";
            string classeGuerrier = "Une brute sanguinaire ou un noble chevalier, à toi de décider. Tu es endurant, rapide et un maître des arts martiaux. Pas le crayon le plus aiguisé de la boîte par contre...";
            string classeVoleur = "Tu es une racaille de la pire espèce, prêt à poignarder, mentir et voler pour une poignée de piécettes";

            int choix = 0;
            for (int i = 0; i < this.Questions.Length - 1; i++)
            {
                choix = PoserQuestion(this.Questions[i]);
                switch (choix)
                {
                    case 1:
                        this.Guerrier++;
                        break;
                    case 2:
                        this.Magicien++;
                        break;
                    case 3:
                        this.Voleur++;
                        break;
                }
            }

            choix = 0;
            if (this.Guerrier > this.Magicien && this.Guerrier > this.Voleur)
            {
                choix = 1;
            }
            if (this.Magicien > this.Guerrier && this.Magicien > this.Voleur)
            {
                choix = 2;
            }
            if (this.Voleur > this.Guerrier && this.Voleur > this.Magicien)
            {
                choix = 3;
            }

            if (choix == 0)
            {
                choix = PoserQuestion(this.Questions[this.Questions.Length - 1]);
            }

            
        }

        private int PoserQuestion(string question)
        {
            int reponse = 0;
            bool invalide = true;
            while (invalide)
            {
                Console.WriteLine(question);
                invalide = !int.TryParse(Console.ReadLine(), out reponse);

                if(reponse < 1 || reponse > 3)
                {
                    invalide = true;
                }

                if (invalide)
                {
                    Console.WriteLine("La valeur saisie n'est pas valide. Choisir une des option de menu.");
                }
            }

            return reponse;
        }
    }
}