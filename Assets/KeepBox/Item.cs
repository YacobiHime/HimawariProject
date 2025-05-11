using UnityEngine;

// アイテムの種類を表す列挙型
public enum ItemType
{
    Grow,   // 成長
    Key      // 鍵
}

[System.Serializable]
public class Item
{
    public int id;             // アイテムのID
    public Sprite icon;        // アイテムのアイコン画像
    public ItemType itemType;  // アイテムの種類
    public string itemName;    // アイテムの名前
    [TextArea]
    public string description; // アイテムの説明
    public int effectValue;    // 効果値
}

[CreateAssetMenu(fileName = "ItemList", menuName = "Inventory/ItemList")]
public class ItemList : ScriptableObject
{
    public Item[] items;

    /// <summary>
    /// 指定されたIDのアイテムを返す
    /// </summary>
    /// <param name="id">検索するアイテムのID</param>
    /// <returns>該当するアイテム。見つからなければnull。</returns>
    public Item GetItemById(int id)
    {
        foreach (var item in items)
        {
            if (item.id == id)
            {
                return item;
            }
        }
        Debug.LogWarning($"Item with ID {id} not found.");
        return null;
    }
}