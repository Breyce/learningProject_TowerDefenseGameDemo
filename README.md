# Tower Defense

## Development Day 1: 2023.12.22

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

3. `Unity`的`Horizontal Layout Group`可以帮助快速进行网格排版：

   ![image-20231222115837194](Image/Horizontal Layout Group.png)

4. `Line Renderer`：制作`Laser Beamer`武器的时候用到的，效果就是画条线，调整调整可以做激光。

5. `Script Execution Order`：可以在`Edit->Project Setting->Script Execution Order`当中找到，当两个脚本的运行顺序非常必要时，可以通过这个方式来规定两个脚本运行的先后顺序。避免出现意外情况。

   <img src="Image/Script Execution Order.png" alt="image-20231222200802927"  />



小小打算：

1. 死亡金币的回馈是与被攻击的次数有关（被攻击的次数越多获得金币越多）；
2. 敌人的血量会随着放置的武器数量而增加；
3. 当血量上升到特定值时，敌人将拥有破坏武器的能力。



## Development Day 2: 2023.12.23

1. 当我们暂停游戏时，一般使用的是`Time.timeScale`，将整个游戏的时间冻结，但是这样会导致暂停页面（如果我们给暂停页面的显示设置了动画的话）的显示一直卡在动画的第一帧。从而无法展示。解决办法很简单，将这个显示动画的`Update Mode`设置为`Unscale Time`就好了。

   ![image-20231223202123194](Image/Unscaled Time.png)

2. 使用`Ctrl + Shift + F`：可以迅速将选中的游戏实体移动到在`Scene`当中的视角和位置



## Development Day 3: 2023.12.24

1. `public AnimationCurve curve;`：`Unity`自带的`AnimationCurve`可以很简便的实现一些曲线变化动画效果。

   <img src="Image/AnimationCurve.png" alt="image-20231224110209496" style="zoom:80%;" />

2. 一些排版组件：`Grid Layout Group`网格排版、`Horizontal Layout Group`水平排版、`Vertical Layout Group`垂直排版，`Content Size Fitter`自适应内容大小。

   ![image-20231224130330930](Image/Layout.png)

   用于实现滚动屏幕的组件：`Scroll Rect`实现滚动轴，`Scroll Mask`将滚动页面显示区域外的内容隐藏，有点像前端`CSS`的`overflow:hidden;`操作。

   ![image-20231224131217224](Image/Scroll.png)

3. 