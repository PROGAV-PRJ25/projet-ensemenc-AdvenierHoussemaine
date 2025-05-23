using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security;

public class Enfant
{
    public PlanteNull PlanteNull {get; set;}
    public Terrain TerrainSimulation {get; set;}
    public int NbrTours = 0;
    public Enfant(Terrain terrainSimulation)
    {
        TerrainSimulation = terrainSimulation;
        PlanteNull = new PlanteNull(TerrainSimulation.Parcelles[0]); //On initialise une plante null générique sur une parcelle aléatoire.
    }

    public bool PierreFeuilleCiseaux()
    {
        string[] options = { "pierre", "feuille", "ciseaux" };
        Random random = new Random();
        int nbrDefaites = 0;
        TerrainSimulation.Parcelles[0].Emplacements[0] = " 👶 ";
        TerrainSimulation.Parcelles[0].Plantes[0] = PlanteNull;
        TerrainSimulation.ToUrgenceString();

        bool rejouer = true; //Utilisé pour vérifier la victoire : si rejouer = true alors le joueur a perdu, si false alors il a gagné.
        do
        {   
            Console.Clear();
            Console.WriteLine("\n = URGENCE !!! =");
            Console.WriteLine("- Battez l'enfant au Pierre - Feuille - Ciseaux pour le calmer -");
            TerrainSimulation.ToUrgenceString();
            NbrTours++;
            Console.Write("-> Votre choix (pierre, feuille, ciseaux) : ");
            string choixJoueur = Console.ReadLine()!.ToLower();

            if (!Array.Exists(options, element => element == choixJoueur))
            {
                Console.WriteLine("-> Choix invalide. Réessayez.");
                continue;
            }
            string choixOrdi = options[random.Next(options.Length)];
            Console.WriteLine($"-> L'enfant à choisi : {choixOrdi}");
            if (
                (choixJoueur == "pierre" && choixOrdi == "ciseaux") ||
                (choixJoueur == "feuille" && choixOrdi == "pierre") ||
                (choixJoueur == "ciseaux" && choixOrdi == "feuille")
            )
            {
                Console.WriteLine("=> Vous avez gagné ! Vous avez chassé l'enfant !");
                rejouer = false;
                TerrainSimulation.Parcelles[NbrTours / 12].Emplacements[nbrDefaites] = " 🟤 "; //Revenir sur un affichage normal.
                System.Threading.Thread.Sleep(3000);
                TerrainSimulation.ToClassiqueString();
            }
            else
            {
                //Destruction des plantes par l'enfant
                TerrainSimulation.Parcelles[(NbrTours / 12)].Emplacements[nbrDefaites] = " 🟤 ";
                TerrainSimulation.Parcelles[(NbrTours / 12)].Emplacements[nbrDefaites + 1] = " 👶 ";
                TerrainSimulation.Parcelles[(NbrTours / 12)].Plantes[nbrDefaites] = PlanteNull; //Détruire les plantes que l'enfant à piétiné.
                TerrainSimulation.Parcelles[(NbrTours / 12)].Plantes[nbrDefaites + 1] = PlanteNull; //Détruire les plantes que l'enfant à piétiné.
                nbrDefaites++;
                if (choixJoueur == choixOrdi) Console.WriteLine("Egalité, rejouez !");
                else Console.WriteLine("Egalité ou l'enfant a gagné, rejouez !");
                System.Threading.Thread.Sleep(1500);
            }
        }while(rejouer == true);
        return rejouer;
    }
    public Terrain Urgence()
    {
        Console.WriteLine("\n = URGENCE !!! UN ENFANT CAPRICIEUX JOUE DANS VOTRE POTAGER ET DETRUIT VOS PLANTES ! =");
        System.Threading.Thread.Sleep(5000);
        PierreFeuilleCiseaux();
        return TerrainSimulation;
    }
}