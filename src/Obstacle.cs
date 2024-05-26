using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;

public class Obstacle : Component
{
    private Rectangle topRectangle;
    private Rectangle bottomRectangle;
    public Obstacle(double Gap,double GapOffset, double Width = 200){

        double Height = SplashKit.ScreenHeight()/2 - Gap/2 - GapOffset;
        double nextY = Height+Gap;
        topRectangle = new Rectangle{X=position.X,Y=0,Width=Width,Height=Height};
        bottomRectangle = new Rectangle{X=position.X,Y=nextY,Width=Width,Height=SplashKit.ScreenHeight()};
    }

    public override void Start()
    {
        throw new NotImplementedException();
    }

    public override void Update(float timeDelta)
    {
        throw new NotImplementedException();
    }
}