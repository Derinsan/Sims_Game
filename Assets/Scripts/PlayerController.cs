using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private GameObject buttonWalk;
    [Header("Печь")]
    [SerializeField] private GameObject buttonCooking;
    [SerializeField] private GameObject _bake;
    private Vector3 p;
    private Vector3 endPos;
    [SerializeField] private Vector3 _endPosCooking;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer spriteRendererBake;

    private NavMeshAgent _agent;
    private float speed;

    private bool _isGoCooking = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        endPos = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update()
    {
        Vector3 velocity = _agent.velocity;
        speed = velocity.magnitude;
        
        if (Shop._isShopOpen == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                var hit2D = Physics2D.Raycast(p, Vector2.zero); // Vector2.zero если нужен рейкаст именно под курсором

                if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Ground")
                {
                    buttonWalk.transform.position = new Vector3(p.x, p.y, -1);
                    buttonWalk.SetActive(true);
                    buttonCooking.SetActive(false);
                }

                if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Button")
                {
                    buttonWalk.SetActive(false);
                    _animator.SetFloat("Speed", speed);
                    endPos = new Vector3(p.x, p.y + 0.85f, 0);
                    _isGoCooking = false;
                }

                if (hit2D.collider != null && hit2D.collider.gameObject.tag == "Bake")
                {
                    buttonCooking.transform.position = new Vector3(_bake.transform.position.x, _bake.transform.position.y, _bake.transform.position.z - 1);
                    buttonCooking.SetActive(true);
                    buttonWalk.SetActive(false);
                }

                if (hit2D.collider != null && hit2D.collider.gameObject.tag == "CookingButton" && Shop._isShopOpen == false)
                {
                    buttonCooking.SetActive(false);
                    _isGoCooking = true;
                }
            }
        }

        if (transform.position == _endPosCooking && BakeMove.isCooking == false)
        {
            _animator.SetBool("Cooking", true);
            if (spriteRendererBake.flipX == true)
            {
                spriteRenderer.flipX = true;
            }
            else if (spriteRendererBake.flipX == false)
            {
                spriteRenderer.flipX = false;
            }
            if (Shop._isShopOpen == true)
            {
                _animator.SetBool("Cooking", false);
                _endPosCooking = new Vector3(20, 20 ,20);
            }
        }
        else
        {
            _animator.SetBool("Cooking", false);
        }
        
        _animator.SetFloat("Speed", speed);
        
        Cooking();
    }

    void FixedUpdate()
    {
        if (transform.position.x > endPos.x)
        {
            spriteRenderer.flipX = true;
        }
        else if (transform.position.x < endPos.x)
        {
            spriteRenderer.flipX = false;
        }

        _bake = GameObject.FindGameObjectWithTag("Bake");
        if (_bake != null)
        {
            spriteRendererBake = _bake.GetComponent<SpriteRenderer>();
        }
        
        _agent.SetDestination(endPos);
    }

    private void Cooking()
    {
        if (Shop._isShopOpen == false && _isGoCooking == true)
        {
            _animator.SetFloat("Speed", speed);
            _endPosCooking = new Vector3(_bake.transform.position.x + 0.02f, _bake.transform.position.y + 0.57f, transform.position.z);
            endPos = _endPosCooking;
        }
    }
}