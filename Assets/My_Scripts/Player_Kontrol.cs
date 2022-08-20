using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Kontrol : MonoBehaviour
{
    Rigidbody Fizik;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;
    public float KarakterHiz;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float egim;
    float AtesZamani = 0;
    public float AtesGecenSure;
    public GameObject Lazer;
    public Transform LazerComeFrom;
    AudioSource players_lazer_sound;

    // Start is called before the first frame update
    void Start()
    {
        Fizik = GetComponent<Rigidbody>();           // Fiziði Rigidbody componentine eþitliyoruz.
        players_lazer_sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1")&& Time.time>AtesZamani)
        {
            AtesZamani = Time.time + AtesGecenSure;
            // Instantiate (object, position, rotation)
            Instantiate (Lazer, LazerComeFrom.position, Quaternion.identity);
            players_lazer_sound.Play();
        }
    }

    // Update is called once per frame
    void FixedUpdate()              // fizik olaylarýyla uðraþýrken FixedUpdate kullanýyoruz.
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, 0, vertical);         // burada vector3 müzün gideceði yerler ayarlýyoruz y ye 0 vermemizin sebebi 2D oyun yaptýðýmýz için.
        Fizik.velocity = vec*KarakterHiz;                  // Burada Hýzýný ayarlýyoruz.


        Fizik.position = new Vector3(                         // Bu aþaðýda ise position içerisinde gidebiliceði sýnýrlarý çizdik ve c# scriptimizin içerisinde public deðerlerle ayarladýk.
            Mathf.Clamp(Fizik.position.x,minX,maxX),
            0.0f,
            Mathf.Clamp(Fizik.position.z,minZ,maxZ)
            );
        Fizik.rotation = Quaternion.Euler(0,0,Fizik.velocity.x*-egim);    // rotation transformun içindeki bir þey fizikte þuan içerisindeki rigidbody compenenti 2 componenti çaðýrýp rotationýn aldýðý
        // Quaternion diye bir deðiþken alýyor ve . ile içerisinde euler anladýðým kadarýyla eðim vermeye yarýyor x sine ve y sine 0 verdikten sonra z sine rigidbodyimizin velocitysine x i atýyoruz ve
        // bunu egimin -lisiyle çarpýyoruz. Kýsaca bu satýr haraket halinde saða sola giderken saða giderken saða eðim sola giderken sola eðim vermesini saðlýyor.

    }
}
