using UnityEngine;
using UnityEngine.UI;

public class StoreManager : GlobalBehavior
{
    public void OpenStore(Store store)
    {        
        var storeDialog = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/ShopWindow"), UIManager.ui.transform);
        storeDialog.transform.localPosition = new Vector3(0, 0, 0);
        Debug.Log("Got store dialog");
        var itemView = storeDialog.transform.Find("BottomPanel/RightPanel/ItemList/Scroll View/Viewport/Content");
        int offset = 0;
        foreach (var item in store.Items)
        {
            var itemGO = (GameObject)Instantiate(Resources.Load("Prefabs/ShopItem"), itemView);
            itemGO.transform.localPosition = new Vector3(0, offset, 0);
            var itemSel = itemGO.GetComponent<EconSelectable>();
            var itemImg = itemGO.GetComponent<Image>();
            itemSel.SelectEvent.AddListener((args) =>
            {
                itemImg.color = new Color(0.8f, 0.2f, 0.2f);
            });

            itemSel.DeselectEvent.AddListener((args) =>
            {
                itemImg.color = new Color(1f, 1f, 1f);
            });

            var itemDescGO = itemGO.transform.Find("ItemDescription");
            var textComponent = itemDescGO.GetComponent<Text>();
            textComponent.text = item.Item.Name;
            offset -= 75;
        }
    }
}
