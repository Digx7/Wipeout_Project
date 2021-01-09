// Digx7
// Will move an object using a Rigidbody2D
using UnityEngine;

public class ObjectMover : MonoBehaviour {

    [Tooltip("If this ObjectMover is activated")]
    [SerializeField] private bool isOn = false;

    [SerializeField] private bool StartOnAwake = false;

    [Header("Movement")]
    [SerializeField] private int moveSpeed;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody rb_3D;

    public enum MovementMode { TowardDirection, TowardObject }

    [Tooltip("TowardDirection: Move in one preset direction\nTowardObject: Move toward a given GameObject")]
    [SerializeField] private MovementMode movementMode = MovementMode.TowardDirection;

    public enum MomentumMode { Velocity, AddForce }

    [Tooltip("Velocity: Move at constant speed\nAddForce: Move at faster and faster rate")]
    [SerializeField] private MomentumMode momentumMode = MomentumMode.Velocity;

    public enum MovementDimension { _3D, _2D }

    [SerializeField] private MovementDimension movementDimension = MovementDimension._2D;

    [Space]
    [Header("Toward Direction Mode")]
    [Tooltip("Only works in TowardDirection Movement Mode")]
    [SerializeField] private Vector3 directionToMove;

    [SerializeField] private bool useLocalSpace = false;

    [Header("Toward Object Mode")]
    [Tooltip("Only works in TowardObject Movement Mode")]
    [SerializeField] private GameObject objectToMoveTowards;

    [SerializeField] private bool lookForGameObjectOnAwake = false;
    [SerializeField] private string tagOfGameObjectToLookFor;

    private Vector3 forwardVel;
    private Vector3 horizontalVel;

    public void Awake() {
        if (lookForGameObjectOnAwake) findGameObjectWithTag();
        if (StartOnAwake) isOn = true;
    }

    public void FixedUpdate() {
        if (isOn && movementMode == MovementMode.TowardDirection) {
            if (!useLocalSpace) {
              if(momentumMode == MomentumMode.Velocity) MoveObject(1);
              else MoveObject(2);
            }
            else {
                forwardVel = transform.right * moveSpeed * directionToMove.x;
                horizontalVel = transform.up * moveSpeed * directionToMove.y;

                if(momentumMode == MomentumMode.Velocity) MoveObject(3);
                else MoveObject(4);
            }
        } else if (isOn && movementMode == MovementMode.TowardObject) {
            directionToMove = objectToMoveTowards.transform.position - gameObject.transform.position;
            Vector3.Normalize(directionToMove);

            if(momentumMode == MomentumMode.Velocity) MoveObject(1);
            else MoveObject(2);
        }
    }

    public void MoveObject(int input){
      switch(input){
        case 1 :
          if(movementDimension == MovementDimension._2D) rb.velocity = directionToMove * moveSpeed;
          else rb_3D.velocity = directionToMove * moveSpeed;
          break;
        case 2 :
          if(movementDimension == MovementDimension._2D) rb.AddForce(directionToMove * moveSpeed, ForceMode2D.Impulse);
          else rb_3D.AddForce(directionToMove * moveSpeed, ForceMode.Impulse);
          break;
        case 3 :
          if(movementDimension == MovementDimension._2D) rb.velocity = forwardVel + horizontalVel;
          else rb_3D.velocity = forwardVel + horizontalVel;
          break;
        case 4 :
          if(movementDimension == MovementDimension._2D) rb.AddForce(forwardVel + horizontalVel, ForceMode2D.Impulse);
          else rb_3D.AddForce(forwardVel + horizontalVel, ForceMode.Impulse);
          break;

      }
    }

    public void toggleIsOn() {
        isOn = !isOn;
    }

    // --- Get and Set Funtions ---------------------------
    public int getMoveSpeed() {
        return moveSpeed;
    }

    public bool getIsOn() {
        return isOn;
    }

    public void setIsOn(bool input) {
        isOn = input;
    }

    public void zeroOutVelocity() {
        rb.velocity = new Vector3(0, 0, 0);
    }

    public Rigidbody2D getRB() {
        return rb;
    }

    public Rigidbody getRB_3D() {
        return rb_3D;
    }

    public void setRB(Rigidbody2D _rb) {
        rb = _rb;
    }

    public void setRB_3D(Rigidbody _rb) {
        rb_3D = _rb;
    }

    public void setDirectionToMoveTo(Vector3 direction) {
        directionToMove = direction;
    }

    public void setDirectionToMoveTo(Vector2 direction) {
        directionToMove = new Vector3(direction.x, direction.y, 0);
    }

    public void setObjectToMoveTowards(GameObject target) {
        objectToMoveTowards = target;
    }

    // --- Auto set Object -----------------

    public bool doesThisObjectHaveTagImLookingFor(GameObject obj) {
        if (obj.tag == tagOfGameObjectToLookFor) return true;
        return false;
    }

    public void findGameObjectWithTag() {
        GameObject[] _object = GameObject.FindGameObjectsWithTag(tagOfGameObjectToLookFor);

        int i = 1;
        if (i == _object.Length) {
            objectToMoveTowards = _object[0];
        }
    }
}
