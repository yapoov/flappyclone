using System.Formats.Tar;
using SplashKitSDK;

public class Player : Component
{
    private float currentCell;
    bool shouldPlayAnim;
    bool isDead;
    public event Action OnPlayerDeath;
    public static Player instance;
    PhysicsObject? physicsObject;
    BitmapDrawer bitmapDrawer;
    public override void Start()
    {
        instance = this;
        physicsObject = gameObject.GetComponent<PhysicsObject>();
        bitmapDrawer = gameObject.GetComponent<BitmapDrawer>();
        gameObject.GetComponent<Collider>().OnCollision+=OnCollision;
        physicsObject.velocity.X = 200;
    }

    private void OnCollision(Collider collider)
    {
        Die();
    }

    public override void Update(float timeDelta)
    {

        if (!isDead && SplashKit.MouseClicked(MouseButton.LeftButton))
        {
            physicsObject.velocity.Y = 500;
            bitmapDrawer.PlayAnimation(0.25f);
        }

        if (physicsObject != null)
        {
            rotation = -90f + Utils.RadianToDeg * new Vector2D { X = 0, Y = 1 }.AngleTo(physicsObject.velocity);
        }

        transform.position.Y = Math.Clamp(position.Y, 0, SplashKit.ScreenHeight() + bitmapDrawer.bitmap.Height);
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;
        physicsObject.velocity.X=0;
        OnPlayerDeath?.Invoke();
    }


}