using UnityEngine;

enum EntityDirection {
    DOWN = 0,
    LEFT = 1,
    UP = 2,
    RIGHT = 3,
}

public class PlayerBehaviour : MonoBehaviour {
    public Animator playerAnimator;
    public Rigidbody2D playerPhysics;
    private EntityDirection direction = EntityDirection.DOWN;
    private Vector2 velocity;
    private float walkSpeed = 5;

    void updateAnimatorDirection() {
        playerAnimator.SetInteger("facing", (int) direction);
    }

    void Start() {
        
    }

    void Update() {
        Vector2 pointingVec = new Vector2(0.0f, 0.0f);

        if (Input.GetKey("w")) {
            pointingVec.y += 1;
            direction = EntityDirection.UP;
        }

        if (Input.GetKey("s")) {
            pointingVec.y += -1;
            direction = EntityDirection.DOWN;
        }

        if (Input.GetKey("d")) {
            pointingVec.x += 1;
            direction = EntityDirection.RIGHT;
        }

        if (Input.GetKey("a")) {
            pointingVec.x += -1;
            direction = EntityDirection.LEFT;
        }

        playerPhysics.linearVelocity = pointingVec.normalized * walkSpeed;

        updateAnimatorDirection();

        if (pointingVec.magnitude > 0) {
            playerAnimator.SetBool("walking", true);
        } else {
            playerAnimator.SetBool("walking", false);
        }
    }

    void FixedUpdate() {
        //playerPhysics.MovePosition(playerPhysics.position + velocity * Time.fixedDeltaTime);
    }
}
