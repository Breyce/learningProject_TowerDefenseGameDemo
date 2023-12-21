# Tower Defense

## Development Day 1:

1. 在制作游戏时的便利方法，可以用来在开发模式下直接描绘出武器范围：

   ```
       private void OnDrawGizmosSelected()
       {
           Gizmos.color = Color.red;
           Gizmos.DrawWireSphere(transform.position, range);
       }
   ```

2. `OnTriggerEnter`执行条件有三个：

   1、两个物体都必须有碰撞器（`Collider`）组件；

   2、其中一个物体的碰撞器（`Collider`）的`IsTrigger`属性必须勾上；

   3、**最重要的一点，其中一个物体必须有刚体（`Rigidbody`）组件。如果是一个运动的物体（如子弹）去碰撞一个静止的物体，则刚体（`Rigidbody`）组件必须加在运动的物体上，否则无法触发`OnOnTriggerEnter`函数。所以这时候子弹身上就要加一个`Rigidboyd`而不是`character controller`；**