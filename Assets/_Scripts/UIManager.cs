using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [SerializeField] private TextMeshProUGUI interactableText;
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;
        ClearInteractableText();
        fadeImage.color = new Color(0, 0, 0, 1f);
        StartCoroutine(FadeIn());
    }

    public void SetInteractableText(string text)
    {
        interactableText.text = text;
    }

    public void ClearInteractableText()
    {
        interactableText.text = "";
    }

    public IEnumerator FadeIn()
    {
        float timer = 0f;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0,0,0,1 - timer/fadeDuration);
            yield return null;
        }
    }

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, timer / fadeDuration);
            yield return null;
        }
    }
}
