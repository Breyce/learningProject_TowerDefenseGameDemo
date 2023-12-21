using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject); 
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        //����һ�����ʵ���˶��ٶȣ���Ϊ����Enemyλ��֮����˶��ٶȻ��½�����˿��Լ�������˶��ٶ�
        if (dir.magnitude < distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    /*
     *  �������� ͨ�����ӵ���Ӹ��壬������collider����ΪisTrigger֮��ͨ��������ײʵ�ֹ���
     *  private void OnTriggerEnter(Collider other)
        {
            //Debug.Log(other);
            GameObject effectInstant = Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectInstant, 2f);
            Destroy(gameObject);
        }
     */


    void HitTarget()
    {
        //Debug.Log("Hit");
        GameObject effectInstant = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstant,2f);
        Destroy(gameObject);
    }
}
