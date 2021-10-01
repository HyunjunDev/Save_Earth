using System.Collections.Generic;
[System.Serializable]
public class User
{
    public string nickname;
    public double star;
    public List<Rocket> rocketList = new List<Rocket>();
    public List<Rocket> rocketMissileList = new List<Rocket>();
    public List<Rocket> rocketSpaceshipList = new List<Rocket>();
    public List<Rocket> rocketFaceList = new List<Rocket>();
    public List<Rocket> rocketBananaList = new List<Rocket>();
    public List<Rocket> rocketPencilList = new List<Rocket>();
    public List<Rocket> rocketShuttleList = new List<Rocket>();
    public List<Rocket> rocketSpeedList = new List<Rocket>();
    public List<Rocket> rocketTrainList = new List<Rocket>();
    public List<Planet> planetList = new List<Planet>();
    public List<Planet> metorList = new List<Planet>();
    public List<Planet> moonList = new List<Planet>();
}

