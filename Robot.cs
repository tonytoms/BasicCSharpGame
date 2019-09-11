using System;
using SplashKitSDK;

public abstract class Robot{

    public double X{ get ; private set;}
    public double Y{ get ; private set;}
    public Color MainColor;
    private Vector2D Velocity{get;set;}

    public Circle CollisionCircle{
        get{
            
            Point2D point2D=new Point2D();
            point2D.X=X;
            point2D.Y=Y;
            return SplashKit.CircleAt(point2D,20);
        }

    }
    public int Width{
        get{
            
            return 50;
        }
    }

    public int Height{
        get{
            return 50;
        }
    }
    public Robot(Window GameWindow,Player player){
        //X=SplashKit.Rnd(GameWindow.Width-Width);
        //Y=SplashKit.Rnd(GameWindow.Height-Height);
        MainColor=Color.RandomRGB(200);

        //Y=0;
        //X=0;

        if(SplashKit.Rnd()<0.5){
                X=SplashKit.Rnd(GameWindow.Width);
                if(SplashKit.Rnd()<0.5){
                    Y=-Height;
                }else{
                    Y=GameWindow.Height;
                }


        }else{
            
                Y=SplashKit.Rnd(GameWindow.Height);
                if(SplashKit.Rnd()<0.5){
                    X=-Width;
                }else{
                    Y=GameWindow.Width;
                }


        }

        const int SPEED=4;

        //point for robot
        Point2D fromPt=new Point2D(){
            X=X,Y=Y
        };
        //point for player
        Point2D toPt=new Point2D(){
            X=player.X,Y=player.Y
        };
        
        Vector2D dir=SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt,toPt));

        Velocity=SplashKit.VectorMultiply(dir,SPEED); 
        


    }
    public void Update(){
        X=X+Velocity.X;
        Y=Y+Velocity.Y;

    }
    public abstract void Draw();
    public bool IsOffscreen(Window GameWindow){

        if(X<-Width || X>GameWindow.Width || Y< -Height || Y > GameWindow.Height){
            return true;
        }else
        {
            return false;
        }
        }
}
public class Boxy : Robot{

    
    public Boxy(Window GameWindow,Player player):base(GameWindow,player){
    }
    public override void Draw(){
        double leftX,rightX;
        double eyeY,mouthY;
        leftX=X+12;
        rightX=X+27;
        eyeY=Y+10;
        mouthY=Y+30;
        SplashKit.FillRectangle(Color.Gray,X,Y,50,50);
        SplashKit.DrawRectangle(MainColor,leftX,eyeY,10,10);
        SplashKit.DrawRectangle(MainColor,rightX,eyeY,10,10);
        SplashKit.DrawRectangle(MainColor,leftX,mouthY,25,10);
        SplashKit.DrawRectangle(MainColor,leftX+2,mouthY+2,21,6);
        
    }

}

public class Roundy : Robot{

    public Roundy(Window GameWindow,Player player):base(GameWindow,player){
    }  
    public override void Draw(){
        double leftX,midX,rightX;
        double midY,eyeY,mouthY;
        leftX=X+17;
        midX=X+25;
        rightX=X+33;

        midY=Y+25;
        eyeY=Y+20;
        mouthY=Y+35;

        SplashKit.FillCircle(Color.White,midX,midY,25);
        SplashKit.DrawCircle(Color.Gray,midX,midY,25);
        SplashKit.FillCircle(Color.RandomRGB(200),leftX,eyeY,5);
        SplashKit.FillCircle(Color.RandomRGB(200),rightX,eyeY,5);
        SplashKit.FillEllipse(Color.Gray,X,eyeY,50,30);
        SplashKit.DrawLine(Color.Black,X,mouthY,X+50,Y+35);


    } 
}

public class ThirdRobot : Robot{

    public ThirdRobot(Window GameWindow,Player player):base(GameWindow,player){
    }  
    public override void Draw(){
        double leftX,midX,rightX;
        double midY,eyeY,mouthY;
        leftX=X+17;
        midX=X+25;
        rightX=X+33;

        midY=Y+25;
        eyeY=Y+20;
        mouthY=Y+35;

        SplashKit.DrawRectangle(MainColor,X,Y,50,50);
        SplashKit.DrawRectangle(Color.SeaGreen,X+3,Y+3,45,45);
        SplashKit.FillCircle(MainColor,leftX,eyeY,5);
        SplashKit.FillCircle(MainColor,rightX,eyeY,5);
        SplashKit.FillEllipse(Color.Peru,X+10,eyeY+5,33,22);
        SplashKit.FillEllipse(Color.Ivory,X+14,eyeY+11,24,16);





    } 
}
    
