using UnityEngine;

public class Door : Interactable
{
    private bool isLocked = true;
    [Tooltip("Once the door is unlocked, this GameObject will be deactivated. / Když jsou dveře odemčeny, tento GameObject bude deaktivován.")]
    public GameObject toOpen; 
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        if (!inputInteraction && other.CompareTag(interactTag) && !isLocked)
        {
            Open();
        }
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
        if (inputInteraction && other.CompareTag(interactTag) && Input.GetKeyDown(interactKey) && !isLocked)
        {
            Open();
        }
    }
    
    public void Unlock()
    {
        if (isLocked)
        {
            isLocked = false;
        }
    }

    public void Open()
    {
        if (!isLocked)
        {
            // Add your door unlocking logic here (e.g., play animation, disable collider, etc.)
            Debug.Log("Door unlocked!");
            toOpen.SetActive(false); // Example: deactivate the door
        }
    }
}
