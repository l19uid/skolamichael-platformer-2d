using TarodevController;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    private float _currentHealth;
    private int _score;
    private Vector2 respawnPoint = Vector2.zero;
    public AudioSource  audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip scoreSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth;
    }
    
    // Nastavení respawn pointu na novou pozici
    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    // Adding score and updating the UI
    public void AddScore(int number)
    {
        _score += number;
        Interface.Instance.ShowScore(_score);
        PlaySound(scoreSound);
    }
    
    // Function for taking damage
    public void TakeDamage(float amount, float strength, Vector2 origin)
    {
        // Take damage
        _currentHealth -= amount;
        // Update health UI
        Interface.Instance.ShowHealth(_currentHealth,maxHealth);
        // Knockback
        transform.position += (transform.position - (Vector3)origin).normalized * strength;
        // Sound
        PlaySound(damageSound);
        
        // Check for death
        if (_currentHealth <= 0)
        {
            // Kill the player
            Die();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;
        audioSource.PlayOneShot(clip);
    }

    // for now the player just respawns at the last respawn point, instead of dying
    private void Die()
    {
        transform.position = respawnPoint;
        _currentHealth = maxHealth;
        Interface.Instance.ShowHealth(_currentHealth, maxHealth);
    }
}
