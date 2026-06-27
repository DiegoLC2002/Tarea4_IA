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
        enemies.Add(new Enemy("Agumon", EvolutionStages.Rookie, 450, 20, 68, 15, 45, 37));
        enemies.Add(new Enemy("Armadillomon", EvolutionStages.Rookie, 530, 32, 23, 21, 48, 33));
        enemies.Add(new Enemy("Impmon", EvolutionStages.Rookie, 140, 51, 44, 51, 21, 44));
        enemies.Add(new Enemy("Gaomon", EvolutionStages.Rookie, 450, 25, 55, 27, 30, 43));
        enemies.Add(new Enemy("Gazimon", EvolutionStages.Rookie, 390, 27, 60, 20, 20, 44));
        enemies.Add(new Enemy("Gabumon", EvolutionStages.Rookie, 450, 35, 45, 30, 32, 38));
        enemies.Add(new Enemy("Guilmon", EvolutionStages.Rookie, 470, 25, 70, 15, 30, 43));
        enemies.Add(new Enemy("Salamon", EvolutionStages.Rookie, 150, 55, 20, 56, 25, 39));
        enemies.Add(new Enemy("Lunamon", EvolutionStages.Rookie, 260, 50, 36, 52, 23, 38));
        enemies.Add(new Enemy("Elecmon", EvolutionStages.Rookie, 400, 40, 33, 30, 30, 37));



        // Champion
        enemies.Add(new Enemy("Greymon", EvolutionStages.Champion, 650, 35, 85, 25, 60, 55));
        enemies.Add(new Enemy("Garurumon", EvolutionStages.Champion, 450, 55, 50, 45, 45, 75));
        enemies.Add(new Enemy("Kabuterimon", EvolutionStages.Champion, 400, 40, 55, 63, 65, 42));
        enemies.Add(new Enemy("Togemon", EvolutionStages.Champion, 700, 40, 55, 44, 60, 46));
        enemies.Add(new Enemy("IceDevimon", EvolutionStages.Champion, 500, 45, 82, 60, 45, 43));
        enemies.Add(new Enemy("Agunimon", EvolutionStages.Champion, 600, 35, 85, 35, 44, 66));
        enemies.Add(new Enemy("Kyubimon", EvolutionStages.Champion, 350, 75, 20, 75, 40, 70));
        enemies.Add(new Enemy("Seadramon", EvolutionStages.Champion, 550, 60, 25, 71, 50, 44));
        enemies.Add(new Enemy("Togemon", EvolutionStages.Champion, 700, 40, 55, 44, 60, 46));
        enemies.Add(new Enemy("Sistermon Ciel", EvolutionStages.Champion, 400, 58, 47, 46, 38, 76));



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
