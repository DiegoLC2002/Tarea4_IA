using UnityEngine;
using TMPro;

public class EnemyInfoUI : MonoBehaviour
{
    [Header("Titulo")]
    [SerializeField] private TMP_Text title;

    [Header("Valores")]
    [SerializeField] private TMP_Text nameValue;
    [SerializeField] private TMP_Text fitnessValue;
    [SerializeField] private TMP_Text powerValue;
    [SerializeField] private TMP_Text expValue;
    [SerializeField] private TMP_Text yenValue;

    [SerializeField] private TMP_Text hpValue;
    [SerializeField] private TMP_Text spValue;
    [SerializeField] private TMP_Text atkValue;
    [SerializeField] private TMP_Text defValue;
    [SerializeField] private TMP_Text intValue;
    [SerializeField] private TMP_Text spdValue;

    public void SetEnemy(Enemy enemy)
    {
        title.text = enemy.DigimonName;

        nameValue.text = enemy.DigimonName;
        fitnessValue.text = enemy.fitness.ToString("F3");
        powerValue.text = enemy.powerScore.ToString("F3");
        expValue.text = enemy.EXP.ToString();
        yenValue.text = enemy.YEN.ToString();

        hpValue.text = enemy.HP.ToString();
        spValue.text = enemy.SP.ToString();
        atkValue.text = enemy.ATK.ToString();
        defValue.text = enemy.DEF.ToString();
        intValue.text = enemy.INT.ToString();
        spdValue.text = enemy.SPD.ToString();
    }
} 
