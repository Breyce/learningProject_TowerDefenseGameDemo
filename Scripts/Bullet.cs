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

        //方法一：检测实体运动速度，因为到达Enemy位置之后的运动速度会下降，因此可以检测物体运动速度
        if (dir.magnitude < distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }
    /*
     *  方法二： 通过给子弹添加刚体，并将其collider设置为isTrigger之后，通过出发碰撞实现功能
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
