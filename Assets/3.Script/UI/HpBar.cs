using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    Vector3 distance = Vector3.down * 100f;

    [SerializeField] AbstractMortals target; //enemy
    [SerializeField] RectTransform rectT;
    [SerializeField] Slider slider;
    [SerializeField] Text hpText;
    [SerializeField] Text blockText;


    public void Init(GameObject gameObject)
    {
        gameObject.TryGetComponent(out target);
        Vector3 scrPos = Camera.main.WorldToScreenPoint(target.transform.position);
        rectT.position = scrPos + distance;
    }
    private void Update()
    {
        slider.value = target.CurHp / target.MaxHp;
        hpText.text = $"{target.CurHp}/{target.MaxHp}";
        blockText.text = $"{target.Block}";
    }
}
