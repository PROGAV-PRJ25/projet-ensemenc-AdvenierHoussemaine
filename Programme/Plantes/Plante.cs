/*


public abstract class Plante {

    //Caractéritiques de la plante
    public string NomPlante {get; protected set;}
    public string ImagePlante {get; set;}

    //public bool NatureAnnuelle {get; protected set;} - est-ce que ça va nous servir?
    public bool NatureCommercialisable {get; protected set;}
    public int NombreProduits {get; protected set;}
    // Diff avec surface nécéssaire ? - public double SurfaceOccupee {get; protected set;}
    
    // preferences de la plante
    public Saison SaisonSemi {get; protected set;}
    //public Terrain TerrainPrefere {get; protected set;} pas nécessaire à mon sens, les préférencs en eau et luière suffisent

    public double BesoinHumidite {get; protected set;}
    public double BesoinLuminosite {get; protected set;}
    //public double TemperaturePrefereMin {get; protected set;} //Est ce que c'est vrmt utilse? Parce qu'on peut pas infulencer la température...
    //public double TemperaturePrefereMax {get; protected set;} //Pareil
    public int SurfaceNecessaire {get; protected set;} //Détermine le nombre d'emplacement dans une parcelle qu'il lui faut pour grandir.

    // donnees initiales qui changerons au fil du temps
    public double VitesseCroissance {get; set;} //ce qui symbolise l'état de la plante, compris entre -1 et 1. -1=mort 0=pas de changement, 1=double la taille lors d'un tour de jeu
    public Parcelle ParcellePlante {get; protected set;} //-- pas nécessaire je pense, les plantes seront ajoutés aux terrains et ces listes seront utilisées pour jouer

    // Valeurs durant le jeu
    public double HumiditePlante {get; set;}
    public double LuminositePlante {get; set;}

    //Contraintes
    public List<Maladies> MaladiesContractables {get; protected set;}
    public int DureeDeMaturation {get; set;}

    public Plante()
    {
        VitesseCroissance = 0; //Initalisée à "pas de croissance" pour toutes les plantes ????pas sur du choix...
    }

    public void Planter(Terrain terrainOuLaPlanteEst){
        TerrainOuLaPlanteEst = terrainOuLaPlanteEst;
    }
    public double VerificationEtatPlante(){ //si retourne 0 la plante survie et grandie pas si elle retourne 1 elle est a sa croissance maximale si elle retourne -1 elle meurt et les nombre négatif signifie une décroissance
        // verification si elle est en etat de survivire
        if (BesoinEnEau<TerrainOuLaPlanteEst.HumiditeTerrain || BesoinEnLuminosité<TerrainOuLaPlanteEst.)
        {
            return-1; //la plante meurt
        }
        // si on est pas dans ces températures préfére elle ne grandira pas
        if (Meteo.temperature<TemperaturePrefereMin)
        {
            VitesseCroissance= -(TemperaturePrefereMin-Meteo.temperature)/TemperaturePrefereMin; // on obtient -1 si on atteint zero degrés
        }
        if (Meteo.temperature>TemperaturePrefereMax)
        {
            if((Meteo.temperature/(2*TemperaturePrefereMax))>=1) //plus de deux fois la temperature max preferer resulte en la mort
            {
                return -1;
            }
            else
            {
                VitesseCroissance = -Meteo.temperature/(2*TemperaturePrefereMax);
            }
           
        }
        //ce seront les maladies qui affectent la plante
         return VitesseCroissance;
    }
     //si il n'y a pas beaucoup de place la croissance est limité
     public double Croissance(double croissancePotentielle){// a effectuer seulement si la vitesseDeCroissance est positive
        if (SurfaceOccupé*(croissancePotentielle-1)<TerrainOuLaPlanteEst.surfaceDisponible)
        {
            return croissancePotentielle;
        }
        else
        {
            return 2; //permettra de signifier qu'il faudra occuper tout l'espace disponible
        }
     }
}

*/