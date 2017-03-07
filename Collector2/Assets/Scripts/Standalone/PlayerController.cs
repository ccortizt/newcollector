using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float defaultMoveSpeed;
    private float effectTime = 4f;
    private bool isUnderEffect;

    private Vector3 dir;
    private float phoneAcceleration = 4f;
    private Rigidbody rb;

    private float sensibility = 0.15f;
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultMoveSpeed = moveSpeed;
        isUnderEffect = false;
    }

    void Update()
    {

        #if UNITY_ANDROID
        float Horizontal = Input.acceleration.x;
        float Vertical = Input.acceleration.y;
        
        //GameObject.Find("InGameHUD").transform.FindChild("Panel/Text").GetComponent<Text>().text =  ""+transform.position;
        //GameObject.Find("InGameHUD").transform.FindChild("Panel/Text").GetComponent<Text>().text =  Vertical+" "+Horizontal;

        if (Horizontal < -sensibility || Horizontal > sensibility || Vertical < -sensibility || Vertical > sensibility)
        {
            //anim.SetBool("isMoving", true);
            
            Vector3 movement = new Vector3(Vertical, 0, -Horizontal);
            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * (moveSpeed)); 

        //    if (Mathf.Abs(movement.x) > Mathf.Abs(movement.z))
        //    {

        //        //movement.y = 0;

        //        if (movement.x > 0)
        //        {
        //            //transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        //            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * 1); 

        //        }

        //        if (movement.x < 0)
        //        {
        //            //transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
        //            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * 1);

        //        }

        //    }
        //    else
        //    {
        //        //movement.x = 0;

        //        if (movement.z > 0)
        //        {
        //            //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * 1); //up

        //        }

        //        if (movement.z < 0)
        //        {
        //            //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        //            rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * 1);
        //        }
        //    }

        }
        //else
        //{
        //    rb.velocity = new Vector3(0f, 0f, 0f);
        //}

#else

        if (Input.GetAxisRaw("Horizontal") > 0.5f)
            {
         
                rb.MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed);
                //transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);

            }

            if (Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                     
                rb.MovePosition(transform.position - transform.right * Time.deltaTime * moveSpeed);
                //transform.rotation = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            }

            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                        
                rb.MovePosition(transform.position + transform.up * Time.deltaTime * moveSpeed);
                //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            }

            if (Input.GetAxisRaw("Vertical") < -0.5f)
            {

                rb.MovePosition(transform.position - transform.up * Time.deltaTime * moveSpeed);
                //transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
            }

        #endif

    }

    public void SetMoveSpeed(float percentage)
    {
        if (isUnderEffect)
        {
            RestoreMoveSpeed();
        }
        
        moveSpeed = (moveSpeed / 100) * percentage;
        isUnderEffect = true;
        StartCoroutine(RestoreMoveSpeedDelay());
        

    }

    public IEnumerator RestoreMoveSpeedDelay()
    {
        yield return new WaitForSeconds(effectTime);
        isUnderEffect = false;
        RestoreMoveSpeed();
    }

    private void RestoreMoveSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }


}
