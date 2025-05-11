using UnityEngine;

public class attach_seed : MonoBehaviour
{
    public GameObject seedPrefab; //プレハブを作成するための変数
    void Start()
    {
        // プレハブを生成
        GameObject seed = Instantiate(seedPrefab, transform.position, Quaternion.identity);
        // プレハブの親をこのオブジェクトに設定
        seed.transform.parent = transform;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        // 衝突したオブジェクトが"Player"タグを持っている場合
        if (other.gameObject.CompareTag("Player"))
        {
            // プレイヤーの種を増やす
            HajimeItem item = other.gameObject.GetComponent<HajimeItem>();
            item.Seedcount += 1; //種の数をカウントする変数
            // このオブジェクトを破壊
            Destroy(gameObject);
        }
    }
}
