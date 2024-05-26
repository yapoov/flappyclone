using SplashKitSDK;

public abstract class Component
{

    public GameObject gameObject;
    public Transform transform => gameObject.transform;
    public Vector2D position { get => transform.position; set => transform.position = value; }
    public float rotation { get => transform.rotation; set => transform.rotation = value; }
    public Vector2D scale { get => transform.scale; set => transform.scale = value; }
    public Matrix2D transformMatrix => transform.transformMatrix;
    public abstract void Update(float timeDelta);
    public abstract void Start();
    public Component()
    {
        OnComponentCreated?.Invoke(this);
    }
    public static event Action<Component> OnComponentCreated = delegate { };
}