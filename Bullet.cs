using System;
using SplashKitSDK;
public class Bullet{

    private Bitmap _PlayerBullet;
    public double X{ get ; private set;}
    public double Y{ get ; private set;}
    private Vector2D Velocity{get;set;}

    public Circle CollisionCircle{
        get{
            
            Point2D point2D=new Point2D();
            point2D.X=X;
            point2D.Y=Y;
            return SplashKit.CircleAt(point2D,5);
        }

    }
    public int Width{
        get{
            
            return 40;
        }
    }

    public int Height{
        get{
            return 40;
        }
    }
    public Bullet(Player _Player,Vector2D _ClickCordinates){

        SplashKit.LoadBitmap("Bullet","Bullet.png");
        _PlayerBullet=SplashKit.BitmapNamed("Bullet");


        const int SPEED=10;
        X=_Player.X;
        Y=_Player.Y;

        //point for robot
        Point2D fromPt=new Point2D(){
            X=_Player.X,Y=_Player.Y
        };
        //point for player
        Point2D toPt=new Point2D(){
            X=_ClickCordinates.X,Y=_ClickCordinates.Y
        };
        
        Vector2D dir=SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt,toPt));

        Velocity=SplashKit.VectorMultiply(dir,SPEED); 
        


    }
    public void Update(){
        X=X+Velocity.X;
        Y=Y+Velocity.Y;

    }
    public void Draw(){
        _PlayerBullet.Draw(X,Y);

        
    }
    public bool IsOffscreen(Window GameWindow){

        if(X<-Width || X>GameWindow.Width || Y< -Height || Y > GameWindow.Height){
            return true;
        }else
        {
            return false;
        }
    }
    public bool CollidedWith(Robot other){
        
        return _PlayerBullet.CircleCollision(X,Y,other.CollisionCircle);


    }

}