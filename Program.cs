using System;
using SplashKitSDK;

namespace _1_5d
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Flappy Bird",600,1000);
            Game game = new Game();
            while(!window.CloseRequested){
                SplashKit.ProcessEvents();
                window.Clear(Color.White);
                game.Tick();
                window.Refresh(targetFps:60);
            }
        }
    }
}
