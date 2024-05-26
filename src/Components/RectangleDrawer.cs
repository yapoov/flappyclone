using SplashKitSDK;

public class RectangleDrawer : Drawer
{

    public float width;
    public float height;
    public Color color;
    public override void Draw()
    {
        SplashKit.FillRectangle(color, new Rectangle
        {
            X = position.X,
            Y = position.Y,
            Width = width,
            Height = height
        });
    }
    public override void Start()
    {
    }
    public override void Update(float timeDelta)
    {

    }
}