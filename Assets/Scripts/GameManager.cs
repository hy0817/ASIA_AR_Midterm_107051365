
using UnityEngine;

public class GameManager: MonoBehaviour
{
    [Header("girl")]
    public Transform girl;
    [Header("boy")]
    public Transform boy;
    [Header("虛擬搖桿")]
    public FixedJoystick  joystick;
    [Header("旋轉速度"),Range(0.3f,10f)]
    public float turn = 1.5f;
    [Header("縮放"),Range(0.1f,0.3f)]
    public float size = 0.1f;
    [Header("少女控制元件")]
    public Animator aniGirl;
    [Header("少年控制元件")]
    public Animator aniBoy;

    private void Start()
    {
        print("開始事件");
    }
    //public float test = 1;
   // public float test2 = 1;
   
    private void Update()
    {
        print(joystick.Vertical);

        girl.Rotate(0, joystick.Horizontal * turn, 0);
        boy.Rotate(0, joystick.Horizontal * turn, 0);

        girl.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;
        boy.localScale += new Vector3(1, 1, 1) * joystick.Vertical * size;

        girl.localScale = new Vector3(1,1,1)*Mathf.Clamp(girl.localScale.x, 0.1f, 0.3f);
        boy.localScale = new Vector3(1,1,1)*Mathf.Clamp(boy.localScale.x, 0.1f, 0.3f);
       // test = Mathf.Clamp(test, 0.5f, 3f);
        //print(Mathf.Clamp(test2, 0, 5));
        
    }
    public void Walk()
    {
        print("走路");
        aniGirl.SetTrigger("走路觸發");
        aniBoy.SetTrigger("走路觸發");
    }
    public void Jump()
    {
        aniGirl.SetTrigger("跳躍觸發");
    }
    public void Death()
    {
        aniBoy.SetTrigger("死亡觸發");
    }
}
