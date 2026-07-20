using UnityEngine;

public class VoidBack : MonoBehaviour
{

   public Transform VoidCheck;
    public float _VoidCheckRadius = 0.1f;
    public LayerMask _VoidLayer;
    public bool _InVoid;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void DowninVoid()
    {
        _InVoid = Physics2D.OverlapCircle(VoidCheck.position,_VoidCheckRadius,_VoidLayer);

        if (_InVoid)
        {
          transform.position = new Vector3(2,2,0);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         DowninVoid();
    }
}
