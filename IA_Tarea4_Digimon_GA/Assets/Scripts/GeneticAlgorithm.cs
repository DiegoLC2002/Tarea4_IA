using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm
{
    private List<Enemy> population;

    private int maxGenerations = 20;
    private float mutationRate = 0.20f;

    private int generatedCounter = 1;

    public GeneticAlgorithm(List<Enemy> initialPopulation)
    {
        population = new List<Enemy>(initialPopulation);
    }

    //Evaluar todos los integrantes de la poblacion
    private void EvaluatePopulation()
    {
        foreach (Enemy enemy in population)
        {
            enemy.Evaluate();
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

            Debug.Log("Generación " + generation + " Mejor Fitness: " + population[0].fitness);

            createNextGeneration();
        }

        EvaluatePopulation();
        SortPopulation();

        Debug.Log("----------------");
        Debug.Log("MEJOR ENEMIGO");

        Debug.Log(population[0].DigimonName);
        Debug.Log(population[0].fitness);
        Debug.Log(population[0].powerScore);

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
            Random.value < 0.5f ? parent1.DEF : parent2.DEF,

            Random.value < 0.5f ? parent1.INT : parent2.INT,
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
        List<Enemy> newPopulation = new List<Enemy>();

        while (newPopulation.Count < population.Count)
        {
            Enemy parent1 = SelectionParents();
            Enemy parent2 = SelectionParents();

            Enemy child = Crossover(parent1, parent2);

            newPopulation.Add(child);
        }

        population = newPopulation;
    }

}