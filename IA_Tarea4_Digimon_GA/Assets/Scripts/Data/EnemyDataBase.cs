using UnityEngine;
using System.Collections.Generic;
public class EnemyDataBase
{
    private List<Enemy> enemies;

    public EnemyDataBase()
    {
        enemies = new List<Enemy>();

        InitializeDataBase();
    }

    private void InitializeDataBase()
    {
        // Rookie
        enemies.Add(new Enemy("Agumon", EvolutionStages.Rookie, 450, 120, 80, 70, 65, 90));
        enemies.Add(new Enemy("Gabumon", EvolutionStages.Rookie, 430, 140, 75, 80, 70, 85));
        enemies.Add(new Enemy("Tentomon", EvolutionStages.Rookie, 420, 150, 70, 75, 95, 80));
        enemies.Add(new Enemy("Palmon", EvolutionStages.Rookie, 440, 145, 68, 72, 90, 82));
        enemies.Add(new Enemy("Impmon", EvolutionStages.Rookie, 350, 140, 10, 20, 85, 94));
        enemies.Add(new Enemy("Patamon", EvolutionStages.Rookie, 530, 40, 85, 40, 60, 85));
        enemies.Add(new Enemy("Gaomon", EvolutionStages.Rookie, 620, 180, 76, 95, 95, 70));
        enemies.Add(new Enemy("Betamon", EvolutionStages.Rookie, 490, 170, 69, 69, 69, 96));


        // Champion
        enemies.Add(new Enemy("Greymon", EvolutionStages.Champion, 900, 180, 145, 120, 90, 110));
        enemies.Add(new Enemy("Garurumon", EvolutionStages.Champion, 820, 210, 130, 115, 95, 140));
        enemies.Add(new Enemy("Kabuterimon", EvolutionStages.Champion, 880, 220, 125, 130, 120, 95));
        enemies.Add(new Enemy("Togemon", EvolutionStages.Champion, 910, 170, 135, 125, 90, 100));

        // Ultimate
        enemies.Add(new Enemy("MetalGreymon", EvolutionStages.Ultimate, 1500, 260, 220, 180, 140, 150));
        enemies.Add(new Enemy("WereGarurumon", EvolutionStages.Ultimate, 1400, 280, 210, 170, 150, 180));

        // Mega
        enemies.Add(new Enemy("WarGreymon", EvolutionStages.Mega, 2300, 350, 320, 270, 220, 240));

        enemies.Add(new Enemy("MetalGarurumon", EvolutionStages.Mega, 2200, 380, 300, 250, 240, 250));
    }

    public List<Enemy> GetEnemiesByStage(EvolutionStages stage)
    {
        List<Enemy> results = new List<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            if(enemy.Stage == stage)
            {
                results.Add(enemy);
            }
        }

        return results;
    }

}
