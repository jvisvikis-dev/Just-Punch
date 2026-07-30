using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchUIManager : MonoBehaviour
{
    private static MatchUIManager instance;
    public static MatchUIManager Instance => instance;
    [SerializeField] private bool debugMode;
    public bool DebugMode => debugMode;
    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Button punchButton;
    [SerializeField] private Image redFlash;
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
        if (!debugMode)
        {
            DisableHealthBar();
        }
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

    public void DisableHealthBar()
    {
        playerHealthBar.gameObject.SetActive(false);
        healthText.gameObject.SetActive(false);
    }

    public IEnumerator FlashRed(float flashTime)
    {
        float timer = 0;
        float fadeTime = flashTime / 2;
        while(timer <= fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f,1f, timer/fadeTime);
            Color color = Color.red;
            color.a = alpha;
            redFlash.color = color;
            yield return null;
        }
        timer = 0;
        while (timer <= fadeTime)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, 1 - timer / fadeTime);
            Color color = Color.red;
            color.a = alpha;
            redFlash.color = color;
            yield return null;
        }

    }

}
