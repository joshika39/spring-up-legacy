using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneratorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject sun;
    public GameObject[] obstacles_down;
    public GameObject[] obstacles_up;
    public GameObject[] mountains;
    public GameObject[] grounds;
    public GameObject[] roofs;
    public GameObject[] backgrounds;
    public GameObject[] clouds;
    public GameObject[] airplanes;
    public GameObject[] boosts;
    public GameObject[] hammers;
    public GameObject[] decorations_down;
    int curr_distance;
    int clicks = 0;
    int level = 0;
    public int g = 0;
    Transform target;
    //int sunrange = 1;

    //Start
    void Start()
    {
        //Ground();
    }

    //Update
    void FixedUpdate()
    {
        curr_distance = (int)player.transform.position.x / 50;
        if (g == curr_distance)
        {
            level = curr_distance / 10;
            Ground();
            Roof();
            Background();
            Obstacle();
            
            g++;
        }
        //sun.transform.RotateAround(target.position, new Vector3(0, 0, 1), -0.1f);
        
    }

    void Ground()
    {
        GameObject ground = Instantiate(grounds[Random.Range(0, grounds.Length)],
            new Vector3(curr_distance * 81.5f + 81.5f,Random.Range(-19,-18),0), Quaternion.identity);
        target = ground.transform;
        sun.transform.position += new Vector3(50, 0, 0);
    }
    void Roof()
    {
        GameObject roof = Instantiate(roofs[Random.Range(0, roofs.Length)],
            new Vector3(curr_distance * 50 + 100, 50, 0), Quaternion.identity);
    }
    void Background()
    {       
        GameObject background = Instantiate(backgrounds[Random.Range(0, backgrounds.Length)],
            new Vector3(curr_distance * 128 + 128, 0, 0), Quaternion.identity);
    }
    void Obstacle()
    {
        int chance = Random.Range(0, 100);
        if (30 < Random.Range(0, 60+ level * clicks/2))
        {
            if (chance > 80)
            {
                Mountain();
                ObstacleDown();
                Cloud();
                Cloud();
                DecorationDown();
                
            }
            else if (chance > 60)
            {
                ObstacleUp();
                Cloud();
                Cloud();
                Mountain();
                Boost();
            }
            else if (chance > 40)
            {
                ObstacleUp();
                Cloud();
                Cloud();
                AirPlane();
                Boost();
            }
            else if (chance > 20)
            {
                ObstacleDown();
                Cloud();
                Cloud();
                Boost();
            }
            else if (chance >= 0)
            {
                Hammer();
                Cloud();
                Cloud();
                AirPlane();
                Boost();
            }
        }
        else if(chance < 50)
        {
            Cloud();
            Cloud();
            AirPlane();
            Boost();
            DecorationDown();
        }
        else
        {
            Cloud();
            Cloud();
            Mountain();
            Boost();
            DecorationDown();
        }
      
       
        //ObstacleDown();
        //ObstacleUp();
        
    }
    public void AddClick()
    {
        clicks++;
    }
    void ObstacleDown()
    {       
        GameObject obstacle = Instantiate(obstacles_down[Random.Range(0,obstacles_down.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-3,3) * 5, -16, 0), Quaternion.identity);
        int scale = Random.Range(1, 5);
        obstacle.transform.localScale = new Vector3(scale * 0.75f, scale * 0.75f, 1);
    }
    void ObstacleUp()
    {
        GameObject obstacle = Instantiate(obstacles_up[Random.Range(0, obstacles_up.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-3, 3) * 5, Random.Range(10, 20), 0), Quaternion.identity);
    }
    void Hammer()
    {
        GameObject hammer = Instantiate(hammers[Random.Range(0, hammers.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-3, 3) * 5, 12, 0), Quaternion.identity);
    }
    void Mountain()
    {
        GameObject obstacle = Instantiate(mountains[Random.Range(0, mountains.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-5, 5) * 5, -5, 0), Quaternion.identity);
        obstacle.transform.localScale = new Vector3(Random.Range(9,11), Random.Range(9,11), 1);
    }
    void Cloud()
    {
        GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)],
            new Vector3(curr_distance * 50 + Random.Range(0,50) + 50, Random.Range(20,50), 0), Quaternion.identity);
        int scale = Random.Range(1, 3);
        cloud.transform.localScale = new Vector3(scale, scale, 1);
        cloud.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(1,3),0,0);
    }
    void AirPlane()
    {
        if(Random.Range(0,100) < 25)
        {
            GameObject airplane = Instantiate(airplanes[Random.Range(0, airplanes.Length)],
                new Vector3(curr_distance * 50 + Random.Range(0, 50) + 50, Random.Range(20, 50), 0), Quaternion.identity);
            int scale = Random.Range(1, 2);
            airplane.transform.localScale = new Vector3(scale, scale, 1);
            airplane.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(3, 5), 0, 0);
        }
        
    }
    void Boost()
    {
        GameObject boost = Instantiate(boosts[Random.Range(0, boosts.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-5, 5) * 5, Random.Range(-15, 15), 0), Quaternion.identity);
    }
    void DecorationDown()
    {
        GameObject decoration = Instantiate(decorations_down[Random.Range(0, decorations_down.Length)],
            new Vector3(curr_distance * 50 + 100 + Random.Range(-3, 3) * 5, -15, 0), Quaternion.identity);
        int scale = Random.Range(1, 2);
        decoration.transform.localScale = new Vector3(scale, scale, 1);
    }


}
