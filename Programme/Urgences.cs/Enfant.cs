using System.Dynamic;
using System.Runtime.InteropServices;
using System.Security;

public class Enfant
{
    PlanteNull planteNull {get; set;}
    public Terrain TerrainSimulation {get; set;}
    public int NbrTours = 0;
    bool Gagner = false;
    public Enfant(Terrain terrainSimulation)
    {
        TerrainSimulation = terrainSimulation;
        planteNull = new PlanteNull(TerrainSimulation.Parcelles[0]); //On initialise un eplante null générique sur une parcelle aléatoire.
    }

    public bool PierreFeuilleCiseaux()
    {
        string[] options = { "pierre", "feuille", "ciseaux" };
        Random random = new Random();
        int nbrDefaites = 0;
        Console.WriteLine("=== Battez l'enfant au Pierre - Feuille - Ciseaux pour le calmer ===");
        TerrainSimulation.Parcelles[0].Emplacements[0] = "👶";
        TerrainSimulation.Parcelles[0].Plantes[0] = planteNull;
        TerrainSimulation.ToUrgenceString();
        TerrainSimulation.Parcelles[0].Emplacements[0] = "🟤"; //Revenir sur un affichage normal.

        bool rejouer = true; //Aussi utilisé pour vérifier la victoire : si rejouer = true alors le joueur a perdu, si false alors il a gagné.
        do
        {   
            TerrainSimulation.ToUrgenceString();
            NbrTours++;
            Console.Write("Votre choix (pierre, feuille, ciseaux) : ");
            string choixJoueur = Console.ReadLine()!.ToLower();

            if (!Array.Exists(options, element => element == choixJoueur))
            {
                Console.WriteLine("Choix invalide. Réessayez.");
                continue;
            }
            string choixOrdi = options[random.Next(options.Length)];
            Console.WriteLine($"L'enfant à choisi : {choixOrdi}");

            if (choixJoueur == choixOrdi)
            {
                Console.WriteLine("Égalité !");
                //Destruction des plantes par l'enfant
                //NbrTours/12 permet de savoir sur quelle parcelle il se situe. Il pétines les plantes une par une.
                TerrainSimulation.Parcelles[(NbrTours/12)].Emplacements[nbrDefaites] = "🟤";
                TerrainSimulation.Parcelles[(NbrTours/12)].Emplacements[nbrDefaites+1] = "👶";
                TerrainSimulation.Parcelles[(NbrTours/12)].Plantes[nbrDefaites] = planteNull; //Détruire les plantes que l'enfant à piétiné.
                TerrainSimulation.Parcelles[(NbrTours/12)].Plantes[nbrDefaites+1] = planteNull; //Détruire les plantes que l'enfant à piétiné.
                nbrDefaites++;
            }
            else if (
                (choixJoueur == "pierre" && choixOrdi == "ciseaux") ||
                (choixJoueur == "feuille" && choixOrdi == "pierre") ||
                (choixJoueur == "ciseaux" && choixOrdi == "feuille")
            )
            {
                Console.WriteLine("Vous avez gagné !");
                rejouer = false;
                Gagner = true;
                TerrainSimulation.Parcelles[NbrTours/12].Emplacements[nbrDefaites+1] = "🟤"; //Revenir sur un affichage normal.
            }
            else
            {
                Console.WriteLine("L'enfant a gagné, rejouez !");
                //Destruction des plantes par l'enfant
                TerrainSimulation.Parcelles[(NbrTours/12)].Emplacements[nbrDefaites] = "🟤";
                TerrainSimulation.Parcelles[(NbrTours/12)].Emplacements[nbrDefaites+1] = "👶";
                TerrainSimulation.Parcelles[(NbrTours/12)].Plantes[nbrDefaites] = planteNull; //Détruire les plantes que l'enfant à piétiné.
                TerrainSimulation.Parcelles[(NbrTours/12)].Plantes[nbrDefaites+1] = planteNull; //Détruire les plantes que l'enfant à piétiné.
                nbrDefaites++;
            }
        }while(rejouer == true);
        return rejouer;
    }
    public Terrain Urgence()
    {
        Console.WriteLine("URGENCE !!!! Un enfant capricieux joue dans votre potager et détruit vos plantes !");
        do{
            PierreFeuilleCiseaux();
        }while(Gagner == false);
        return TerrainSimulation;
    }
}