//using UnityEngine;

//public class BackgroundScroller : MonoBehaviour
//{
//    [Range(-1f,1f)]
//    public float scrollSpeed = 0.5f;
//    private float offset;
//    private Material mat;

//    void Start()
//    {
//        mat = GetComponent<Renderer>().material;
//    }

//    void Update()
//    {
//        offset += (Time.deltaTime * scrollSpeed) / 10f;
//        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0)); 

//    }
//}


using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    public Transform[] backgrounds;
    public float[] parallaxScales;
    public float smoothing;

    private Transform cam;

    private Vector3 previousCamPos;


    [Range(-1f, 1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    public GameObject player;

    // Use this for initialization
    void Start()
    {

        cam = Camera.main.transform;
        previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length];


        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
            Debug.Log(parallaxScales[i]);
        }

        mat = GetComponent<Renderer>().material;



    }


    //void Update()
    //{
    //    offset += (Time.deltaTime * scrollSpeed) / 10f;
    //    mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));

    //}

    // Update is called once per frame
    void FixedUpdate()
    {

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        previousCamPos = cam.position;


        //new Vector3(player.transform.position.x, transform.position.y, transform.position.z);


      //  offset += (Time.deltaTime * scrollSpeed) / 2f;
        mat.SetTextureOffset("_MainTex", new Vector2(player.transform.position.x/10f, 0));




    }

}