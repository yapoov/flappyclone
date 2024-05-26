using SplashKitSDK;

public class Game
{

    public List<GameObject> gameObjects = new();

    uint lastTick;
    SplashKitSDK.Timer timer;
    Player player;

    Queue<Action> startQueue = new();

    List<Drawer> drawers = new();
    bool gameOver;
    public Game()
    {
        Component.OnComponentCreated += (comp) => startQueue.Enqueue(comp.Start);
        Component.OnComponentCreated += (comp) =>
        {
            if (comp is Drawer drawer)
            {
                drawers.Add(drawer);
            }
        };


        timer = SplashKit.CreateTimer("mainloop");
        timer.Start();
        lastTick = timer.Ticks;


        player = CreateGameObjectWithComponent<Player>();
        player.transform.position.X = SplashKit.ScreenCenter().X;
        player.transform.position.Y = SplashKit.ScreenCenter().Y;
        player.transform.scale = new Vector2D { X = 6, Y = 6 };

        var drawer = new BitmapDrawer
        {
            bitmap = new Bitmap("bird", "bird.png"),
            columnCount = 4
        };

        var playerPhysics = new PhysicsObject();
        player.gameObject.AddComponent(drawer);
        player.gameObject.AddComponent(playerPhysics);


        var playerCollider = new RectangleCollider
        {
            width = drawer.bitmap.CellWidth,
            height = drawer.bitmap.CellHeight
        };
        player.gameObject.AddComponent(playerCollider);


        var rand = new Random();
        int gap= 250;
        for (int i = 1; i < 10; i++)
        {
            int offset = rand.Next(-300, 300);

            var topRect = CreateGameObjectWithComponent<RectangleDrawer>();
            topRect.transform.position.X = i * 1000;
            topRect.transform.position.Y = 0;
            topRect.height = SplashKit.ScreenHeight()/ 2 + offset;
            topRect.color = Color.SeaGreen;
            topRect.width = 200;

            var topRectCollider = new RectangleCollider
            {
                width = topRect.width,
                height = topRect.height
            };
            topRect.gameObject.AddComponent(topRectCollider);

            var bottomRect = CreateGameObjectWithComponent<RectangleDrawer>();        
            bottomRect.transform.position.Y  = topRect.height + gap;
            bottomRect.transform.position.X = i * 1000;
            bottomRect.height = SplashKit.ScreenHeight();
            bottomRect.width = 200;
            bottomRect.color = Color.SeaGreen;

            var bottomRectCollider = new RectangleCollider
            {
                width = bottomRect.width,
                height = bottomRect.height
            };
            bottomRect.gameObject.AddComponent(bottomRectCollider);

        }


        var collChecker = CreateGameObjectWithComponent<CollisionChecker>();
        collChecker.colliders = gameObjects.Select(e=>e.GetComponent<Collider>()).ToList();
        collChecker.playerCollider = playerCollider;
    }
    public void Tick()
    {

        while (startQueue.Count > 0)
        {
            startQueue.Dequeue().Invoke();
        }

        float timeDelta = (timer.Ticks - lastTick) / 1000f;
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.Update(timeDelta);
        }

        foreach (Drawer drawer in drawers)
        {
            drawer.Draw();
        }

        SplashKit.SetCameraPosition(new Point2D { X = player.transform.position.X - SplashKit.ScreenWidth() * 0.4f, Y = 0 });
        lastTick = timer.Ticks;
    }


    public GameObject CreateGameObject(){

        var gameObject = new GameObject();
        gameObjects.Add(gameObject);
        return gameObject;
    }
    public  T CreateGameObjectWithComponent<T>() where T : Component, new()
    {

        var res = new T();
        var gameObject = CreateGameObject();
        gameObject.AddComponent(res);
        return res;
    }
}
