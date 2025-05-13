public class PlanteInvasive: Plante
{
    public PlanteInvasive(Terrain terrainPlante, int positionParcelle) : base()
    {
        ImagesPlante = new List<string> {"🌱"};
        TerrainPlante = terrainPlante;
        ParcellePlante = TerrainPlante.Parcelles[positionParcelle]; //Indique sur quelle parcelle du terrain se situe la plante.
        NomPlante = "Weed";
        NombreProduits = 0;
        SurfaceNecessaire = 1;
        //SaisonSemis = tt l'année
        BesoinHumidite = 0.5;
        BesoinLuminosite = 0.5;
        DureeDeMaturation = 1;
        //MaladiesContractables = (....)
        TemperaturePrefereeMin = 0;
        TemperaturePrefereeMax = 30;
        NatureCommercialisable = false;
    }

    public void Developpement()
    {
        int index = 0; //On veut récupérer l'indice des itérations emplacement.
        foreach(var emplacement in ParcellePlante.Emplacements)
        {
            if (emplacement == "🟤") 
            {
                ParcellePlante.Emplacements[index] = ImagesPlante[0];
                index++;
                Console.WriteLine("Il faut desherber les plantes invasives,🌱. Sinon, elles peuvent empêcher vos plantes de se développer.");
            }
        }
    } 
}
