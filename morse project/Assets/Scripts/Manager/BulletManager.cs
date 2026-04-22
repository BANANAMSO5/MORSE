using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bulletObject; 

    [HideInInspector]
    public GameObject playerObject;
    //public Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Shot()
    {
        Player player = playerObject.GetComponent<Player>();

        GameObject bulletInstantiate = Instantiate(bulletObject, player.Position, bulletObject.transform.rotation);
        Bullet bullet = bulletInstantiate.GetComponent<Bullet>();
        if (bullet != null)
        {
            Debug.Log("player.Id: " + player.Id + "bullet.Id: " + bullet.Id);
            bullet.Shot(player.Id, player.direction);
        }
    }
}
