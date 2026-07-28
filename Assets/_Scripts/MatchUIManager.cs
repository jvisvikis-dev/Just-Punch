using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchUIManager : MonoBehaviour
{
    private static MatchUIManager instance;
    public static MatchUIManager Instance => instance;
    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Button punchButton;
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        SetPunchButtonActive(true);
    }
    public void SetPlayerHealthBar(float value)
    {
        playerHealthBar.value = value;
    }

    public void SetPlayerHealthText(string text)
    {
        healthText.text = text;
    }

    public void SetPunchButtonActive(bool active)
    {
        punchButton.gameObject.SetActive(active);
    }

}
