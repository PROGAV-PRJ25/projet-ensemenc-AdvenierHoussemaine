/* TESTS AFFICHAGE

List<List<string>> Grille = new List<List<string>>();
for (int i=0; i<7; i++)
{
    List<string> ligne = new List<string>();
    for (int j=0; j<7; j++)
    {
        if (i%2 == 0)  ligne.Add("|");
        else if (j%3 == 0 && j!=0 && i%2!=0) ligne.Add("___");
        else ligne.Add("  ");
    }
    Grille.Add(ligne);
}

for (int i=0; i<7; i++)
{
    for (int j=0; j<7; j++)
    {
        Console.Write($"{Grille[i][j]}");
    }
    Console.WriteLine("");
}
*/