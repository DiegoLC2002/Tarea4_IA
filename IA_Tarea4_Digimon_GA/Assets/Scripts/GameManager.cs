using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Enemy agumon = new Enemy("Agumon", EvolutionStages.Rookie, 450, 120, 80, 70, 65, 90);

        agumon.Evaluate();  //Evaluamos al digimon

        //Mensajes de debug
        Debug.Log("Nombre: " + agumon.DigimonName);
        Debug.Log("Power Score: " + agumon.powerScore);
        Debug.Log("Fitness: " + agumon.fitness);
        Debug.Log("EXP: " + agumon.EXP);
        Debug.Log("YEN: " + agumon.YEN);
    }
}
