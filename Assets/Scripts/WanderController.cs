using UnityEngine;

public class WanderController : MonoBehaviour {
    public EntityBase entityBase;
    private long nextWanderTime = 0;
    private long nextWanderDuration = 0;
    private bool wandering = false;

    void ChooseNextWander() {
        this.nextWanderTime = (long) (Time.time*1000) + Random.Range(1000, 5000);
        this.nextWanderDuration = Random.Range(200, 500);
    }

    void Start() {
        ChooseNextWander();
    }

    void Update() {
        if ((long) (Time.time * 1000) >= this.nextWanderTime) {
            if (!wandering) {
                //Debug.Log("it's wanderin time");
                wandering = true;
                this.entityBase.UpdateMovementState(Random.Range(-1, 2), Random.Range(-1, 2), EntityMovementState.WALK);
            } else {
                // we're wandering rn, check if our time is up
                if ((long) (Time.time * 1000) >= (this.nextWanderTime + this.nextWanderDuration)) {
                    wandering = false;
                    this.entityBase.UpdateMovementState(0, 0, EntityMovementState.IDLE);
                    ChooseNextWander();
                    //Debug.Log("no more");
                }
            }
        }
    }
}
