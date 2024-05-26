using SplashKitSDK;

public class BitmapDrawer : Drawer
{
    public Bitmap bitmap;
    public int columnCount = 1;
    public int rowCount = 1;
    private bool isAnimationSheet;
    private float currentProgress;
    private bool isPlaying;
    private float animationSpeed;
    public override void Draw()
    {
        var options = SplashKit.OptionScaleBmp(transform.scale.X, transform.scale.Y);
        options.Angle = transform.rotation;

        if (isAnimationSheet)
        {
            options.DrawCell = (int)currentProgress;
        }

        bitmap.Draw(transform.position.X, transform.position.Y, options);
    }

    public override void Start()
    {
        if (rowCount > 1 || columnCount > 1)
        {
            isAnimationSheet = true;
            bitmap.SetCellDetails(bitmap.Width / columnCount, bitmap.Height / rowCount, columnCount, rowCount, columnCount * rowCount);
        }
    }

    public void PlayAnimation(float speed = 1)
    {

        isPlaying = true;
        animationSpeed = speed;
    }

    public override void Update(float timeDelta)
    {
        if (isPlaying)
        {
            currentProgress += animationSpeed * 1;
            if (currentProgress >= rowCount * columnCount)
            {
                isPlaying = false;
                currentProgress = 0;
            }
        }
    }
}