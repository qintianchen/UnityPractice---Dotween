using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chapt2 : MonoBehaviour
{
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        Test();
    }

    void Test()
    {
        // 将相机的宽高比变成 1:1. 注意这里设置的Aspect跟Game视图的Aspect不一样
        // 设置Game视图的Aspect的时候,纵横的像素密度不会改变,场景不会产生形变
        // 但是这里改变Aspect之后,原来纵横各需要显示多少像素还是显示多少像素
        // 但是因为强行改变了相机的Aspect,纵横的像素密度不同了,物体就会产生形变
        //cam.DOAspect(1, 2);

        // 改变相机的颜色
        //cam.DOColor(Color.red, 2);

        // 改变近切面
        //cam.DONearClipPlane(400f, 2);

        // 改变远切面
        //cam.DOFarClipPlane(600f, 2);

        // 控制透视模式的相机的视域
        //cam.DOFieldOfView(100, 2);

        // 控制正交相机的视域
        //cam.DOOrthoSize(100, 2);

        // 控制相机在屏幕空间的显示位置和大小，可以实现一些分屏的效果
        //cam.DORect(new Rect(0, 0, 0.5f, 0.5f), 2);

        // 也可以指定相机显示Rect的绝对像素大小
        //cam.DOPixelRect(new Rect(0, 0, 512, 200), 2);

        // 随机震动
        cam.DOShakePosition(2);
    }
}
    