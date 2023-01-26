using System.ComponentModel.DataAnnotations;

namespace WSConvertisseur.Models
{
    public class Devise
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nomDevise;

        /// <summary>
        /// Champ requis
        /// </summary>
        [Required]
        public string NomDevise
        {
            get { return nomDevise; }
            set { nomDevise = value; }
        }

        private double taux;

        public double Taux
        {
            get { return taux; }
            set { taux = value; }
        }





        public Devise()
        {
                
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="id">L'id de la devise</param>
        /// <param name="nomDevise">Le nom de la devise</param>
        /// <param name="taux">Le taux de la devise</param>
        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }

        public override bool Equals(object obj)
        {
            return obj is Devise devise &&
                   Id == devise.Id &&
                   NomDevise == devise.NomDevise &&
                   Taux == devise.Taux;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, NomDevise, Taux);
        }
    }
}
