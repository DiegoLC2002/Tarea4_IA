using UnityEngine;
using System.Collections.Generic;

//Analiza la población y obtiene los maximos de cada estadistica
public class PopulationStats
{
    public float MaxHP { get; private set; }
    public float MaxSP { get; private set; }
    public float MaxATK { get; private set; }
    public float MaxDEF { get; private set; }
    public float MaxINT { get; private set; }
    public float MaxSPD { get; private set; }

    public PopulationStats(List<Enemy> population)
    {
        CalculateMaximums(population);
        //Debug.Log($"HP:{MaxHP}  SP:{MaxSP}  ATK:{MaxATK}  DEF:{MaxDEF}  INT:{MaxINT}  SPD:{MaxSPD}");
    }

    private void CalculateMaximums(List<Enemy> population)
    {
        MaxHP = 0;
        MaxSP = 0;
        MaxATK = 0;
        MaxDEF = 0;
        MaxINT = 0;
        MaxSPD = 0;

        foreach (Enemy enemy in population)
        {
            if (enemy.HP > MaxHP) MaxHP = enemy.HP;
            if (enemy.SP > MaxSP) MaxSP = enemy.SP;
            if (enemy.ATK > MaxATK) MaxATK = enemy.ATK;
            if (enemy.DEF > MaxDEF) MaxDEF = enemy.DEF;
            if (enemy.INT > MaxINT) MaxINT = enemy.INT;
            if (enemy.SPD > MaxSPD) MaxSPD = enemy.SPD;
        }
    }
}
