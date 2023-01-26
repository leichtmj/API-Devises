namespace WSConvertisseur.Models
{
    public class Devise
    {
        private int id;
        private string nomDevise;
        private double taux;

        public int Id { get => id; set => id = value; }
        public string NomDevise { get => nomDevise; set => nomDevise = value; }
        public double Taux { get => taux; set => taux = value; }


        public Devise()
        {
                
        }

        public Devise(int id, string nomDevise, double taux)
        {
            Id = id;
            NomDevise = nomDevise;
            Taux = taux;
        }
    }
}
