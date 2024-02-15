using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal linkedPortal;
    public MeshRenderer Mirror;
    Transform playerCam;
    UnityEngine.Camera myCamera;
    public PortalTeleport tep { get; private set; }

    private void Awake()
    {
        playerCam = UnityEngine.Camera.main.transform;
        myCamera = GetComponentInChildren<UnityEngine.Camera>();
        tep = GetComponentInChildren<PortalTeleport>();
    }

    private void Start()
    {
        RenderTexture rt = new RenderTexture(Screen.width, Screen.height, 0);
        myCamera.targetTexture = rt;
        linkedPortal.Mirror.material.SetTexture("_MainTex", rt);
        linkedPortal.tep.receiver = tep.transform;
    }

    private void Update()
    {
        Matrix4x4 m = transform.localToWorldMatrix *
            linkedPortal.transform.worldToLocalMatrix *
            playerCam.localToWorldMatrix;

        myCamera.transform.SetPositionAndRotation(m.GetPosition(), m.rotation);

        Vector3 cameraToPortal = transform.position - myCamera.transform.position;
        float nearPlane = cameraToPortal.magnitude - 2.5f;
        nearPlane = Mathf.Clamp(nearPlane, 0.01f, 50f);

        myCamera.nearClipPlane = nearPlane;
    }
}
