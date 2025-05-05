public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected Meteo MeteoDuMois;
    static bool ModeUrgence =false;
    public Simulation(double pluviometrie,double temperature, double ensoleillement) //pluviometrie en cm d'averse sur le mois
    {
        MeteoDuMois = new Meteo();
        //permet d'initialiser les valeurs 
        double MeteoDuMois.pluviometrie == pluviometrie;
        double MeteoDuMois.temperature == temperature;
        double MeteoDuMois.ensoleillement == ensoleillement;

    }

    public void Simuler()
    {
        while (bool conditionArret==false)
        {
            //les modification de météo d'un mois à l'autre
            int fluctuationPluviometrie = rng.Next(-2, 2 + 1);
            MeteoDuMois.pluviometrie = Math.Abs(MeteoDuMois.pluviometrie+ fluctuationPluviometrie);
            int fluctuationTemperature = rng.Next(-2, 2 + 1);
            MeteoDuMois.temperature += fluctuationTemperature;
            MeteoDuMois.ensoleillement*= rng.NextDouble();
            int risqueModeUrgence = rng.Next(0, 5);
            if (risqueModeUrgence==0)
            {
                ModeUrgence = true;
            }
            //affichage de l'état du jeu 
            Console.WriteLine(Simulation.MeteoDuMois());

            //distinction si on est en mode urgence ou classique avec un affichage à la fin et un temp de latence ou une attente que l'utilisateur tape sur une touche
             
        }
    }
}