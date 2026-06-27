using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm
{
    private List<Enemy> population;

    private int maxGenerations = 20;
    private float mutationRate = 0.20f;

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
        EvaluatePopulation();
        SortPopulation();

        Debug.Log("Mejor individuo:");
        Debug.Log(GetBestEnemy().DigimonName);
        Debug.Log(GetBestEnemy().fitness);

    }

}