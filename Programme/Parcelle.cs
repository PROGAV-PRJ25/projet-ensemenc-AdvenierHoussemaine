class Parcelle
{
    public List<char> Emplacements {get; set;} 
    public string NumParcelle {get; set;}

    public Parcelle(string numPetitTerrain, List<char> emplacements)
    {
        Emplacements = emplacements;
        NumParcelle = numPetitTerrain;
    }
}