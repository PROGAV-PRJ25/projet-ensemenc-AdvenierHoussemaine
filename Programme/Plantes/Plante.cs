/*
public abstract class Plante {

    //CARACTERISTIQUES DE LA PLANTE
    public string NomPlante {get; protected set;}
    public List<string> ImagesPlante {get; set;} 
    public bool NatureCommercialisable {get; protected set;}
    public int NombreProduits {get; protected set;}
    
    //PREFERENCES DE LA PLANTE
    public Saison SaisonSemi {get; protected set;}
    public double BesoinHumidite {get; set;} //Compris entre 0 et 1.
    public double BesoinLuminosite {get; protected set;} //Compris entre 0 et 1.
    public double TemperaturePrefereMin {get; protected set;}
    public double TemperaturePrefereMax {get; protected set;}
    public int SurfaceNecessaire {get; protected set;} //Détermine le nombre d'emplacement dans une parcelle qu'il lui faut pour grandir.

    //DONNEES INITIALES QUI CHANGENT AU COURS DE LA PARTIE
    public double VitesseCroissance {get; set;} //Symbolise l'état de la plante, compris entre -1 et 1 :  -1 = mort, 0 = pas de changement, entre 0.5 et 1 = double la taille lors d'un tour de jeu.
    public Terrain TerrainPlante {get; protected set;} //Indique ou se situe la plante.

    //CONTRAINTES
    public List<Maladies> MaladiesContractables {get; protected set;}
    public int DureeDeMaturation {get; set;}

    public Plante()
    {
        VitesseCroissance = 0; //Initalisée à "pas de croissance" pour toutes les plantes.
    }

    public void Planter(Terrain terrainOuLaPlanteEst){
        TerrainPlante = terrainOuLaPlanteEst;
    }
    public double VerificationEtatPlante(){ //si retourne 0 la plante survie et grandie pas si elle retourne 1 elle est a sa croissance maximale si elle retourne -1 elle meurt et les nombre négatif signifie une décroissance
        //Verification si elle est en etat de survivre
        if (BesoinHumidite > TerrainPlante.HumiditeTerrain || BesoinLuminosite > Meteo.Ensoleillement)
        {
            return-1; //la plante meurt
        }
        //Si on est pas dans ces températures préfére elle ne grandira pas
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
    if (SurfaceNecessaire*(croissancePotentielle-1)<TerrainPlante.surfaceDisponible) //A régler....:/
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