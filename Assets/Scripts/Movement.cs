using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {
   public float speed = 8.0f;
   public float speedMultiplier = 1f;
   public Vector2 initialDirection;
   public LayerMask obstacleLayer;

   public new Rigidbody2D rigidbody { get; private set; }
   public Vector2 direction { get; private set; }
   public Vector2 nextDirection { get; private set; }
   public Vector3 startingPosition { get; private set; }

   private void Awake() {
       rigidbody = GetComponent<Rigidbody2D>();
       startingPosition = transform.position;
   }

   public void Start() {
       ResetState();
   }

   public void ResetState() {
       speedMultiplier = 1f;
       this.direction = this.initialDirection;
       nextDirection = Vector2.zero;
       transform.position = this.startingPosition;
       rigidbody.isKinematic = false;
       enabled = true;
   }

   private void Update() {
       if (nextDirection != Vector2.zero) {
           SetDirection(nextDirection);
       }
       other();
   }

   public void FixedUpdated() {
       Vector2 position = this.rigidbody.position;
       Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;
       rigidbody.MovePosition(position + translation);
   }

   public void SetDirection(Vector2 direction, bool forced = false) {
       if (forced || !Occupied(direction)) {
           this.direction = direction;
           nextDirection = Vector2.zero;
       } else { 
           nextDirection = direction;
           this.direction = direction;
       }
   }

   public bool Occupied(Vector2 direction) {
       RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one * 0.75f, 0f, direction, 1.5f, obstacleLayer);
        return hit.collider != null;
   }

   public void other () {
       Vector2 position = this.rigidbody.position;
       Vector2 translation = this.direction * speed * speedMultiplier * Time.fixedDeltaTime;
       rigidbody.MovePosition(position + translation);
   }
}
