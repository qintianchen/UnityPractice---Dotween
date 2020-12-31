using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Chapt3 : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();

        Test();
    }

    void Test()
    {
        // 打字机效果，注意这里的变化速率是先快后慢
        var doText = text.DOText("话说很久很久以前，有一个农夫在河里丢了一块斧头，突然河的中央升起一个老人，手里拿着三把斧头问农夫道：你丢的是这把金斧头，还是这把银斧头，还是这把破烂的铁斧头？", 10);
        // 设置速率为线性变化
        doText.SetEase(Ease.Linear);
    }
}
