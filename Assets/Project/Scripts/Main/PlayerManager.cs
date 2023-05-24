using System.Collections.Generic;
using Main;
using Units;

public class PlayerManager : Singleton<PlayerManager>
{
    private float gold;
    private List<Unit> owndedAllies = new();

    #region Properties

    public List<Unit> OwndedAllies => owndedAllies; 
    public float Gold => gold;

    #endregion

    public void AddNewAlly()
    {
        int index = owndedAllies.Count;
        if (index >= Archive.Instance.Allies.Length) return;
        
        Ally newAlly = new Ally((AllyData) Archive.Instance.Allies[index]);
        owndedAllies.Add(newAlly);
    }

    public void AddGold(float value)
    {
        gold += value;
    }
}