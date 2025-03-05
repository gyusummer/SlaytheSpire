using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Vector3 distance;

    [SerializeField] AbstractMortals target; //enemy
    [SerializeField] RectTransform rectT;
    [SerializeField] Slider slider;
    [SerializeField] Text hpText;
    [SerializeField] Text blockText;
    [SerializeField] GameObject blockImage;


    public void Init(GameObject gameObject)
    {
        gameObject.TryGetComponent(out target);
        target.TryGetComponent(out BoxCollider2D col);
        float sizeY = col.size.y * 0.5f * target.transform.localScale.y;
        distance = new Vector3(0, sizeY, 0);
        Vector2 v1 = Camera.main.WorldToScreenPoint(col.bounds.min);
        Vector2 v2 = Camera.main.WorldToScreenPoint(col.bounds.max);
        float sizeX = v2.x - v1.x;
        rectT.sizeDelta = new Vector2(sizeX, rectT.sizeDelta.y);
        Vector3 scrPos = Camera.main.WorldToScreenPoint(target.transform.position - distance);
        rectT.position = scrPos;
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
}
