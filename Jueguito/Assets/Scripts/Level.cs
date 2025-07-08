using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] private Image xpBar;
    [SerializeField] private GameObject menuLevelUp;

    private Player player;
    private MenuLevel menuLevel;

    private void Start()
    {
        player = GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("No se encontró el componente Player.");
            return;
        }

        menuLevel = FindObjectOfType<MenuLevel>();
        if (menuLevel == null)
        {
            Debug.LogError("No se encontró el componente MenuLevel.");
            return;
        }

        CalculateRequiredExperience();
        UpdateXPBar();
    }

    private void CalculateRequiredExperience()
    {
        player.stats.experienceRequired = 100 * Mathf.Pow(1.1f, player.stats.level - 1);
    }

    public void GainExperience(float amount)
    {
        player.stats.experience += amount;

        while (player.stats.experience >= player.stats.experienceRequired)
        {
            player.stats.experience -= player.stats.experienceRequired;
            LevelUp();
        }

        UpdateXPBar();
    }

    private void LevelUp()
    {
        player.stats.level++;
        CalculateRequiredExperience();

        if (menuLevel != null)
        {
            menuLevel.LevelPausa();
            // Asumiendo que tienes definidos los parámetros op1, op2, op3, op4.
            // menuLevel.LevelUp(op1, op2, op3, op4);
        }
    }

    private void UpdateXPBar()
    {
        if (xpBar != null)
        {
            xpBar.fillAmount = player.stats.experience / player.stats.experienceRequired;
        }
    }
}

