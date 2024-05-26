using System.Runtime.CompilerServices;
using SplashKitSDK;

public abstract class Collider:Component{
    public System.Action<Collider> OnCollision;  
    public abstract bool CheckCollisionWith(Collider other);
}