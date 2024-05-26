using SplashKitSDK;

public class RectangleCollider : Collider
{
    public float width;
    public float height;

    public Rectangle Rectangle=> new Rectangle{X=position.X,Y=position.Y,Width=width,Height=height};

    public override bool CheckCollisionWith(Collider other){
        if(other is RectangleCollider rectangleCollider){
            return SplashKit.RectanglesIntersect(rectangleCollider.Rectangle,Rectangle );    
        }

        return false;
    }

    public override void Update(float timeDelta)
    {
    }

    public override void Start()
    {
    }
}