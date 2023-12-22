using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = false;

    //���ƾ�ͷ�ƶ�
    [Header("Movement")]
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;

    //���ƾ�ͷ��ת
    [Header("Rotation")]
    public float sensX;
    public float sensY;

    void Update()
    {


        //���ƾ�ͷ�ƶ�
        if (Input.GetKeyDown(KeyCode.Escape)) doMovement = !doMovement;
        if (!doMovement)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness) {transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);}
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness) { transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World); }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness) { transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World); }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness) { transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World); }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        Vector3 rot = transform.localEulerAngles;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
        //Debug.Log(transform.position);

        //���ƾ�ͷ��ת
        if(Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            rot.y += mouseX;
            rot.x -= mouseY;

            //�������Ǹ���
            rot.x = Mathf.Clamp(rot.x, 45f, 90f);
            if (rot.y > 45 && rot.y < 180) rot.y = 45;
            else if (rot.y < 315 && rot.y >180) rot.y = 315;

            //Debug.Log(rot);
            transform.rotation = Quaternion.Euler(rot.x,rot.y,0f);
        }
    }
}
