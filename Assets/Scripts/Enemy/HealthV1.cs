using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthV1 : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            if (gameObject.CompareTag("Enemy"))
            {
                GameManager.Instance.AddScore(20);
            }
            else if (gameObject.CompareTag("Boss"))
            {
                GameManager.Instance.AddScore(50);
                SceneManager.LoadScene(1);

            }
        }
    }
}
