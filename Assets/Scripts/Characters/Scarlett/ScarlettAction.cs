using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarlettAction : MonoBehaviour
{
    Animator animator;
    public Rigidbody rb;
    //public GameObject goldObj;
    public GameObject target;
    public int speed;
    /*public static int gold;
    public static int playerName;*/

    private Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }
    void Start()
    {
        /*        target=GameObject.FindWithTag("Player");*/
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get the Screen positions of the object
        Vector3 positionOnScreen = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mouseOnScreen = (Vector3)UnityEngine.Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        // Code from: https://www.codegrepper.com/code-examples/csharp/unity+wasd+movement
        //movement using wasd or arrow keys
        /*if(useNetwork==true)
        {
            float x= Input.GetAxis("Horizontal");
            float z= Input.GetAxis("Vertical");
            FindObjectOfType<GameManager>().OnlineMovement(x,z,angle);
        }*/
        /*Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));*/

        move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        /*this.transform.position += Movement * speed * Time.deltaTime;*/
        /*rotate(angle);*/
        /*ShootingUpdate();*/

    }


    //Code from: https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
    //character rotation towards mouse 
    void Update()
    {
        //Get the Screen positions of the object
        Vector3 positionOnScreen = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mouseOnScreen = (Vector3)UnityEngine.Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //rotate the player object towards mouse
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));

        //Shoot me pls
        /*ShootingUpdate();*/
        Animation();
    }


    //finding angle between two points
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg;
    }

    public void move(float x, float z)
    {
        Vector3 Movement = new Vector3(x, 0, z);
        transform.position += Movement * speed * Time.deltaTime;
        //Debug.Log(x + " " + z);
    }

    public void rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }

    /*void ShootingUpdate()
    {
        //if left mouse button
        if (Input.GetButton("Fire1"))
        {
            WeaponScript.gun.Shoot();
        }
    }*/


    void Animation()
    {
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isBackwards = animator.GetBool("isBackwards");
        bool movePressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("d") || Input.GetKey("s");
        bool walkPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool inAir = animator.GetBool("inAir");
        bool backwardsPressed = Input.GetKey("s");

        if (!isRunning && movePressed) // run state on w key
        {
            animator.SetBool("isRunning", true);
        }
        if (isRunning && !movePressed) // return to idle if no w key from run state
        {
            animator.SetBool("isRunning", false);
        }
        if (!isWalking && (movePressed && walkPressed)) // walk state when running on w + left shift
        {
            animator.SetBool("isWalking", true);
        }
        if (isWalking && (!movePressed || !walkPressed)) // return to idle if no w key from walk state
        {
            animator.SetBool("isWalking", false);
        }
        if (jumpPressed && !inAir) // jump if inAir is false
        {
            animator.SetBool("inAir", true);
        }
        if (!jumpPressed && inAir) // jump if inAir is true
        {
            animator.SetBool("inAir", false);
        }
        /*if (!isBackwards && backwardsPressed) // run state on s key
        {
            animator.SetBool("isBackwards", true);
        }
        if (isBackwards && !backwardsPressed) // 
        {
            animator.SetBool("isBackwards", false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.gameObject.GetComponent<Item>();

        if (item != null)
        {
            inventory.AddItem(item.data);
            Debug.Log(item.data);
            Destroy(other.gameObject);
        }
    }
}

