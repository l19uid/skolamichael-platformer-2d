using System;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string interactTag = "Player";
    public KeyCode interactKey = KeyCode.F;
    [Tooltip("If true, interaction requires pressing the 'F' key. If false, interaction happens automatically on trigger enter. /" +
             "Jestliže je true, interakce vyžaduje stisknutí klávesy 'F'. Pokud je false, interakce probíhá automaticky při vstupu do triggeru.")]
    public bool inputInteraction = false;
    [Tooltip("Text, který se zobrazí, pokud musí hráč stisknout klávesu Interakce, pokud je prázdný, zobrazí se Press F")]
    public string hintText;
    
    private bool isInsideTrigger = false;
    private Collider2D _other;
    
    // Když něco vstoupí do triggeru
    public  void OnTriggerEnter2D(Collider2D other)
    {
        // Pokud není potřeba stisknout klávesu pro interakci, interagujeme hned
        // Ještě kontrolujeme tag
        if (!inputInteraction && other.CompareTag(interactTag))
        {
            Debug.Log($"Player entered the interactable area of {gameObject}");
            Interact(other);
        }
        
        isInsideTrigger = other.CompareTag(interactTag); 
        _other = other;
        if (inputInteraction && isInsideTrigger)
            Interface.Instance.ShowHint($"Press {interactKey.ToString()} {hintText}");
    }
    
    // Když něco zůstane do triggeru
    private void Update()
    {
        // Kontrolujeme tag nejdřív protože víme že hráč je v triggeru ale nemusí stisknout klávesu
        // Pokud je potřeba stisknout klávesu pro interakci, čekáme na ni
        if (inputInteraction && isInsideTrigger)
        {
            if(Input.GetKeyDown(interactKey))
                Interact(_other);
            // Zobrazíme hint
        }
    }
    
    // Když něco odejde do triggeru
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(interactTag))
        {
            Interface.Instance.HideHint();
            StopInteraction(other);
            isInsideTrigger = false;
            _other = null;
        }
    }

    // Metoda pro interakci, kterou lze přepsat v podtřídách
    public virtual void Interact(Collider2D other)
    {
        Debug.Log($"Player interacted with  {gameObject}");
        Interface.Instance.HideHint();
    }

    // Metoda pro ukončení interakce, kterou lze přepsat v podtřídách
    public virtual void StopInteraction(Collider2D other)
    {
        Debug.Log($"Player stoped interaction with {gameObject}");
    }

    // Když je objekt zničen, schováme hint
    public void OnDestroy()
    {
        Interface.Instance.HideHint();
    }
}
