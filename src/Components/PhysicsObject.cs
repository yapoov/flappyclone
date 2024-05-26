

using SplashKitSDK;

public class PhysicsObject:Component{
   
    public Vector2D velocity;
    public bool isStatic;

    public bool hasGravity = true;
    public override void Start()
    {
    }

    public override void Update(float timeDelta)
    {   

        if(hasGravity){
            velocity.Y-= 980*timeDelta;
        }

        transform.position.X += velocity.X * timeDelta;
        transform.position.Y -= velocity.Y * timeDelta;
    }
}