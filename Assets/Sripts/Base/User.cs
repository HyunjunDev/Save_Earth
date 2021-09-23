using System.Collections.Generic;
[System.Serializable]
public class User
{
    public string nickname;
    public long star;
    public static int touchStar;
    public List<Rocket> rocketList = new List<Rocket>();
    public List<Rocket> rocketMissileList = new List<Rocket>();
    public List<Rocket> rocketSpaceshipList = new List<Rocket>();
    public List<Planet> planetList = new List<Planet>();
    public List<Planet> metorList = new List<Planet>();
}

