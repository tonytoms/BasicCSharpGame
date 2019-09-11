using System;
using SplashKitSDK;
 

public class Player{
    private Bitmap _PlayerBitmap;
    private Bitmap _PlayerLife;//Task 62
    public Bullet _Bullet{get;private set; }//Task 62
    public bool _Fired{get;private set; }//Task 62
    public double X{ get ; private set;}
    public double Y{ get ; private set;}
    public double _angle;
    public bool Quit{ get;private set; }
    const int SPEED=5;
    const int GAP=10;
    public int _Life;//Task 62
    public Timer _PlayerTimer{get;private set;}//Task 62 

    public int Width{
        get
        {
            return _PlayerBitmap.Width;
        }
    }


    public int Height{
        get
        {
            return _PlayerBitmap.Height;
        }
    }
    public double Angle
    {
        get { return _angle; }
        set { _angle = value; }
    }
    public Player(Window gameWindow){
        SplashKit.LoadBitmap("Player","Player.png");
        SplashKit.LoadBitmap("Life","Life.png");//Task 62
        _PlayerBitmap=SplashKit.BitmapNamed("Player");
        _PlayerLife=SplashKit.BitmapNamed("Life");//Task 62
        X=(gameWindow.Width-Width)/2;
        Y=(gameWindow.Height-Height)/2;
        _PlayerTimer=new Timer("Player Timer");//Task 62 
        _PlayerTimer.Start();//Task 62 
        _angle=0;
        Quit=false;
        _Life=5;//Task 62
        _Fired=false;//Task 62
        

    }
    public void Draw(){
        _PlayerBitmap.Draw(X,Y,SplashKit.OptionRotateBmp(_angle));
        
        // Task 62
        for(int i=0;i<_Life;i++){
          _PlayerLife.Draw(20*i,20);

        }

        if(_Life==0) // Task 62
            Quit=true;
        

    }
    public void HandleInput(){
        SplashKit.ProcessEvents();

        if(SplashKit.KeyDown(KeyCode.UpKey)){
            Move(0,-SPEED);
        }
        if(SplashKit.KeyDown(KeyCode.DownKey)){
            Move(0,SPEED);
        }
        if(SplashKit.KeyDown(KeyCode.RightKey)){
            Rotate(SPEED);
        }
        if(SplashKit.KeyDown(KeyCode.LeftKey)){
            Rotate(-SPEED);
        }
        if(SplashKit.KeyDown(KeyCode.EscapeKey)){
            Quit=true;
        }
        //Task 62
        if(SplashKit.MouseDown(MouseButton.LeftButton)){
            if(!_Fired){

                _Fired=true;
                _Bullet=new Bullet(this,SplashKit.MousePositionVector());
            }
        }

    }

    public void Rotate(double amount)
    {
        _angle = (_angle + amount) % 360;
    }
    public void StayOnWindow(Window gameWindow){
        if(X-10<0 )
            X=10;
        if(Y-10<0 )
            Y=10;
        if(X+10+Width>gameWindow.Width)
            X=gameWindow.Width-Width-10;
        if(Y+10+Height>gameWindow.Height)
            Y=gameWindow.Height-Height-10;    

               

    }
    public void Move(double amountForward, double amountStrafe)
    {
        Vector2D movement = new Vector2D();
        Matrix2D rotation = SplashKit.RotationMatrix(_angle);

        movement.X += amountForward;
        movement.Y += amountStrafe;

        movement = SplashKit.MatrixMultiply(rotation, movement);
 


        X += movement.X;
        Y += movement.Y;
    }
    public bool CollidedWith(Robot other){

        return _PlayerBitmap.CircleCollision(X,Y,other.CollisionCircle);


    }
    //Task 62
    public void BulletDestroy(){
        _Fired=false;
        _Bullet=null;
    }



}