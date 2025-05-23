//Créer une fonction annuaire des plante spour savoir ce dont elles ont besoin qui peut être appellé à tout moment.

Console.WriteLine("\n\n----------- BIENVENUE DANS ENSCEMENCE ! ----------");
Console.WriteLine($@"

Dans ce jeu, vous allez vous occuper de votre potager !
Vous avez un terrain avec 6 parcelles. Sur chacune de ces parcelles vous avez 12 emplacements pour planter des plantes. 
Pour vous occuper de votre potager, vous pourrez planter des plantes et vous en occuper avec diverses actions. Pour faires ces actions vous devrez payer.
Vous partez avec 20 clochettes (🔔) ! Mais paq de soucis ! Dès qu'une plante commercialisable est mure elle sera automatiquement ceuillie et elle vous rapportera de l'argent.

Attention ! Au cours de vtre aventure vous aurez des difficultés à surmonter, des animaux à faire fuir !

Pour bien jouer au jeu il faut savoir :
- Le sanglier ne rentre pas dans le potager si vous avez installé une barrière.
- Les plantes sont très sensible à la lumionisté et l'humidité ! pensez bien à arroser ou ombrager vos plantes à chaque tour (si nécessaire).
- Vous pouvez arrêter de jouer à n'importe quel tour.
- La partie s'arrete lorsque la moitié de vos plantes sont mortes, lorsque la majorité sont en mauvais état ou lorsque vous avec -5 🔔.

Bon courage...!");
bool robustesse = false;
Terrain terrainJeu = null!;
do
{        
    Console.WriteLine("\nDans quel terrain voulez-vous jouer ? Sableux, Rocheux, Argileux ou Tourbière ?");
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



