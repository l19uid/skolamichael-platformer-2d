using System;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public TextMeshProUGUI dialogueUI;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI healthUI;
    public TextMeshPro hintUI;
    
    
    // This is called Singleton Pattern, it makes it easy to call this object from other scripts (like GetComponent but for just this single object)
    public static Interface Instance;

    public void Awake()
    {
        Instance = this;
        if (Instance == null)
            Debug.LogWarning("There is no Interface script in the Scene, did you add the Core prefab into the Scene?");
    }

    public void ShowDialogue(string dialogue)
    {
        if (dialogueUI != null) dialogueUI.text = dialogue;
    }

    public void ShowScore(int score)
    {
        if (scoreUI != null) scoreUI.text = score.ToString();
    }

    // Funkce na ukázání textu hint
    // Nastaví text hintUI na předaný text který se pak zobrazí na obrazovce
    public void ShowHint(string hint)
    {
        if (hintUI != null) hintUI.text = hint;
    }

    public void HideHint()
    {
        if (hintUI != null) hintUI.text = "";
    }
}
