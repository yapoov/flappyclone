using SplashKitSDK;

public static class Utils{


    public static float AngleTo(this Vector2D a, Vector2D b){

        double dot = SplashKit.DotProduct(a,b);

        double len = SplashKit.VectorMagnitude(a)* SplashKit.VectorMagnitude(b);
    
        return (float) Math.Acos(dot/len);
    }

    public static Point2D ToPoint2D(this Vector2D vector)=>new Point2D{X=vector.X,Y=vector.Y};

    public static float RadianToDeg = 57.2958f;
}