using TMPro;
using UnityEngine;

public class DefeatedText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string defeatedEnemy = GameManager.Instance.DefeatedEnemy;
        if (defeatedEnemy.Equals(""))
            return;
        text.text = $"{defeatedEnemy} has been defeated!";
    }
}
