using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        EnemyDataBase database = new EnemyDataBase();

        List<Enemy> enemiesByStage = database.GetEnemiesByStage(EvolutionStages.Ultimate);

        GeneticAlgorithm ga = new GeneticAlgorithm(enemiesByStage);

        ga.Run();
    }
}
