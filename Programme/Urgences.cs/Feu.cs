
public class Feu
{
    public PlanteNull PlanteNull {get; set;}
    public Terrain TerrainSimulation {get; set;}
    public int NbrTours = 0;
    public Feu(Terrain terrainSimulation)
    {
        TerrainSimulation = terrainSimulation;
        PlanteNull = new PlanteNull(TerrainSimulation.Parcelles[0]); //On initialise une plante null générique sur une parcelle aléatoire.
    }

    public void DevinerLeNombre()
    {
        Random rand = new Random();
        int nombreMystere = rand.Next(0, 21);
        int proposition = -1;
        int tentatives = 0;
        
        TerrainSimulation.Parcelles[0].Emplacements[0] = " 🔥 ";
        TerrainSimulation.Parcelles[0].Plantes[0] = PlanteNull;
        TerrainSimulation.ToUrgenceString();

        while (proposition != nombreMystere)
        {

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("\n = URGENCE !!! =");
            Console.WriteLine("- Devinez un nombre entre 0 et 20 pour arrêter le jeu ! -");
            TerrainSimulation.ToUrgenceString();

            Console.Write("\n Votre proposition : ");
            string input = Console.ReadLine()!;

            if (!int.TryParse(input, out proposition) || proposition < 0 || proposition > 20)
            {
                Console.WriteLine("Entrée invalide. Tappez un nombre entre 0 et 20.");
                continue;
            }

            tentatives++;

            if (proposition < nombreMystere)
            {
                Console.WriteLine("Trop petit !");
                TerrainSimulation.Parcelles[(NbrTours / 12)].Emplacements[NbrTours] = " 🔥 ";
                TerrainSimulation.Parcelles[(NbrTours / 12)].Plantes[NbrTours] = PlanteNull;
            }
            else if (proposition > nombreMystere)
            {
                Console.WriteLine("Trop grand !");
                TerrainSimulation.Parcelles[(NbrTours / 12)].Emplacements[NbrTours] = " 🔥 ";
                TerrainSimulation.Parcelles[(NbrTours / 12)].Plantes[NbrTours] = PlanteNull;
            }
            else
            {
                Console.WriteLine($"\n => Bravo Vous avez gagné ! Vous avez trouvé le nombre {nombreMystere} ! Vous avez éteint le feu !");
                int indexEmplacement = 0;
                foreach (var emplacement in TerrainSimulation.Parcelles[NbrTours / 12].Emplacements)
                {
                    if (emplacement == " 🔥 ") TerrainSimulation.Parcelles[NbrTours / 12].Emplacements[indexEmplacement] = " 🟤 ";
                    indexEmplacement++;
                }
                System.Threading.Thread.Sleep(3000);
                TerrainSimulation.ToClassiqueString();
            }
            NbrTours++;
        }
    }

    public Terrain Urgence()
    {
        Console.WriteLine("\n = URGENCE !!! DES RANDONNEURS DISTRAITS ONT LANCE LEUR CIGARETTE SUR LE SOL, ARRETEZ LE FEU ! =");
        System.Threading.Thread.Sleep(5000);
        DevinerLeNombre();
        return TerrainSimulation;
    }
}