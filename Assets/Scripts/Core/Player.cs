using TarodevController;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100f;
    private float _currentHealth;
    public TextMeshProUGUI _healthText;
    private int _score;
    public TextMeshProUGUI _scoreText;
    private Vector2 respawnPoint = Vector2.zero;
    public AudioSource  audioSource;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip scoreSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth;
        _healthText.text = "Health: " + _currentHealth;
        _scoreText.text = "Score: " + _score;
    }
    
    public void SetRespawnPoint(Vector2 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
    }

    public void AddScore(int number)
    {
        _score += number;
        _scoreText.text = "Score: " + _score;
        PlaySound(scoreSound);
    }
    
    public void TakeDamage(float amount, float strength, Vector2 origin)
    {
        _currentHealth -= amount;
        _healthText.text = "Health: " + _currentHealth;
        transform.position += (transform.position - (Vector3)origin).normalized * strength;
        PlaySound(damageSound);
        
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip == null || audioSource == null)
            return;
        audioSource.PlayOneShot(clip);
    }

    private void Die()
    {
        transform.position = respawnPoint;
        _currentHealth = maxHealth;
        _healthText.text = "Health: " + _currentHealth;
    }
}
