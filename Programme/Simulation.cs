public class Simulation 
{
    static private Random rng = new Random(); //est utilisé pour l'aléatoire
    protected Meteo MeteoDuMois;
    static bool ModeUrgence =false;
    public Simulation(double pluviometrie,double temperature, double ensoleillement) //pluviometrie en cm d'averse sur le mois
    {
        //creer l'année (une liste de mois) 
        //creer les terrains 
        MeteoDuMois = new Meteo(pluviometrie,temperature,ensoleillement);
        //permet d'initialiser les valeurs 
        double MeteoDuMois.Pluviometrie = pluviometrie;
        double MeteoDuMois.Temperature = temperature;
        double MeteoDuMois.Ensoleillement = ensoleillement;

    }

    public void Simuler()
    {
        while (bool conditionArret==false)
        {
            //les modification de météo d'un mois à l'autre
            int fluctuationPluviometrie = rng.Next(-2, 2 + 1);
            MeteoDuMois.Pluviometrie = Math.Abs(MeteoDuMois.Pluviometrie+ fluctuationPluviometrie);
            int fluctuationTemperature = rng.Next(-2, 2 + 1);
            MeteoDuMois.Temperature += fluctuationTemperature;
            MeteoDuMois.Ensoleillement*= rng.NextDouble();
            int risqueModeUrgence = rng.Next(0, 5);
            if (risqueModeUrgence==0)
            {
                ModeUrgence = true;
                //choix de l'urgence 
                //affichage du nom de l'urgence 
                //boucle while l'urgence est pas réglé ou que le joueur à perdu 
            }
            else 
            {
                // affichage du mois et de la meteo
                Console.WriteLine(Simulation.MeteoDuMois());
                //choix d'une créature qui nuit 
                //affichage de la créature
        
                //affichage score d'action restant
                //affichage des actions possibles 
                while (actionRestantes>0 && rienFaire==false)
                {
                    //demander l'action souhaité 
                    //executer l'action 
                    //mise à jour des variables (eventuellement déjà dasn l'action)
                    //incrementation du nombre d'action restantes
                    //affichage score d'action restantes
                }
            }
            //affichage de l'état du jeu 
            Console.WriteLine(Simulation.Terrain());
            // un temp de latence ou une attente que l'utilisateur tape sur une touche pour passer au prochain mois
             
        }
    }
}