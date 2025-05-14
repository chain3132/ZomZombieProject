using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Inspactor
    [Header("Movement")]
    public Transform playerParentTransform;
    public float speed;
    public float xRange = 10;
    
    [Header("Bullet")]
    public GameObject projectilePrefab;
    public Transform bulletPoolingTransform;
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
    public Image[] bulletImage;
    public Sprite bulletOriginalImage;
    public Sprite bulletShadowImage;
    #endregion
    
    #region field
    private Animator animator;
    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;
    private int remainingBulletCount;
    private float regenCooldownTimer = 0;
    #endregion
    
    #region Life Cycle
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }
    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        animator = GetComponent<Animator>();
        remainingBulletCount = maxBulletCount;

    }
    #endregion
    
    #region Update
    void Update()
    {
        OnMove();
        OnShoot();
    }

    #endregion
    
    #region Movement

    private void OnMove()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        switch (horizontalInput)
        {
            case > 0:
                playerParentTransform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case < 0:
                playerParentTransform.rotation = Quaternion.Euler(0, -90, 0);
                break;
            default:
                animator.SetBool("isRunning",false);
                playerParentTransform.rotation = Quaternion.Euler(0, 0, 0);
                return;
        }
        IsPlayerOutOfBound();
        playerParentTransform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        animator.SetBool("isRunning",true);
    }

    private void IsPlayerOutOfBound()
    {
        if (transform.position.x < -xRange)
        {
            playerParentTransform.position = new Vector3(-xRange,transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            playerParentTransform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
    #endregion
    
    #region Shoot
    private void OnShoot()
    {
        if (shootAction.triggered && remainingBulletCount > 0)
        {
            remainingBulletCount--;
            animator.SetTrigger("isShooting");
            Instantiate(projectilePrefab, transform.position + Vector3.forward* 1.5f, transform.rotation,bulletPoolingTransform);
            regenCooldownTimer = bulletRegenerateCooldown;
            UpdateBulletImage();
        }

        if (remainingBulletCount <= 0)
        {
            regenCooldownTimer -= Time.deltaTime;
            if (regenCooldownTimer <= 0)
            {
                remainingBulletCount = maxBulletCount;
                UpdateBulletImage();
            }
        }
    }
    private void UpdateBulletImage()
    {
        for (int i = 0; i < bulletImage.Length; i++)
        {
            if (i < remainingBulletCount)
            {
                // Bullet available → show real bullet
                bulletImage[i].sprite = bulletOriginalImage; // Optional: assign a specific sprite if needed
            }
            else
            {
                bulletImage[i].sprite = bulletShadowImage;
            }
        }
    }

    #endregion
    

    
}
