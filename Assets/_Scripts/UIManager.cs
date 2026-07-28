using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }
    public void SetPlayerHealthBar(float value)
    {
        playerHealthBar.value = value;
    }

    public void SetPlayerHealthText(string text)
    {
        healthText.text = text;
    }

}
