using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAnim : MonoBehaviour
{
    public GameObject butterfly;
    public GameObject leftWing;
    public GameObject leftPivot;
    public GameObject rightWing;
    public GameObject rightPivot;

    public float wingSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        leftWing.transform.RotateAround(leftPivot.transform.position, Vector3.left, wingSpeed * Time.deltaTime);
        rightWing.transform.RotateAround(rightPivot.transform.position, Vector3.left, -wingSpeed * Time.deltaTime);
    }

    IEnumerator StartButterflyAnim()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.6f);
            wingSpeed = -wingSpeed;
        }
    }
}
