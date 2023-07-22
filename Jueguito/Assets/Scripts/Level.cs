using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int level = 1;
    public float experience = 0;
    public float experienceRequired = 100;
    [SerializeField] public Image xpBar;

    private void Start()
    {
        CalculateRequiredExperience();
        xpBar.fillAmount = experience / experienceRequired;
    }

    private void CalculateRequiredExperience()
    {
        experienceRequired *= 1.1f;
    }

    public void GainExperience(float amount)
    {
        experience += amount;
        Debug.Log("Ganaste " + amount + " experiencia.");
        xpBar.fillAmount = experience / experienceRequired;
        Debug.Log(experience/experienceRequired);

        if (experience >= experienceRequired)
        {
            experience = 0f;
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        CalculateRequiredExperience();
    }
}
