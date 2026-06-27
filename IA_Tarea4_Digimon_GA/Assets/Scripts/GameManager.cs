using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        EnemyDataBase database = new EnemyDataBase();

        List<Enemy> champions =
            database.GetEnemiesByStage(EvolutionStages.Rookie);

        GeneticAlgorithm ga =
            new GeneticAlgorithm(champions);

        ga.Run();
    }
}
