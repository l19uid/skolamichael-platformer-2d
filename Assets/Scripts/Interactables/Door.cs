using UnityEngine;

public class Door : Interactable
{
    private bool isLocked = true;
    [Tooltip("Once the door is unlocked, this GameObject will be deactivated. / Když jsou dveře odemčeny, tento GameObject bude deaktivován.")]
    public GameObject toOpen;


    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        Open();
    }
    
    
    public void Unlock() // Unlocks from Key
    {
        if (isLocked)
        {
            isLocked = false;
        }
    }

    private void Open() // Can be private
    {
        if (!isLocked)
        {
            // Add your door unlocking logic here (e.g., play animation, disable collider, etc.)
            Debug.Log("Door unlocked!");
            toOpen.SetActive(false); // Example: deactivate the door
        }
    }
}
