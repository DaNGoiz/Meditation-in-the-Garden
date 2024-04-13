using System.Collections;
using UnityEngine;

public class ButterflyTrail : MonoBehaviour
{
    public float speed = 5.0f;          // 蝴蝶的飞行速度
    public float directionChangeInterval = 3.0f; // 方向改变间隔，单位是秒
    private Vector3 currentDirection;   // 当前移动方向

    void Start()
    {
        SetInitialDirection();          // 设置初始方向
        StartCoroutine(ChangeDirectionRoutine()); // 开始周期性改变方向的协程
    }

    void Update()
    {
        // 根据当前方向和速度更新蝴蝶的位置
        transform.Translate(currentDirection * speed * Time.deltaTime, Space.World);
    }

    private void SetInitialDirection()
    {
        // 设置一个初始方向，仅水平变化
        currentDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        AdjustRotation();
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(directionChangeInterval);
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        // 改变方向，仅水平
        currentDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        AdjustRotation();
    }

    private void AdjustRotation()
    {
        // 调整蝴蝶的旋转以面向当前移动方向
        transform.rotation = Quaternion.LookRotation(currentDirection);
    }
}
