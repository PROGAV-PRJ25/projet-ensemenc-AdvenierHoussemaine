public class Mois 
{
    public string NomDuMois {get;private set;}
    public double Pluviometrie {get; private set;} //pluviometrie en cm d'averse sur le mois
    public double Temperature {get; private set;} // en degres celsius 
    public double Ensoleillement {get; private set;} // en taux 0==noir complet 1==jour sur le mois
    
    public Mois (string nomDuMois)
    {
        NomDuMois = nomDuMois ;
        if (nomDuMois=="Janvier")
        {
            Pluviometrie = 7.5;
            Temperature = 6.5;
            Ensoleillement =0.4 ;
        }
        else if (nomDuMois=="Février")
        {
            Pluviometrie = 5.5;
            Temperature = 6.5;
            Ensoleillement = 0.5;
        }
        else if (nomDuMois=="Mars")
        {
            Pluviometrie = 5.5;
            Temperature = 9.7;
            Ensoleillement = 0.7;
        }
        else if (nomDuMois=="Avril")
        {
            Pluviometrie = 7.3;
            Temperature = 12.5;
            Ensoleillement = 0.8 ;
        }
        else if (nomDuMois=="Mai")
        {
            Pluviometrie = 7.6;
            Temperature = 16;
            Ensoleillement = 0.9;
        }
        else if (nomDuMois=="Juin")
        {
            Pluviometrie = 6.8;
            Temperature = 20;
            Ensoleillement = 0.9;
        }
        else if (nomDuMois=="Juillet")
        {
            Pluviometrie = 5.3;
            Temperature = 21.5;
            Ensoleillement = 0.9;
        }
        else if (nomDuMois=="Août")
        {
            Pluviometrie = 5.3;
            Temperature = 21.5;
            Ensoleillement = 0.9;
        }
        else if (nomDuMois=="Septembre")
        {
            Pluviometrie = 6;
            Temperature = 19;
            Ensoleillement = 0.8;
        }
        else if (nomDuMois=="Octobre")
        {
            Pluviometrie = 7.1;
            Temperature = 15;
            Ensoleillement = 0.7;
        }
        else if (nomDuMois=="Novembre")
        {
            Pluviometrie = 8.6;
            Temperature = 10;
            Ensoleillement = 0.5;
        }
        else //cas du décembre
        {
            Pluviometrie = 7.3;
            Temperature = 7;
            Ensoleillement = 0.4 ;
        }
    }
    //eventuellement inutile si on fait le tostring dans la classe annee
    public override string ToString()
    {
        return $"La météo du mois de {NomDuMois} est la suivante \n Température moyenne : {Temperature}\n Cm de pluie dans le mois : {Pluviometrie}\n Taux de lumiére moyenne pendant une journée : {Ensoleillement}";
    }

}
