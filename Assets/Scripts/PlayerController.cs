using UnityEngine;

public class PlayerController : MonoBehaviour {
    public EntityBase entityBase;

    void Start() {
        
    }

    void Update() {
        int vert = 0;
        int horiz = 0;

        if (Input.GetKey("w")) vert = 1;
        if (Input.GetKey("s")) vert = -1;
        if (Input.GetKey("d")) horiz = 1;
        if (Input.GetKey("a")) horiz = -1;

        if (vert != 0 || horiz != 0) {
            this.entityBase.UpdateMovementState(vert, horiz, EntityMovementState.WALK);
        } else {
            this.entityBase.UpdateMovementState(vert, horiz, EntityMovementState.IDLE);
        }

    }
}
