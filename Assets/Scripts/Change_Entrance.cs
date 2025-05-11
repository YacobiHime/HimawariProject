using UnityEngine;
using UnityEngine.SceneManagement;

public class Change_Entrance : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
        SceneManager.LoadScene("GardenEntrance");
        }
    }
}