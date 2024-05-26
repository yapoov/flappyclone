using SplashKitSDK;

public class CollisionChecker : Component
{
    public List<Collider> colliders = new();

    public Collider playerCollider;
    public override void Start()
    {
        Console.WriteLine(colliders.Count);
    }

    public override void Update(float timeDelta)
    {

        foreach (var collider in colliders)
        {
            if (collider == playerCollider || collider==null)
            {
                continue;
            }

            if (collider.CheckCollisionWith(playerCollider))
            {

                if (collider is RectangleCollider rectCol && playerCollider is RectangleCollider playerRectCol)
                {

                    var playerPhysics = playerCollider.gameObject.GetComponent<PhysicsObject>();
                    //horribly inneficent resolve;
                    while(SplashKit.RectanglesIntersect(playerRectCol.Rectangle,rectCol.Rectangle)){
                        playerCollider.transform.position.X -= playerPhysics.velocity.X * 0.01f;
                        playerCollider.transform.position.Y -= playerPhysics.velocity.Y * 0.01f;
                    }
                    playerPhysics.velocity.X *=-1;
                }
                collider.OnCollision?.Invoke(playerCollider);
                playerCollider.OnCollision?.Invoke(collider);
            }
        }
    }

    
}