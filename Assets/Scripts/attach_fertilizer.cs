using UnityEngine;

public class attach_fertilizer : MonoBehaviour
{
    public GameObject fertilizerPrefab; //プレハブを作成するための変数
    void Start()
    {
        // プレハブを生成
        GameObject fertilizer = Instantiate(fertilizerPrefab, transform.position, Quaternion.identity);
        // プレハブの親をこのオブジェクトに設定
        fertilizer.transform.parent = transform;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        // 衝突したオブジェクトが"Player"タグを持っている場合
        if (other.gameObject.CompareTag("Player"))
        {
            // プレイヤーの肥料を増やす
            HajimeItem item = other.gameObject.GetComponent<HajimeItem>();
            item.fertilizerCount += 1; //肥料の数をカウントする変数
            // このオブジェクトを破壊
            Destroy(gameObject);
        }
    }
}
