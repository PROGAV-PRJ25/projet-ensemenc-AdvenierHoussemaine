
public abstract class Plante
{
    //CARACTERISTIQUES DE LA PLANTE
    public string? NomPlante {get; protected set;}
    public List<string>? ImagesPlante {get; set;} 
    public bool NatureCommercialisable {get; protected set;}
    public int NombreProduits {get; protected set;}
    public int ValeurProduit {get; set;} //Les plantes ont une valeur monétaire (🔔) par produit récolté.
    
    //PREFERENCES DE LA PLANTE
    public Saison? SaisonSemi {get; protected set;}
    public double BesoinHumidite {get; set;} //Compris entre 0 et 1.
    public double BesoinLuminosite {get; set;} //Compris entre 0 et 1.
    public double TemperaturePrefereeMin {get; protected set;}
    public double TemperaturePrefereeMax {get; protected set;}

    //DONNEES INITIALES QUI CHANGENT AU COURS DE LA PARTIE
    public double VitesseCroissance {get; set;} //Symbolise l'état de la plante, compris entre -1 et 1 :  -1 = mort, 0 = pas de changement, entre 0.5 et 1 = double la taille lors d'un tour de jeu.
    public Parcelle? ParcellePlante {get; set;} //Indique sur quelle parcelle du terrain se situe la plante.
    public int NiveauMaturation {get; set;} // Indique à quel niveau dans les emoticone la plante est, 0 pour morte 4 pour à son max

    //CONTRAINTES
    // vient on le fait que is on a le temps - public List<Maladies> MaladiesContractables {get; protected set;}
    public int DureeDeMaturation {get; set;} //En mois.

    public Plante(Parcelle parcellePlante)
    {
        ParcellePlante = parcellePlante;
        VitesseCroissance = 0; //Initalisée à "pas de croissance" pour toutes les plantes.
        NiveauMaturation = 1; //La plante comment au niveau de graine
    }

    public virtual double VerificationEtatPlante(Mois moisActuel)
    { //Si retourne 0 la plante survit et grandit pas. Si elle retourne 1 elle est à sa croissance maximale. Si elle retourne -1 elle meurt et les nombre négatifs signifient une décroissance.
        //Verification pour savoir si elle est en etat de survivre.
        if (BesoinHumidite > ParcellePlante!.HumiditeParcelle || BesoinLuminosite > ParcellePlante!.EnsoleillementParcelle)
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
        return VitesseCroissance;
     }
}
