using UnityEngine;
using System.Collections.Generic; // Listを使うために必要
using System.Linq; // Linq (string.Join, ToListなど) を使うために必要

public class Item_attach : MonoBehaviour
{
    public string itemName;

    // PlayerPrefsに保存する際のキー
    private const string AcquiredItemsKey = "Himawari_AcquiredItems";

    // 獲得したアイテムを記録する静的リスト（ゲーム全体で共有される）
    public static List<string> acquiredItems = new List<string>();

    // ゲーム開始時に一度だけ呼ばれるようにする（最初のシーンがロードされる前）
    // 静的コンストラクタの代わりにこれを使用することで、PlayerPrefsへの安全なアクセスを保証します。
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeAcquiredItemsOnLoad()
    {
        LoadAcquiredItems();
        // Debug.Log("獲得済みアイテムリストが RuntimeInitializeOnLoadMethod 経由でロードされました。"); // 動作確認用ログ
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Debug.Log(itemName + "とインタラクトしました。"); // 
            AcquireItem(); // アイテムを獲得
            // Debug.Log("アイテムを獲得しました。");
        }
    }

    void AcquireItem()
    {
        // アイテムを獲得したことをログに出力
        Debug.Log(itemName + " を獲得しました！");

        // 獲得したアイテムリストにアイテム名を追加（まだ持っていなければ）
        if (!acquiredItems.Contains(itemName))
        {
            acquiredItems.Add(itemName);
            SaveAcquiredItems(); // アイテムリストの変更を保存
        }

        // 現在の獲得アイテムリストをコンソールに表示して確認
        Debug.Log("現在の獲得アイテム: " + string.Join(", ", acquiredItems));

        // このアイテムオブジェクトをシーンから削除
        Destroy(gameObject);
    }

    /// <summary>
    /// 指定されたアイテムを使用（消費）する。
    /// </summary>
    /// <param name="itemNameToUse">使用するアイテムの名前</param>
    /// <returns>アイテムを所持していて使用できたらtrue、そうでなければfalse</returns>
    public static bool UseItem(string itemNameToUse)
    {
        if (acquiredItems.Contains(itemNameToUse))
        {
            acquiredItems.Remove(itemNameToUse); // リストから削除
            SaveAcquiredItems(); // アイテムリストの変更を保存
            Debug.Log(itemNameToUse + " を使用しました。");
            Debug.Log("現在の獲得アイテム (使用後): " + string.Join(", ", acquiredItems));
            return true;
        }
        else
        {
            Debug.LogWarning(itemNameToUse + " を所持していません。");
            return false;
        }
    }

    /// <summary>
    /// PlayerPrefsから獲得済みアイテムのリストを読み込む
    /// </summary>
    private static void LoadAcquiredItems()
    {
        if (PlayerPrefs.HasKey(AcquiredItemsKey))
        {
            string savedItemsString = PlayerPrefs.GetString(AcquiredItemsKey);
            if (!string.IsNullOrEmpty(savedItemsString))
            {
                // カンマ区切りの文字列をリストに戻す
                acquiredItems = savedItemsString.Split(',').ToList();
            }
            else
            {
                acquiredItems = new List<string>(); // 保存データが空なら空のリスト
            }
        }
        else
        {
            acquiredItems = new List<string>(); // まだ保存データがなければ空のリスト
        }
        Debug.Log("ロードされた獲得アイテム: " + string.Join(", ", acquiredItems));
    }

    /// <summary>
    /// 現在の獲得済みアイテムのリストをPlayerPrefsに保存する
    /// </summary>
    private static void SaveAcquiredItems()
    {
        // リストをカンマ区切りの一つの文字列に変換して保存
        string itemsToSave = string.Join(",", acquiredItems);
        PlayerPrefs.SetString(AcquiredItemsKey, itemsToSave);
        PlayerPrefs.Save(); // 変更をディスクに書き込む（即時保存）
        Debug.Log("アイテムリストを保存しました: " + itemsToSave);
    }
}
