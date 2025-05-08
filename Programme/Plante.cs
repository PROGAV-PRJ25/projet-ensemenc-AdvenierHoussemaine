/*
abstract class Plante {
    // caracteristiques de la plante
    public string NomPlante {get; protected set;}
    public bool NatureAnnuelle {get; protected set;}
    public bool NatureComestible {get; protected set;}
    public int NombreDeProduitQueLaPlantePeuxProduire {get; protected set;}
    public double SurfaceOccupé {get; protected set;}
    // preferences de la plante 
    public Saison SaisonSemi {get; protected set;}
    public Terrain TerrainPrefere {get; protected set;}

    public double BesoinEnEau {get; protected set;}
    public double BesoinEnLuminosité {get; protected set;}
    public double TemperaturePrefereMin {get; protected set;}
    public double TemperaturePrefereMax {get; protected set;}
    public double SurfaceNecessaire {get; protected set;}

    // donnees initiales qui changerons au fil du temps
    public double VitesseCroissance {get; set;}//ce qui symbolise l'état de la plante, compris entre -1 et 1. -1=mort 0=pas de changement, 1=double la taille lors d'un tour de jeu
    public Terrain TerrainOuLaPlanteEst {get; protected set;}

    //contrainte non negociable 
    public List<Maladies> MaladiesContractable {get; protected set;}
    public int NombreDeMoisDesperanceMax {get; set;}

    public Plante(string nomPlante,bool natureAnnuelle,bool natureComestible,int nombreDeProduitQueLaPlantePeuxProduire, Saison saisonSemi, Terrain terrainPrefere, double besoinEnEau, double besoinEnLuminosité,double temperaturePrefereMin,double temperaturePrefereMax ,double surfaceNecessaire,double vitesseCroissance,List<Maladies> maladiesContractable,int nombreDeMoisDesperanceMax){
        string NomPlante = nomPlante;
        bool NatureAnnuelle = natureAnnuelle;
        bool NatureComestible = natureComestible;
        int NombreDeProduitQueLaPlantePeuxProduire = nombreDeProduitQueLaPlantePeuxProduire;
        double SurfaceOccupé = surfaceNecessaire;
        Saison SaisonSemi = saisonSemi;
        Terrain TerrainPrefere = terrainPrefere;
        double BesoinEnEau = besoinEnEau;
        double BesoinEnLuminosité = besoinEnLuminosité;
        double TemperaturePrefereMin = temperaturePrefereMin;
        double TemperaturePrefereMax = temperaturePrefereMax;
        double SurfaceNecessaire = surfaceNecessaire;
        double VitesseCroissance = vitesseCroissance;
        List<Maladies> MaladiesContractable = maladiesContractable;
        int NombreDeMoisDesperanceMax = nombreDeMoisDesperanceMax;      
    }
    public void Planter(Terrain terrainOuLaPlanteEst){
        TerrainOuLaPlanteEst = terrainOuLaPlanteEst;
    }
    public double VerificationEtatPlante(){ //si retourne 0 la plante survie et grandie pas si elle retourne 1 elle est a sa croissance maximale si elle retourne -1 elle meurt et les nombre négatif signifie une décroissance 
        // verification si elle est en etat de survivire
        if (BesoinEnEau<TerrainOuLaPlanteEst.humidite || BesoinEnLuminosité<TerrainOuLaPlanteEst.)
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