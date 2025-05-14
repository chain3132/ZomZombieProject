using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;
    [SerializeField] private bool isBoss = false;

    // Update is called once per frame
    void Update()
    {
        // [2] if the object goes out of the top bound
        if (transform.position.z > topBound)
        {
            gameObject.SetActive(false);
        }
        else if (transform.position.z < lowerBound)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        if (isBoss)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
