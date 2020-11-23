using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterManager : MonoBehaviour
{
    public bool rifleWeapon;
    public bool shotgunWeapon;
    public bool rocketWeapon;
    public bool shurikenWeapon;
    public bool bombWeapon;

    private GameObject player;

    private static GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = gameObject; 
        } else {
            Destroy(instance);
            instance = gameObject;
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player)
            player.GetComponent<weaponChooser>().chooseWeapon(rifleWeapon, shotgunWeapon, rocketWeapon, shurikenWeapon, bombWeapon);
    }

    
}
