/*
作者名称:YHB

脚本作用:平行移动---用来控制不同层面上的物体的移动快慢

建立时间:2016.8.6.13.53
*/

using UnityEngine;
using System.Collections;

public class ParallelTransport : MonoBehaviour
{
    #region 字段
    public float ParallelFactor;//移动的幅度，越远的东西移动的距离越小

    private Vector3 cameraTransform;//临时记录主摄像机的位置
    private Camera mainCamera;//主摄像机
    #endregion

    #region Unity内置函数
    void Start()
    {
        mainCamera = Camera.main;//缓存当前的主摄像机
        cameraTransform = mainCamera.transform.position;//缓存当前的主摄像机的初始位置
    }
    void Update()
    {
        MoveObject();
    }
    #endregion

    #region 物体移动方法
    void MoveObject()
    {
        //距离---当前相机的位置减去上面缓存的相机的位置
        Vector3 dir = mainCamera.transform.position - cameraTransform;

        //因为这个游戏的背景物体只需要的X轴上移动就行了，所以距离dir的y轴和z轴都是0
        dir.y = 0;
        dir.z = 0;

        //移动脚本挂载的物体的位置(这个脚本是挂载到背景物体上的，越是后面的背景移动的距离越小)
        this.transform.position += dir / ParallelFactor;//这里除以移动幅度可以在外部调试

        //这一步是关键，不然每次dir的值都是当前相机的位置减去000位置的相机，那就不能算是距离上的移动了
        cameraTransform = mainCamera.transform.position;
    }
    #endregion
}
