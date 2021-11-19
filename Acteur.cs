using System;

namespace Labo_TDZ_Final00_Sol
{
    class Acteur
    {
        public string Nom { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int MaxArmure { get; set; }
        public int RegenArmure { get; set; }
        public int Armure { get; set; }
        public int Agilite { get; set; }
        public int Dommage { get; set; }
        public int TauxCritique { get; set; }
        public string Description { get; set; }

        public Acteur(string nom, int maxHp, int maxArmure, int regenArmure, int agilite, int dommage, string description)
        {
            this.Nom = nom;
            this.MaxHp = maxHp;
            this.Hp = maxHp;
            this.MaxArmure = maxArmure;
            this.Armure = maxArmure;
            this.RegenArmure = regenArmure;
            this.Agilite = agilite;
            this.Dommage = dommage;
            this.TauxCritique = 100 - Agilite / 2;
            this.Description = description;
        }

        public void Attaquer(Acteur defenseur)
        {
            Random rng = new Random();
            int touche = rng.Next(1, 101);
            int dommageFinal = this.Dommage;

            if (touche >= this.TauxCritique)
            {
                dommageFinal = dommageFinal * 3 / 2;
                defenseur.Defendre(dommageFinal);
                Console.WriteLine($"{this.Nom} a porté un coup critique! {defenseur.Nom} reçoit {dommageFinal} points de dommage.");
            }
            else if (touche <= defenseur.Agilite)
            {
                Console.WriteLine($"{defenseur.Nom} a évité l'attaque.");
            }
            else
            {
                defenseur.Defendre(dommageFinal);
                Console.WriteLine($"{defenseur.Nom} reçoit {dommageFinal} points de dommage.");
            }
        }

        public void Defendre(int dommage)
        {
            this.Armure -= dommage;
            if(this.Armure < 0)
            {
                this.Hp += this.Armure;
                this.Armure = 0;
            }
            this.Armure += this.RegenArmure;
        }

        public bool estVivant()
        {
            return !(this.Hp <= 0);
        }

        public void AfficherEtat()
        {
            Console.WriteLine($"{this.Nom}, Hp : {this.Hp}, Armure : {this.Armure}");
        }
    }
}