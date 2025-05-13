
public abstract class Plante 
{
    //CARACTERISTIQUES DE LA PLANTE
    public string NomPlante {get; protected set;}
    public List<string> ImagesPlante {get; set;} 
    public bool NatureCommercialisable {get; protected set;}
    public int NombreProduits {get; protected set;}
    
    //PREFERENCES DE LA PLANTE
    public Saison SaisonSemi {get; protected set;}
    public double BesoinHumidite {get; set;} //Compris entre 0 et 1.
    public double BesoinLuminosite {get; set;} //Compris entre 0 et 1.
    public double TemperaturePrefereeMin {get; protected set;}
    public double TemperaturePrefereeMax {get; protected set;}
    public int SurfaceNecessaire {get; protected set;} //Détermine le nombre d'emplacement dans une parcelle qu'il lui faut pour grandir.

    //DONNEES INITIALES QUI CHANGENT AU COURS DE LA PARTIE
    public double VitesseCroissance {get; set;} //Symbolise l'état de la plante, compris entre -1 et 1 :  -1 = mort, 0 = pas de changement, entre 0.5 et 1 = double la taille lors d'un tour de jeu.
    public Terrain TerrainPlante {get; protected set;} //Indique ou se situe la plante.
    public Parcelle ParcellePlante {get; set;} //Indique sur quelle parcelle du terrain se situe la plante.

    //CONTRAINTES
    // vient on le fait que is on a le temps - public List<Maladies> MaladiesContractables {get; protected set;}
    public int DureeDeMaturation {get; set;} //En mois.

    public Plante()
    {
        VitesseCroissance = 0; //Initalisée à "pas de croissance" pour toutes les plantes.
    }

    public void Planter(Terrain terrainOuLaPlanteEst){
        TerrainPlante = terrainOuLaPlanteEst;
    }
    public double VerificationEtatPlante(Mois moisActuel){ //Si retourne 0 la plante survit et grandit pas. Si elle retourne 1 elle est à sa croissance maximale. Si elle retourne -1 elle meurt et les nombre négatifs signifient une décroissance.
        //Verification pour savoir si elle est en etat de survivre.
        if (BesoinHumidite > TerrainPlante.HumiditeTerrain || BesoinLuminosite > TerrainPlante.EnsoleillementTerrain)
        {
            return-1; //La plante meurt si ses besoins en ensoleillement et en humidité ne sont pas atteints.
        }
        //Si on est pas dans ces températures préfére elle ne grandira pas.
        if (moisActuel.Temperature<TemperaturePrefereeMin)
        {
            VitesseCroissance = -(TemperaturePrefereeMin-moisActuel.Temperature)/TemperaturePrefereeMin; //On obtient -1 si on atteint zero degrés.
        }
        if (moisActuel.Temperature>TemperaturePrefereeMax)
        {
            if((moisActuel.Temperature/(2*TemperaturePrefereeMax))>=1) //Plus de deux fois la temperature max preferée resulte en la mort
            {
                return -1;
            }
            else
            {
                VitesseCroissance = -moisActuel.Temperature/(2*TemperaturePrefereeMax);
            }
           
        }
        //ce seront les maladies qui affectent la plante
        
        /*
        //si il n'y a pas beaucoup de place la croissance est limité
        if (SurfaceNecessaire*(croissancePotentielle-1)<ParcellePlante.SurfaceNecessaire) //A régler....:/
        {
            return croissancePotentielle;
        }
        else
        {
            return 2; //permettra de signifier qu'il faudra occuper tout l'espace disponible
        }
        */
        return VitesseCroissance;
     }
}
