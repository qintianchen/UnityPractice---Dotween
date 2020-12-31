using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chapt1 : MonoBehaviour
{
    public Gradient gradient;

    void Start()
    {
        ChangeMaterial();
    }

    void ChangeMaterial()
    {
        Material mat1 = GetComponent<MeshRenderer>().material;

        // 默认是改变Shader的 _Color属性
        //mat1.DOColor(Color.red, 2);

        // 动手指定需要变更的属性名称
        //mat1.DOColor(Color.red, "_TintColor", 2);

        // 设置指定颜色属性的值
        //mat1.SetColor("_Color", Color.red);

        // 逐渐透明化,注意这里Shader需要使用Transparent渲染通道
        //mat1.DOColor(Color.clear, 2);

        // 透明化的第二种方法
        //mat1.DOFade(0, 2);

        // 完成颜色渐变的效果,如果shader没有_Color属性,也可以在第二个参数指定属性名
        //mat1.DOGradientColor(gradient, 2);

        // 改变材质采样的offset
        //mat1.DOOffset(new Vector2(1, 1), 2);

        // 通用的改变某个属性的值,必须指定属性名,下面这个例子也是物体透明化的效果
        //mat1.DOVector(Color.clear, "_Color", 2);

        // ?????????????????????????????????????????        
        // 以下代码原本是想让物体最终变成黄色,但是在Unity 2019.4.14f 上测试有bug,物体最终显示的是很暗的黄色,接近黑色
        //mat1.DOBlendableColor(Color.red, 2);
        //mat1.DOBlendableColor(Color.green, 2);
    }

    void Blend()
    {
        // 直接连续写下面这两个方法的话，物体根本就不会走到 (1,1,1) 在走到 (-2,-2,-2)，最终结果就是走到了 (-2,-2,-2)
        //transform.DOMove(new Vector3(1, 1, 1), 2);
        //transform.DOMove(new Vector3(-2, -2, -2), 2);

        // 连续写带Blend的方法会先计算所有的效果最终的结果，然后在做动画，最终效果是物体直接走到了 (-1,-1,-1) 
        transform.DOBlendableMoveBy(new Vector3(1, 1, 1), 2);
        transform.DOBlendableMoveBy(new Vector3(-2, -2, -2), 2);
    }

    void Shake()
    {
        // 随机震动，可以用来实现相机的震动效果
        transform.DOShakePosition(2, 1, 10, 90);
    }

    void Scale_Punch()
    {
        // 缩放
        //transform.DOScale(new Vector3(2, 2, 2), 2);

        // vibrato：震动的次数，elasticity：弹性系数
        //transform.DOPunchPosition(new Vector3(0, 1, 0), duration:2, vibrato:3, elasticity:0.1f);       

        // 缩放震动
        //transform.DOPunchScale(new Vector3(2, 2, 2), 2, 3, 0.1f);

        // 旋转震动
        transform.DOPunchRotation(new Vector3(50, 50, 50), 2, 3, 0.1f);
    }

    void Move_Rotate()
    {
        // 移动到Vector3.one，耗时2秒
        transform.DOMove(Vector3.one, 2);

        // /也可以进行单轴向的Move
        transform.DOMoveX(1, 2);

        // 移动local Position
        transform.DOLocalMove(Vector3.one, 2);

        // 旋转
        transform.DORotate(new Vector3(50, 50, 50), 2);
    }
}
