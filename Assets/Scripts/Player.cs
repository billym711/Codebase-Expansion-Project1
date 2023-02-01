using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer sprite;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public int savedHealth;
    public List<Key> keys;
    public List<Key> savedKeys;
    public int commonKeysAmount;
    public int savedKeysAmount;
    public KeyUI keyUI;
    [SerializeField]
    public List<Enemy1> enemy1s;
    public List<Enemy1> savedEnemy1s;
    [SerializeField]
    public List<Enemy2> enemy2s;
    public List<Enemy2> savedEnemy2s;
    [SerializeField]
    public List<Enemy3> enemy3s;
    public List<Enemy3> savedEnemy3s;
    [SerializeField]
    public List<Enemy4> enemy4s;
    public List<Enemy4> savedEnemy4s;


    public AudioSource hitSound;
    public AudioSource healSound;
    public AudioSource keySound;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        commonKeysAmount = 0;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (damage < 0)
        {
            StartCoroutine(BlinkPlayerG());
            healSound.Play();
        }
        else
        {
            StartCoroutine(BlinkPlayerR());
            hitSound.Play();
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    IEnumerator BlinkPlayerR()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
    
    
    IEnumerator BlinkPlayerG()

    {
        sprite.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }    
    

    void Die()
    {
        GameManager manager = FindObjectOfType<GameManager>();
        if (manager != null)
        {
            manager.GameOver();
        }
        Destroy(gameObject);
    }
    public void Save()
    {
        savedKeysAmount = commonKeysAmount;
        savedHealth = currentHealth;
        keys.Clear();
        savedEnemy1s = enemy1s;
        savedEnemy2s = enemy2s;
        savedEnemy3s = enemy3s;
        savedEnemy4s = enemy4s;
    }
    public void Load()
    {
        currentHealth = savedHealth;
        commonKeysAmount = savedKeysAmount;
        healthBar.SetHealth(currentHealth);
        keyUI.ShowKeysAmount();
        foreach (Key key in keys)
        {
            key.gameObject.SetActive(true);
        }
        foreach (Enemy1 enemy1 in savedEnemy1s)
        {
            enemy1.gameObject.SetActive(true);
        }

    }
}
