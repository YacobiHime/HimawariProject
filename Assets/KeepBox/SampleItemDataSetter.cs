using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SampleItemDataSetter : MonoBehaviour
{
    [SerializeField] private ItemList itemList; // ScriptableObjectをアタッチ
    [SerializeField] private Image itemIconImage; // アイコン表示用
    [SerializeField] private int itemId;       // 表示したいアイテムのID
    [SerializeField] private TMP_Text itemNameText;    // アイテム名表示用
    [SerializeField] private TMP_Text itemDescriptionText; // 説明表示用
    [SerializeField] private TMP_Text itemEffectValueText; // 効果値表示用

    private void Start()
    {
        DisplayItemDetails(itemId);
    }

    private void DisplayItemDetails(int id)
    {
        // IDに該当するアイテムを取得
        var item = itemList.GetItemById(id);

        if (item != null)
        {
            itemIconImage.sprite = item.icon;
            itemNameText.text = item.itemName;
            itemDescriptionText.text = item.description;
            itemEffectValueText.text = $"Effect: {item.effectValue}";
        }
    }
}