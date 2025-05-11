using UnityEngine;

public class GardenEntranceCounter : MonoBehaviour
{
    // GardenEntranceシーンへの遷移回数を保持する静的変数
    // staticを使うことで、シーンを跨いで値を保持できます。
    public static int entranceCount = 0;

    void Start()
    {
        // このスクリプトがアタッチされたGameObjectが有効になったとき（シーンロード時など）に呼ばれる

        // 遷移回数をインクリメント
        entranceCount++;

        // コンソールにメッセージを表示
        Debug.Log("GardenEntranceシーンへの遷移回数: " + entranceCount + "回");
    }

    // もし必要であれば、どこか別のスクリプトからこの回数を参照することも可能です
    public static int GetEntranceCount()
    {
        return entranceCount;
    }

    // 必要であれば、回数をリセットするメソッドなども追加できます
    // public static void ResetCount()
    // {
    //     entranceCount = 0;
    //     Debug.Log("GardenEntranceシーン遷移回数をリセットしました。");
    // }
}