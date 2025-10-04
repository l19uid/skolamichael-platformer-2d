using System;
using UnityEngine;

public class Checkpoint : Interactable
{
    [Header("Portal Settings")]
    [Tooltip("The location where the player will be teleported to when interacting with the portal. / Pozice, kam bude hráč teleportován po interakci s portálem.")]
    public Vector2 checkpointPosition = Vector2.zero;
    
  
    public override void Interact(Collider2D other)
    {
        base.Interact(other);
        other.GetComponent<Player>()?.SetRespawnPoint(checkpointPosition);
    }
    
    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(checkpointPosition, 0.3f);
    }
}
