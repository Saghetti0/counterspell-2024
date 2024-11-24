using UnityEngine;

enum EntityDirection {
    DOWN = 0,
    LEFT = 1,
    UP = 2,
    RIGHT = 3,
}

public class EntityMovementState {
    private EntityMovementState(string value) { Value = value; }

    public string Value { get; private set; }

    public static EntityMovementState IDLE { get { return new EntityMovementState("idle"); } }
    public static EntityMovementState WALK { get { return new EntityMovementState("walk"); } }
    public static EntityMovementState JUMP { get { return new EntityMovementState("run"); } }

    public override string ToString()
    {
        return Value;
    }
}

public class EntityBase : MonoBehaviour {
    public Animator animator;
    public Rigidbody2D physicsRigidbody;
    private EntityDirection direction = EntityDirection.DOWN;
    private Vector2 velocity;
    public float walkSpeed = 5;
    private string currentAnimState = "none";
    private int vertMovement = 0;
    private int horizMovement = 0;
    private EntityMovementState movementState = EntityMovementState.IDLE;

    public void UpdateMovementState(int vert, int horiz, EntityMovementState state) {
        this.vertMovement = vert;
        this.horizMovement = horiz;
        this.movementState = state;
    }

    void Start() {
        
    }

    void Update() {
        Vector2 pointingVec = new Vector2(0.0f, 0.0f);

        if (this.vertMovement == 1) {
            pointingVec.y += 1;
            direction = EntityDirection.UP;
        }

        if (this.vertMovement == -1) {
            pointingVec.y += -1;
            direction = EntityDirection.DOWN;
        }

        if (this.horizMovement == 1) {
            pointingVec.x += 1;
            direction = EntityDirection.RIGHT;
        }

        if (this.horizMovement == -1) {
            pointingVec.x += -1;
            direction = EntityDirection.LEFT;
        }

        this.physicsRigidbody.linearVelocity = pointingVec.normalized * walkSpeed;
        //this.walking = (pointingVec.magnitude > 0);

        updateAnimationState();
    }

    void updateAnimationState() {
        string newState = this.movementState.ToString();
        
        switch (this.direction) {
            case (EntityDirection.DOWN): {
                newState += "_down";
                break;
            }
            case (EntityDirection.LEFT): {
                newState += "_left";
                break;
            }
            case (EntityDirection.UP): {
                newState += "_up";
                break;
            }
            case (EntityDirection.RIGHT): {
                newState += "_right";
                break;
            }
        }

        if (newState != this.currentAnimState) {
            //Debug.Log("the fucking animation " + newState);
            this.animator.Play(newState);
            this.currentAnimState = newState;
        }
    }
}
