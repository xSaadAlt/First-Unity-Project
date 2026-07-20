using UnityEngine;

public class Attackhitbox : MonoBehaviour
{
    public int damge;
    void Start()

    {
        
    }


     private void OnTriggerEnter2D(Collider2D collision)
    {
        Slime _SlimeGreen = collision.gameObject.GetComponent<Slime>();

        if (_SlimeGreen != null)
        {
            _SlimeGreen.takeDamge(damge);
                    Debug.Log("found Slime Component!"); // هل يوصل هنا؟

        }
        else
        {
                    Debug.Log("can`t Slime Component!"); // هل يوصل هنا؟

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
