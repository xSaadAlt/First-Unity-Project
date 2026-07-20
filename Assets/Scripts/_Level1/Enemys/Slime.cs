using UnityEngine;




public class Slime : MonoBehaviour
{

    public int maxhealth;
    public int currenthealth;
    public int damge;

     public float MoveDistance;
     public Vector3 leftPoint;
     public Vector3 RightPoint;
    public float speed = 3f;


    public float Distance;
    public bool MovingRight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        leftPoint = transform.position - new Vector3(MoveDistance,0,0);
        RightPoint = transform.position + new Vector3(MoveDistance,0,0);

        currenthealth = maxhealth;
    }


private void OnCollisionEnter2D(Collision2D collision)
    {
        Player playerHealth = collision.gameObject.GetComponent<Player>();

        if (playerHealth != null)
        {
            playerHealth.takeDamge(damge);
        }
    }

    public void takeDamge(int damgeAmount)
    {
        
        currenthealth -=damgeAmount;
        Debug.Log("Take Damge! : " + damgeAmount);

        if (currenthealth <= 0)
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _slimeMovements();
    }

    void _slimeMovements()
    {

        Vector3 target = MovingRight ? RightPoint : leftPoint;
      transform.position = Vector2.MoveTowards(transform.position,target, speed*Time.deltaTime);


        if(Vector2.Distance(transform.position,target) < Distance)
        {
            MovingRight = !MovingRight;

        }

        if (MovingRight == true)
        {
            transform.localScale = new Vector3(7,7,7);
        }else if (MovingRight == false)
        {
            transform.localScale = new Vector3(-7,7,7);
        }


    }

}
