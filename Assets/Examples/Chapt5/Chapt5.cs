using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chapt5 : MonoBehaviour
{
    void Start()
    {
        // 将动画 “移动物体当前点移动到Vector3.one” 循环执行三次
        //transform.DOMove(Vector3.one, 1).SetLoops(3);

        // 物体会像悠悠球一样，执行动画，然后反向执行动画，然后执行动画。。。
        // Setloops第一个参数设置-1可以无限循环下去
        //transform.DOMove(Vector3.one, 1).SetLoops(3, LoopType.Yoyo);

        // 下面的方法也能达到相同的效果，同时SetAutoKill()可以在以后不用到当前动画的时候自动销毁
        //TweenParams tp = new TweenParams();
        //tp.SetLoops(3, LoopType.Yoyo);
        //transform.DOMove(Vector3.one, 1).SetAs(tp).SetAutoKill();

        // 表示DoMove中给的第一个参数表示运动的起始点运动回原点
        transform.DOMove(Vector3.one, 1).From();

        // 运动完之后停留3秒
        transform.DOMove(Vector3.one, 1).SetDelay(3);

        // 第二个参数1此时表示速度
        transform.DOMove(Vector3.one, 1).SetSpeedBased();
    }
}
