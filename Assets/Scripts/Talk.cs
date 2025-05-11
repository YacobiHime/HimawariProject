using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
    public GameObject dialogue;
    public Text Text;

    [SerializeField] 
    string words = "僕が手伝うよ";

    private bool isPlayerColliding = false; // プレイヤーが接触しているかどうかのフラグ

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerColliding = false;
            dialogue.SetActive(false);
        }
    }

    private void Update()
    {
        // プレイヤーが接触していて、かつEnterキーまたはSpaceキーが押され、かつダイアログが非表示の場合
        if (isPlayerColliding && 
            (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && 
            !dialogue.activeSelf)
        {
            Text.text = words;
            dialogue.SetActive(true);
        }
    }
}