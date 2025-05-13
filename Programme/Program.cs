//Créer une fonction annuaire des plante spour savoir ce dont elles ont besoin qui peut être appellé à tout moment.

Console.WriteLine("----------- BIENVENUE DANS ENSCEMENCE ! ----------");
//Console.WriteLine(Les règles);
bool robustesse = false;
Terrain terrainJeu = null!;
do
{        
    Console.WriteLine("Dans quel terrain voulez-vous jouer ? Sableux, Rocheux, Argileux ou Tourbière ?");
    string input = Console.ReadLine()!;
    switch (input)
    {
        case "Sableux":
            terrainJeu = new TerrainSableux();
            robustesse = true;
            break;
        case "Rocheux":
            terrainJeu = new TerrainRocheux();
            robustesse = true;
            break;
        case "Argileux":
            terrainJeu = new TerrainArgileux();
            robustesse = true;
            break;
        case "Tourbière":
            terrainJeu = new TerrainTourbiere();
            robustesse = true;
            break;
        default:
            Console.WriteLine("Le terrain que vous avez choisi n'existe pas.");
            break;
    }
}while(robustesse == false);
Simulation jeu = new Simulation(terrainJeu);




/*
new class Affichage ()
{
    List <List<string>> Grille {get; set;}
    List <Terrains> TerrainsAfficher {get; set;}

    public Affichage()
    {
        //Crée une grille vide de dimension 2x3 : dans chaque case il y a 6 espaces pour planter une plante
        Grille = new List<List<string>>();
        for (int i=0; i<13; i++)
        {
            for (int j=0; j<7; j++)
            {
                if (j==0 || j==3) Grille[i][j] = "_";
                else if (i%3 == 0) Grille[i][j] = "|";
                else Grille[i][j] = " ";
            }
        }
    }
    public override string ToString()
    {
        //Crée une grille vide 

        return affichage;
    }
}
*/

