using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneticAlgorithm
{
    private List<Enemy> population;

    private int maxGenerations = 20;
    private float mutationRate = 0.20f;

    private int generatedCounter = 1;
    private PopulationStats stats;
    private float targetPower = 0.80f;

    public GeneticAlgorithm(List<Enemy> initialPopulation)
    {
        population = new List<Enemy>(initialPopulation);

        stats = new PopulationStats(population);
    }

    //Evaluar todos los integrantes de la poblacion
    private void EvaluatePopulation()
    {
        foreach (Enemy enemy in population)
        {
            enemy.Evaluate(stats, targetPower);
        }
    }

    private void SortPopulation()
    {
        //Ordenar a los enemigos segun su fitness, los más altos quedan arriba
        population.Sort((a, b) => b.fitness.CompareTo(a.fitness));
    }

    public Enemy GetBestEnemy()
    {
        SortPopulation();
        return population[0];   //Devuelve el mejor
    }

    public void Run()
    {
        for (int generation = 0; generation < maxGenerations; generation++)
        {
            EvaluatePopulation();
            SortPopulation();

            float error = Mathf.Abs(population[0].powerScore - targetPower);

            //Informacion por consola
            Debug.Log(
                $"Generación {generation} | " +
                $"{population[0].DigimonName} | " +
                $"Fitness: {population[0].fitness:F3} | " +
                $"Power: {population[0].powerScore:F3} | " +
                $"Target: {targetPower:F3} | " +
                $"Error: {error:F3} | " +
                $"HP:{population[0].HP} SP:{population[0].SP} " +
                $"ATK:{population[0].ATK} DEF:{population[0].DEF} " +
                $"INT:{population[0].INT} SPD:{population[0].SPD}"
            );

            createNextGeneration();
        }

        EvaluatePopulation();
        SortPopulation();

        Debug.Log("----------------");
        Debug.Log("MEJOR ENEMIGO");

        Debug.Log("Nombre: " + population[0].DigimonName);
        Debug.Log("Fitness: " + population[0].fitness);
        Debug.Log("PowerScore: " + population[0].powerScore);
        Debug.Log("EXP: " + population[0].EXP);
        Debug.Log("YEN: " + population[0].YEN);

    }

    private Enemy Crossover(Enemy parent1, Enemy parent2)
    {
        //Crossover uniforme donde cada gen tiene un 50% de heredarse de cualquiera de los padres.
        Enemy child = new Enemy(
            "Generated_" + generatedCounter++,  //Nombre del enemigo generado
            parent1.Stage,                      //Etapa

            Random.value < 0.5f ? parent1.HP : parent2.HP,
            Random.value < 0.5f ? parent1.SP : parent2.SP,

            Random.value < 0.5f ? parent1.ATK : parent2.ATK,
            Random.value < 0.5f ? parent1.INT : parent2.INT,

            Random.value < 0.5f ? parent1.DEF : parent2.DEF,
            Random.value < 0.5f ? parent1.SPD : parent2.SPD
            );


        return child;
    }

    private Enemy SelectionParents()
    {
        //Elige a los mejores del 50% de la población
        int eliteSize = population.Count / 2;
        int index = Random.Range(0, eliteSize);

        return population[index];
    }

    private void createNextGeneration()
    {
        SortPopulation();

        List<Enemy> newPopulation = new List<Enemy>();

        //Copiar los 2 mejores enemigos de la poblacion original 
        newPopulation.Add(population[0].Clone());
        newPopulation.Add(population[1].Clone());

        while (newPopulation.Count < population.Count)
        {
            Enemy parent1 = SelectionParents();
            Enemy parent2 = SelectionParents();

            Enemy child = Crossover(parent1, parent2);

            Mutation(child);

            newPopulation.Add(child);
        }

        population = newPopulation;
    }

    private void Mutation(Enemy enemy)
    {
        if(Random.value > mutationRate) { return; }

        int stat = Random.Range(0, 6);  //Selecciona la estadistica a mutar
        float factor = Random.Range(0.90f, 1.10f);  //Decidir si se acumenta o disminuye la estadistica
        
        switch(stat)
        {
            case 0: 
                enemy.HP = Mathf.RoundToInt(enemy.HP * factor);
                break;

            case 1:
                enemy.SP = Mathf.RoundToInt(enemy.SP * factor);
                break;

            case 2:
                enemy.ATK = Mathf.RoundToInt(enemy.ATK * factor);
                break;

            case 3:
                enemy.DEF = Mathf.RoundToInt(enemy.DEF * factor);
                break;
            case 4:
                enemy.INT = Mathf.RoundToInt(enemy.INT * factor);
                break;

            case 5:
                enemy.SPD = Mathf.RoundToInt(enemy.SPD * factor);
                break;
        }
    }

}