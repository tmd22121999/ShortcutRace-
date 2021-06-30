using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed,rcy;
    public FloatingJoystick FloatingJoystick;
    public Rigidbody rb;
    public player thisplayer;
    public Animator ani;
    public Vector3 direction;
    public void FixedUpdate()
    {
        if(ani.GetBool("isHit")!=thisplayer.isHit)
            ani.SetBool("isHit",thisplayer.isHit);
        if(ani.GetBool("isKilling")!=thisplayer.isKilling){
            ani.SetBool("isKilling",thisplayer.isKilling);

        }
        direction = Vector3.forward * FloatingJoystick.Vertical + Vector3.right * FloatingJoystick.Horizontal;
        if(direction.magnitude>0.1f){
            ani.SetBool("isrunning",true);
            //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
            rb.MovePosition(rb.position+direction*speed);
            float rotateAngle= Vector3.SignedAngle(direction, Vector3.forward, Vector3.down);
            transform.eulerAngles  =new Vector3(0,rotateAngle,0);
        }else
        {
            ani.SetBool("isrunning",false);
        }
        RaycastHit hit;
        Vector3 dir=new Vector3(0,rcy,0);
        dir+=transform.forward;
         if (Physics.Raycast(transform.position,dir, out hit, 100)){
            
        }
    }
}