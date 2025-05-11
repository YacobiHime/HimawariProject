using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Center : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
                SceneManager.LoadScene("GardenCenter");
        }
    }
}