using UnityEngine;

public class PlanetSpin : MonoBehaviour
{
    public Transform orbitCenter; // 公转中心物体，例如太阳
    public float rotationSpeed = 25.0f; // 自转速度
    public float orbitSpeed = 10.0f; // 公转速度
    public float orbitRadius = 5.0f; // 公转半径
    public float orbitTilt = 0.0f; // 公转轨道的倾斜角度

    private Vector3 orbitAxis; // 公转轴

    void Start()
    {
        if (orbitCenter == null)
        {
            Debug.LogError("Orbit center is not set!");
            return;
        }

        // 设置公转轴，可以根据需要调整为不同的轴
        orbitAxis = Quaternion.Euler(orbitTilt, 0, 0) * Vector3.up;

        // 随机初始化行星的位置
        float randomAngle = Random.Range(0, 360) * Mathf.Deg2Rad; // 转换为弧度
        Vector3 orbitPosition = new Vector3(Mathf.Cos(randomAngle), 0, Mathf.Sin(randomAngle)) * orbitRadius;
        transform.position = orbitCenter.position + orbitPosition;
    }

    void Update()
    {
        // 执行自转
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // 执行公转
        transform.RotateAround(orbitCenter.position, orbitAxis, orbitSpeed * Time.deltaTime);
    }
}
