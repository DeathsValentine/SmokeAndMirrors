using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarlettAction : MonoBehaviour
{
    Animator animator;
    public Rigidbody rb;
    //public GameObject goldObj;
    public int speed;
    /*public static int gold;
    public static int playerName;*/
    private bool noMovement;
    private bool noRotation;
    private Vector3 scarlettRotation;
    private Vector3 emptyRotation;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        emptyRotation = GetComponent<Transform>().rotation.eulerAngles;
        scarlettRotation = GetComponentInChildren<Transform>().rotation.eulerAngles;
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
        if (!noMovement)
        {
            move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        /*this.transform.position += Movement * speed * Time.deltaTime;*/
        /*rotate(angle);*/

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
        if (!noRotation)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        }

        BladeDance();
        Overwhelm();
        Dash();
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
    }

    public void rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle ,0f));
    }

    void Dash()
    {
        if (Input.GetKey("q"))
        {
            bool dashes = UseDash.dummy.Dash();
            if (dashes)
            {
                animator.SetBool("dash", true);
                Invoke("SetAnimationFalse", 0.5f);
            }
        }
    }

    void BladeDance()
    {
        if (Input.GetKey("e"))
        {
            bool dances = UseBladeDance.dummy.BladeDance();
            if (dances)
            {
                noRotation = true;
                animator.SetBool("spin", true);
                Invoke("SetNoRotation", 4f);
                Invoke("SetAnimationFalse", 3.0f);
            }
        }
    }

    void Overwhelm()
    {
        if (Input.GetKey("f"))
        {
            bool overwhelm = UseOverwhelm.dummy.Overwhelm();
            if (overwhelm)
            {
                noMovement = true;
                animator.SetBool("overwhelm", true);
                Invoke("SetAnimationFalse", 0.5f);
                Invoke("SetInAnimation", 2.5f);
            }
        }
    }

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
    }

    void SetAnimationFalse()
    {
        if (animator.GetBool("overwhelm")) animator.SetBool("overwhelm", false);
        if (animator.GetBool("dash")) animator.SetBool("dash", false);
        if (animator.GetBool("spin")) animator.SetBool("spin", false);
    }

    void SetNoRotation()
    {
        noRotation = false;
        scarlettRotation = new Vector3(0f, 180f, 0f);
        emptyRotation = new Vector3(0f, 0f, 0f);
    }

    void SetNoMovement()
    {
        noMovement = false;
    }
}
