using System;
using SplashKitSDK;

public class Program
{
    public static void Main()
    {
        Window window=new Window("RobotDodge",800,600);
        RobotDodge robotDodge=new RobotDodge(window);

        while(!window.CloseRequested && !robotDodge.Quit){
            
            
            robotDodge.Draw();
            robotDodge.HandleInput();
            robotDodge.Update();

        }


    }
}
