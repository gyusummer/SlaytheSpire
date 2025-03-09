using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Vector3 distance;

    [SerializeField] Mortal target;
    [SerializeField] RectTransform rectT;
    [SerializeField] Slider slider;
    [SerializeField] Text hpText;
    [SerializeField] Text blockText;
    [SerializeField] GameObject blockImage;
    [SerializeField] GameObject StatusesPanel;
    [SerializeField] GameObject Status_Prefab;
    public void Init(GameObject gameObject)
    {
        gameObject.TryGetComponent(out target);
        target.TryGetComponent(out BoxCollider2D col);

        // 체력바 위치 및 크기 조정
        float sizeY = col.size.y * 0.5f * target.transform.localScale.y;
        distance = new Vector3(0, sizeY, 0);
        Vector2 v1 = Camera.main.WorldToScreenPoint(col.bounds.min);
        Vector2 v2 = Camera.main.WorldToScreenPoint(col.bounds.max);
        float sizeX = v2.x - v1.x;
        rectT.sizeDelta = new Vector2(sizeX, rectT.sizeDelta.y);
        Vector3 scrPos = Camera.main.WorldToScreenPoint(target.transform.position - distance);
        rectT.position = scrPos;

        target.OnStatusChanged += UpdateStatuses;
    }
    private void Update()
    {
        if(target.CurHp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        if (target.Block <= 0)
        {
            blockImage.SetActive(false);
        }
        else
        {
            blockImage.SetActive(true);
        }
        slider.value = (float)target.CurHp / target.MaxHp;
        hpText.text = $"{target.CurHp}/{target.MaxHp}";
        blockText.text = $"{target.Block}";
    }
    public void UpdateStatuses()
    {
        int statusCount = target.StatusList.Count;
        int iconCount = StatusesPanel.transform.childCount;
        if (iconCount < statusCount)
        {
            int lack = statusCount - iconCount;
            for (int n = 0; n < lack; n++)
            {
                Instantiate(Status_Prefab, StatusesPanel.transform);
            }
        }
        else if (iconCount > statusCount)
        {
            int excess = iconCount - statusCount;
            for (int n = iconCount - 1; n > iconCount - 1 - excess; n--)
            {
                StatusesPanel.transform.GetChild(n).gameObject.SetActive(false);
            }
        }
        for (int n = 0; n < statusCount; n++)
        {
            GameObject s = StatusesPanel.transform.GetChild(n).gameObject;
            Image img = s.transform.GetComponentInChildren<Image>();
            Text text = img.transform.GetComponentInChildren<Text>();
            img.sprite = target.StatusList[n].image;
            text.text = target.StatusList[n].stack.ToString();
        }
    }
}
