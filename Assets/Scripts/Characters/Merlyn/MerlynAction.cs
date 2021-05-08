using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
public class MerlynAction : NetworkBehaviour
{
    Animator animator;
    public Rigidbody rb;
    //public GameObject goldObj;
    public int speed;
    /*public static int gold;
    public static int playerName;*/

    private DialogManager dialogManager;
    private bool noMovement;
    private bool noRotation;
    private bool inDialogue;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        dialogManager = GameObject.Find("DialogueManager").GetComponent<DialogManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
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
        if (dialogManager.GetInDialog())
        {
            inDialogue = true;
        }
        else
        {
            inDialogue = false;
        }
        if (!inDialogue)
        {
            if (Input.GetKey("left shift")) speed = 5;
            move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        /*this.transform.position += Movement * speed * Time.deltaTime;*/
        /*rotate(angle);*/
        /*ShootingUpdate();*/

    }


    //Code from: https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
    //character rotation towards mouse 
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        //Get the Screen positions of the object
        Vector3 positionOnScreen = UnityEngine.Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector3 mouseOnScreen = (Vector3)UnityEngine.Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

        //rotate the player object towards mouse
        if (!inDialogue)
        {
            if (!noRotation)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
            }
            Freeze();
            Teleport();
            Fireball();
            Animation();
        }
        else
        {
            SetAnimationFalse();
        }
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
        speed = 10;
    }

    public void rotate(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle,0f));
    }

    void Fireball()
    {
        if (Input.GetKey("q"))
        {
            bool shoots = ShootFireBall.dummy.Shoot();
            if(shoots)
            {
                animator.SetBool("fireballSkill", true);
                Invoke("SetAnimationFalse", 0.5f);
            }
        }
    }

    void Freeze()
    {
        if (Input.GetKey("e"))
        {
            bool shoots = ShootFreeze.dummy.Shoot();
            if (shoots)
            {
                animator.SetBool("iceSkill", true);
                Invoke("SetAnimationFalse", 0.5f);
            }
        }
    }

    void Teleport()
    {
        if (Input.GetKey("f"))
        {
            UseTeleport.dummy.Tele();
        }
    }

    void Animation()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
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
    }

    void SetAnimationFalse()
    {
        if (animator.GetBool("fireballSkill")) animator.SetBool("fireballSkill", false);
        if (animator.GetBool("iceSkill")) animator.SetBool("iceSkill", false);
        if (animator.GetBool("isRunning")) animator.SetBool("isRunning", false);
        if (animator.GetBool("isWalking")) animator.SetBool("isWalking", false);
    }
}
