using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chapt4 : MonoBehaviour
{
    void Start()
    {
        CallBack();       
    }

    void CallBack()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(Vector3.one * 3, 2));
        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(-Vector3.one * 3, 2));

        sequence.Append(transform.DOMove(Vector3.one, 2));
        sequence.AppendInterval(1); // 停止一秒
        sequence.Append(transform.DOMove(new Vector3(2, 0, 0), 2));

        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(-Vector3.one, 2));
        // 也可以使用预添加来添加回调函数
        sequence.PrependCallback(() =>
        {
            print("Prepend call back here...");
        });

        // 在某个位置插入一个回调函数
        sequence.InsertCallback(2, () =>
        {
            print("My call back");
        });
    }

    void Join()
    {
        // 除了使用insert，也可以使用join混合两种效果动画效果
        // Join不用指定开始时间，开始时间是最近一次Append所指定的开始时间
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(Vector3.one, 2));
        sequence.Join(transform.DOScale(Vector3.one * 2, 2));
        sequence.AppendInterval(1); // 停止一秒
        sequence.Append(transform.DOMove(new Vector3(2, 0, 0), 2));
    }

    void Prepend()
    {
        Sequence sequence = DOTween.Sequence();

        // 无论prepend是在哪儿，一定会先执行序列里面所有prepend的序列
        // 并且按照栈的先进后出的规则执行
        // 执行完所有的prepend之后，才执行append添加的序列
        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(Vector3.one * 3, 2));
        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(-Vector3.one * 3, 2));

        sequence.Append(transform.DOMove(Vector3.one, 2));
        sequence.AppendInterval(1); // 停止一秒
        sequence.Append(transform.DOMove(new Vector3(2, 0, 0), 2));

        sequence.PrependInterval(1);
        sequence.Prepend(transform.DOMove(-Vector3.one, 2));
    }

    void Test()
    {
        // 序列是让Dotween能够顺序执行某些动作，而不是忽略除了最后一个
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(Vector3.one, 2));
        sequence.AppendInterval(1); // 停止一秒
        sequence.Append(transform.DOMove(new Vector3(2, 0, 0), 2));

        // 在第0秒的位置插入一个动作，总的时长不变，这个动作会将之前的第一个动作的0-1秒覆盖掉
        // 如果插入的位置大于之前的总时长，则会扩充总时长
        //sequence.Insert(0, transform.DOMove(-Vector3.one, 1));

        // 如果插入的动作改变的属性跟之前不一样，则会混合效果
        //sequence.Insert(0, transform.DOScale(Vector3.one * 2, 2));
    }    
}
