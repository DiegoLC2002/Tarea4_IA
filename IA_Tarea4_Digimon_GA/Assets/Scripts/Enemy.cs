using System.Xml.Linq;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string DigimonName;
    public EvolutionStages Stage;

    //Genes
    public int HP;
    public int SP;

    public int ATK;
    public int DEF;
    public int INT;
    public int SPD;

    //Valores derivados
    public float powerScore;
    public float fitness;

    public int EXP;
    public int YEN;

    //Valores Normalizados
    private float normalizedHP;
    private float normalizedSP;
    private float normalizedATK;
    private float normalizedDEF;
    private float normalizedINT;
    private float normalizedSPD;



    public Enemy(string name, EvolutionStages stage, int hp, int sp, int atk, int def, int intel, int spd)
    {
        DigimonName = name;
        Stage = stage;

        HP = hp;
        SP = sp;

        ATK = atk;
        DEF = def;
        INT = intel;
        SPD = spd;
    }

    //Metodo para normalizar estadisticas
    public void NormalizeStats(PopulationStats stats)
    {
        normalizedHP = HP / stats.MaxHP;
        normalizedSP = SP / stats.MaxSP;

        normalizedATK = ATK / stats.MaxATK;
        normalizedDEF = DEF / stats.MaxDEF;
        normalizedINT = INT / stats.MaxINT;
        normalizedSPD = SPD / stats.MaxSPD;

    }

    //Obtenemos el PowerScore con el promedio de las estadisticas
    public void calculatePowerScore()
    {
        powerScore = (normalizedHP + normalizedSP + normalizedATK + normalizedDEF + normalizedINT + normalizedSPD) / 6f;
    }

    //Calcular el poder esperado
    public float calculateExpectedPower()
    {
        return (float)Stage / 7f;
    }

    //Calcular Fitness
    public void calculateFitness()
    {
        float expectedPower = calculateExpectedPower();

        fitness = 1 - Mathf.Abs(expectedPower - powerScore);    //usa valor absoluto
    }

    //Calcular las recompensas

    public void calculateRewards()
    {
        EXP = Mathf.RoundToInt(powerScore * 100f);
        YEN = Mathf.RoundToInt(powerScore * 150f);
    }

    //Metodo para llamar a todas las funcuones a la vez
    public void Evaluate(PopulationStats stats)
    {
        NormalizeStats(stats);
        calculatePowerScore();
        calculateFitness();
        calculateRewards();
    }



}
