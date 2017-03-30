using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    private float defaultMoveSpeed;
    private float effectTime = 4f;

    public Sprite ice;
    public Sprite slow;
    public Sprite speed;
    public Sprite none;

    public GameObject iceProp;
    public GameObject slowProp;
    public GameObject speedProp;


    private Vector3 dir;
    private float phoneAcceleration = 0.8f;
    private Rigidbody rb;

    private float sensibility = 0.15f;

    private string powerAcquired = "none";

    public VirtualJoystick moveJoystick;
    public VirtualButton shootButton;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        defaultMoveSpeed = moveSpeed;
#if UNITY_ANDROID
        moveJoystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VirtualJoystick>();
        shootButton = GameObject.FindGameObjectWithTag("ShootButton").GetComponent<VirtualButton>();
#endif

    }

    void Update()
    {

#if UNITY_ANDROID
        //float Horizontal = Input.acceleration.x;
        //float Vertical = Input.acceleration.y;

        float Horizontal = moveJoystick.InputDirection.x;
        float Vertical = moveJoystick.InputDirection.z;

        //if (Horizontal < -sensibility || Horizontal > sensibility || Vertical < -sensibility || Vertical > sensibility)
        //{
        //anim.SetBool("isMoving", true);

        Vector3 movement = new Vector3(Vertical, 0, -Horizontal);
        rb.MovePosition(transform.position + (movement * phoneAcceleration) * Time.deltaTime * (moveSpeed));

        if (shootButton.isPressed)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.z))
            {
                if (movement.x > 0)
                {
                    var prop = iceProp;

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position + transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position + transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position + transform.up, Quaternion.identity);
                    }
                    
                    SetPowerAcquired("none");
                    
                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    prop.GetComponent<Rigidbody>().velocity = prop.transform.right * 20;

                }

                if (movement.x < 0)
                {
                    var prop = iceProp;

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position - transform.up, Quaternion.identity);

                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position - transform.up, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position - transform.up, Quaternion.identity);
                    }

                    SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();                    
                    prop.GetComponent<Rigidbody>().velocity = -prop.transform.right * 20;
                }
            }
            else
            {
                if (movement.z > 0)
                {
                    var prop = iceProp;

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position - transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position - transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position - transform.right, Quaternion.identity);
                    }

                    SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    //prop.GetComponent<Rigidbody>().velocity = prop.transform.right * 20;
                    prop.GetComponent<Rigidbody>().velocity = prop.transform.forward * 20;
                }

                if (movement.z < 0)
                {
                    var prop = iceProp;

                    if (powerAcquired.Equals("ice"))
                    {
                        prop = Instantiate(iceProp, transform.position + transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("slow"))
                    {
                        prop = Instantiate(slowProp, transform.position + transform.right, Quaternion.identity);
                    }

                    if (powerAcquired.Equals("speed"))
                    {
                        prop = Instantiate(speedProp, transform.position + transform.right, Quaternion.identity);
                    }

                    SetPowerAcquired("none");

                    prop.GetComponent<AppleController>().SetMovementDisabled();
                    //prop.GetComponent<Rigidbody>().velocity = -prop.transform.right * 20;
                    prop.GetComponent<Rigidbody>().velocity = -prop.transform.forward * 20;
                }
            }


        }

#else        

        if (!Input.GetKey(KeyCode.Space))
        {
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
        }
        

        if (Input.GetKey(KeyCode.Space))
        {            

            if (Input.GetKey(KeyCode.DownArrow))
            {
                var prop = iceProp;

                if (powerAcquired.Equals("ice"))
                {
                    prop = Instantiate(iceProp, transform.position - transform.up, Quaternion.identity);
                }

                if (powerAcquired.Equals("slow"))
                {
                    prop = Instantiate(slowProp, transform.position - transform.up, Quaternion.identity);
                }

                if (powerAcquired.Equals("speed"))
                {
                    prop = Instantiate(speedProp, transform.position - transform.up, Quaternion.identity);
                }


                
                SetPowerAcquired("none");

                
                prop.GetComponent<AppleController>().SetMovementDisabled();
                prop.GetComponent<Rigidbody>().velocity = -prop.transform.right * 20;

            }


            if (Input.GetKey(KeyCode.UpArrow))
            {
                var prop = iceProp;

                if (powerAcquired.Equals("ice"))
                {
                    prop = Instantiate(iceProp, transform.position + transform.up, Quaternion.identity);
                }

                if (powerAcquired.Equals("slow"))
                {
                    prop = Instantiate(slowProp, transform.position + transform.up, Quaternion.identity);
                }

                if (powerAcquired.Equals("speed"))
                {
                    prop = Instantiate(speedProp, transform.position + transform.up, Quaternion.identity);
                }

                SetPowerAcquired("none");
                
                prop.GetComponent<AppleController>().SetMovementDisabled();
                prop.GetComponent<Rigidbody>().velocity = prop.transform.right * 20;

            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var prop = iceProp;

                if (powerAcquired.Equals("ice"))
                {
                    prop = Instantiate(iceProp, transform.position - transform.right, Quaternion.identity);
                    
                }

                if (powerAcquired.Equals("slow"))
                {
                    prop = Instantiate(slowProp, transform.position - transform.right, Quaternion.identity);
                }

                if (powerAcquired.Equals("speed"))
                {
                    prop = Instantiate(speedProp, transform.position - transform.right, Quaternion.identity);
                }

                SetPowerAcquired("none");
                
                prop.GetComponent<AppleController>().SetMovementDisabled();
                prop.GetComponent<Rigidbody>().velocity = prop.transform.forward * 20;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                var prop = iceProp;

                if (powerAcquired.Equals("ice"))
                {
                    prop = Instantiate(iceProp, transform.position + transform.right, Quaternion.identity);
                }

                if (powerAcquired.Equals("slow"))
                {
                    prop = Instantiate(slowProp, transform.position + transform.right, Quaternion.identity);
                }

                if (powerAcquired.Equals("speed"))
                {
                    prop = Instantiate(speedProp, transform.position + transform.right, Quaternion.identity);
                }
                
                SetPowerAcquired("none");
                
                prop.GetComponent<AppleController>().SetMovementDisabled();
                prop.GetComponent<Rigidbody>().velocity = -prop.transform.forward * 20;

            }
        }

#endif

    }

    public void SetMoveSpeed(float percentage)
    {
        moveSpeed = (defaultMoveSpeed / 100) * percentage;

        StartCoroutine(RestoreMoveSpeedDelay());
    }

    public IEnumerator RestoreMoveSpeedDelay()
    {
        yield return new WaitForSeconds(effectTime);

        RestoreMoveSpeed();
    }

    private void RestoreMoveSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }

    public void SetPowerAcquired(string newPower)
    {
        powerAcquired = newPower;
        string tag = "";

        if (gameObject.name.Equals("Player"))
        {
            tag = "PlayerItem";
        }
        else
        {
            tag = "EnemyItem";
        }

        if (powerAcquired.Equals("ice"))
        {
            GameObject.FindGameObjectWithTag(tag).GetComponent<Image>().sprite = ice;
        }

        if (powerAcquired.Equals("speed"))
        {
            GameObject.FindGameObjectWithTag(tag).GetComponent<Image>().sprite = speed;
        }

        if (powerAcquired.Equals("slow"))
        {
            GameObject.FindGameObjectWithTag(tag).GetComponent<Image>().sprite = slow;
        }

        if (powerAcquired.Equals("none"))
        {
            GameObject.FindGameObjectWithTag(tag).GetComponent<Image>().sprite = none;
        }
    }

    public string GetPowerAcquired()
    {
        return powerAcquired;
    }
}
