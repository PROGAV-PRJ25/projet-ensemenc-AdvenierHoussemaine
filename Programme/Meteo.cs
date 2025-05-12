public class Meteo {
    double Pluviometrie {get; set;} //pluviometrie en cm d'averse sur le mois
    double Temperature {get; set;} // en degres celsius 
    double Ensoleillement {get; set;} // en taux 0==noir complet 1==jour sur le mois

    public Meteo(double pluviometrie, double temperature, double ensoleillement)
    {
        Pluviometrie=pluviometrie;
        Temperature=temperature;
        Ensoleillement=ensoleillement;
    }
    public void Averses(double cmDaverse)
    {
        Pluviometrie+=cmDaverse;
    }
    public void Secheresse(double intensiteSecheresse)
    {
        Ensoleillement+=intensiteSecheresse;
    }

    //mettre affichage to string
}