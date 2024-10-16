using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        public bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;

        //managers
        private GameManager gameManager;
        private InventoryManager inventoryManager;
        private SelectionManaer selectionManager; // yeah we misspelled the class name but thats ok
        //
        //Item Parameters
        private ItemsList itemList;
        private DraggableItem selectedItem;
        private SpriteRenderer heldItemGraphic;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
            selectionManager = GameObject.Find("SelectionManager").GetComponent<SelectionManaer>();
            heldItemGraphic = GameObject.Find("HeldObject").GetComponent<SpriteRenderer>();
            itemList = GameObject.Find("ItemsList").GetComponent<ItemsList>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            //reset attack anim trigger
            animator.SetInteger("attackTrigger", 0);
            //
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }
            //
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            //
            //Attacking!
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log($"{selectedItem.itemRef.name}");
                if (selectedItem.itemRef == itemList.ListRef[1])
                {
                    //Melee attack!
                    animator.SetInteger("attackTrigger", 1);
                }
            }
            //
            if (!isGrounded)animator.SetInteger("playerState", 2); // Turn on jump animation
            //
            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
            //
            //Set held item to selected item
            if (selectionManager.HotBarSlots[selectionManager.selectedSlot].GetComponentInChildren<DraggableItem>() != null)
            {
                selectedItem = selectionManager.HotBarSlots[selectionManager.selectedSlot].GetComponentInChildren<DraggableItem>();
                heldItemGraphic.sprite = selectedItem.imageRef.sprite;
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                inventoryManager.AddItem(other.GetComponent<Coin>().coinData);
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }
        }

        public bool canAttack()
        {
            return isGrounded;
        }
    }
}
