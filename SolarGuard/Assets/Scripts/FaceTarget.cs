using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public GameObject target; // 可在Unity编辑器中设置的目标对象

    void Start()
    {
        if (target != null)
        {
            // 计算从当前对象指向目标对象的方向向量
            Vector3 directionToTarget = target.transform.position - transform.position;
            directionToTarget.y = 0; // 保持y轴不变，确保是水平旋转

            // 创建一个朝向目标方向的旋转
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // 应用旋转到当前对象
            transform.rotation = targetRotation;
        }
    }
}
