using System;
using SplashKitSDK;
using System.Collections.Generic;


public class RobotDodge{

    private Player _Player;

    private Window _GameWindow;
    private List<Robot> _Robots;
    private int _RobotTypeSwitch;
    public bool Quit{
        get{
            return _Player.Quit;
        }
    }
    public RobotDodge(Window inputWindow){
        _GameWindow=inputWindow;
        _Player=new Player(_GameWindow);
        _Robots=new List<Robot>();
        _RobotTypeSwitch=1;
    }
    public void HandleInput(){
        _Player.HandleInput();
        _Player.StayOnWindow(_GameWindow);
        //Task 62
        if(_Player._Fired){
            if(_Player._Bullet.IsOffscreen(_GameWindow)){
                _Player.BulletDestroy();
            }
        }

    }
    public void Draw(){
        _GameWindow.Clear(Color.White);
        foreach(Robot eachRobot in _Robots){
            eachRobot.Draw();
        }
        _Player.Draw();
        //Task 62
        if(_Player._Fired){
            _Player._Bullet.Draw();
            
        }
        _GameWindow.DrawText("POINTS",Color.Green,"BAUHS93.ttf",17,_GameWindow.Width-80,30);//Task 62 
        _GameWindow.DrawText((_Player._PlayerTimer.Ticks/1000)+"",Color.Green,"BAUHS93.ttf",17,_GameWindow.Width-60,50);//Task 62 
        _GameWindow.Refresh(60);
    }
    

    public void Update(){

        CheckCollisions();
        //Task 62
        if(_Player._Fired){
            _Player._Bullet.Update();
            
        }
        if(_Robots.Count<3){
            _Robots.Add(RandomRobot());
        }
        foreach(Robot eachRobot in _Robots){

            eachRobot.Update();
        }
    }
    public Robot RandomRobot(){
        
        if(_RobotTypeSwitch==1){
            _RobotTypeSwitch++;
            return new Boxy(_GameWindow,_Player);

        }else if(_RobotTypeSwitch==2){
            _RobotTypeSwitch++;
            return new Roundy(_GameWindow,_Player);            
        }else{
            _RobotTypeSwitch=1;
            return new ThirdRobot(_GameWindow,_Player);            

        }

    }

    public void CheckCollisions(){
        List<Robot> SecondList=new List<Robot>();
        foreach(Robot eachRobot in _Robots){
            if(_Player.CollidedWith(eachRobot) || eachRobot.IsOffscreen(_GameWindow) || (_Player._Fired && _Player._Bullet.CollidedWith(eachRobot))){
                SecondList.Add(eachRobot);
                //Task 62
                if( (_Player._Fired && _Player._Bullet.CollidedWith(eachRobot))){
                    _Player.BulletDestroy();
                }
            }
 
            //Task 62
            if(_Player.CollidedWith(eachRobot)){
                _Player._Life--;
            }

        }
        foreach(Robot eachRobot in SecondList){
            _Robots.Remove(eachRobot);
        }

    }

}