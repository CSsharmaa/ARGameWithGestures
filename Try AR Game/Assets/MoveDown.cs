using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.ParticleSystemJobs;

public class MoveDown : MonoBehaviour
{
    private ManoGestureContinuous grab;

    [SerializeField]
    private Material[] arCubeMaterial;
    [SerializeField]
    private GameObject colliderCube;
    private Renderer cubeRenderer;

    [SerializeField]
    private ParticleSystem Particles;

    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        grab = ManoGestureContinuous.CLOSED_HAND_GESTURE;
        cubeRenderer = GetComponent<Renderer>();
        cubeRenderer.sharedMaterial = arCubeMaterial[2];
        cubeRenderer.material = arCubeMaterial[2];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other">The collider that stays</param>
    private void OnTriggerStay(Collider other)
    {
        MoveWhenGrab(other);

    }

    /// <summary>
    /// If grab is performed while hand collider is in the cube.
    /// The cube will follow the hand.
    /// </summary>
    private void MoveWhenGrab(Collider other)
    {
        if (ManomotionManager.Instance.Hand_infos[0].hand_info.gesture_info.mano_gesture_continuous == grab)
        {
            transform.parent = other.gameObject.transform;
        }


        else
        {
            transform.parent = null;
        }
    }

    /// <summary>
    /// Vibrate when hand collider enters the cube.
    /// </summary>
    /// <param name="other">The collider that enters</param>
    private void OnTriggerEnter(Collider other)
    {
        cubeRenderer.sharedMaterial = arCubeMaterial[1];
        Handheld.Vibrate();

    }

    /// <summary>
    /// Change material when exit the cube
    /// </summary>
    /// <param name="other">The collider that exits</param>
    private void OnTriggerExit(Collider other)
    {
        cubeRenderer.sharedMaterial = arCubeMaterial[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 0.1f);
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            ScoreManager.instance.AddPoint();
            Explosion();
            CollisionTextManager.instance.CollisionText();
        }
    }

    void Explosion()
    {
        Instantiate(Particles);
        Particles.Play();
    }

}
