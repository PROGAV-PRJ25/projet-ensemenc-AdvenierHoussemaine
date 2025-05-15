//Créer une fonction annuaire des plante spour savoir ce dont elles ont besoin qui peut être appellé à tout moment.

Console.WriteLine("----------- BIENVENUE DANS ENSCEMENCE ! ----------");
//Console.WriteLine(Les règles);
bool robustesse = false;
Terrain terrainJeu = null!;
do
{        
    Console.WriteLine("Dans quel terrain voulez-vous jouer ? Sableux, Rocheux, Argileux ou Tourbière ?");
    string input = Console.ReadLine()!.ToLower();
    switch (input)
    {
        case "sableux":
            terrainJeu = new TerrainSableux();
            robustesse = true;
            break;
        case "rocheux":
            terrainJeu = new TerrainRocheux();
            robustesse = true;
            break;
        case "argileux":
            terrainJeu = new TerrainArgileux();
            robustesse = true;
            break;
        case "tourbière":
        case "tourbiere":
            terrainJeu = new TerrainTourbiere();
            robustesse = true;
            break;
        default:
            Console.WriteLine("Le terrain que vous avez choisi n'existe pas.");
            break;
    }
}while(robustesse == false);
Simulation jeu = new Simulation(terrainJeu);
jeu.Simuler();