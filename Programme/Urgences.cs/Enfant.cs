using System.Dynamic;
using System.Runtime.InteropServices;

public class Enfant
{
    public Terrain TerrainSimulation {get; set;}

    public Enfant(Terrain terrainSimulation)
    {
        TerrainSimulation = terrainSimulation;
    }

    public bool PierreFeuilleCiseaux()
    {
        string[] options = { "pierre", "feuille", "ciseaux" };
        Random random = new Random();
        int nbrDefaites = 0;
        Console.WriteLine("=== Battez l'enfant au Pierre - Feuille - Ciseaux pour le calmer ===");

        bool rejouer = true; //Aussi utilisé pour vérifier la victoire : si rejouer = true alors le joueur a perdu, si false alors il a gagné.
        do
        {   
            TerrainSimulation.ToUrgenceString(); 
            Console.Write("Votre choix (pierre, feuille, ciseaux) : ");
            string choixJoueur = Console.ReadLine()!.ToLower();

            if (!Array.Exists(options, element => element == choixJoueur))
            {
                Console.WriteLine("Choix invalide. Réessayez.");
                continue;
            }
            string choixOrdi = options[random.Next(options.Length)];
            Console.WriteLine($"L'enfant a choisi : {choixOrdi}");

            if (choixJoueur == choixOrdi)
            {
                Console.WriteLine("Égalité !");
                //Destruction des plantes par l'enfant
                foreach(var parcelle in TerrainSimulation.Parcelles)
                {
                    parcelle.Emplacements[nbrDefaites] = "🟤";
                    parcelle.Emplacements[nbrDefaites+1] = "👶";
                    //Ajouter ligne qui suprrimela plante
                }
            }
            else if (
                (choixJoueur == "pierre" && choixOrdi == "ciseaux") ||
                (choixJoueur == "feuille" && choixOrdi == "pierre") ||
                (choixJoueur == "ciseaux" && choixOrdi == "feuille")
            )
            {
                Console.WriteLine("Vous avez gagné !");
                rejouer = false;
            }
            else
            {
                Console.WriteLine("L'enfant a gagné, rejouez !");
                //Destruction des plantes par l'enfant
                foreach(var parcelle in TerrainSimulation.Parcelles)
                {
                    parcelle.Emplacements[nbrDefaites] = "🟤";
                    parcelle.Emplacements[nbrDefaites+1] = "👶";
                    //Ajouter ligne qui supprime la plante
                }
            }
        }while(rejouer == true);
        return rejouer;
    }
    public Terrain Urgence()
    {
        bool gagne = false;
        Console.WriteLine("URGENCE !!!! Un enfant capricieux joue dans votre potager et détruit vos plantes !");
        do{
            PierreFeuilleCiseaux();
        }while(gagne == false);
        return TerrainSimulation;
    }
}