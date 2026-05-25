using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public Damageable target;
    public TextMeshProUGUI hpText;

    public bool AIFormat = false;

    void Update()
    {
        if (target == null) return;

        if (AIFormat)
        {
            hpText.text = target.CurrentHealth.ToString();
        }
        else
        {
            hpText.text = "HP: " + target.CurrentHealth;
        }
    }
}