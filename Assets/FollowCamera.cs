using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform FoxTr = null;
    [Range(0.0f, 20.0f)] private float dist = 1f;
    [Range(0.0f, 20.0f)] private float height = 1f;
    [Range(0.0f, 20.0f)] private float smoothRotate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        FoxTr = GameObject.Find("Fox").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*���� ���� * �ð� * ���� �ӵ� * 0.5f * ������� �Ÿ�*/
    }

    private void LateUpdate()
    {
        float currYAngle = Mathf.LerpAngle(transform.eulerAngles.y, FoxTr.eulerAngles.y, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0f, currYAngle, 0f);

        transform.position = FoxTr.position - (rot * Vector3.forward * dist) + (Vector3.up * height);

        transform.LookAt(FoxTr.position);
    }
}
