using UnityEngine;

public class attach_water : MonoBehaviour
{
    public GameObject waterPrefab; //プレハブを作成するための変数
    void Start()
    {
        // プレハブを生成
        GameObject water = Instantiate(waterPrefab, transform.position, Quaternion.identity);
        // プレハブの親をこのオブジェクトに設定
        water.transform.parent = transform;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        // 衝突したオブジェクトが"Player"タグを持っている場合
        if (other.gameObject.CompareTag("Player"))
        {
            // プレイヤーの水を増やす
            HajimeItem item = other.gameObject.GetComponent<HajimeItem>();
            item.Watercount += 1; //水の数をカウントする変数
            // このオブジェクトを破壊
            Destroy(gameObject);
        }
    }
}
