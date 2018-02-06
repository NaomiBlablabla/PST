/*using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI_suelo : MonoBehaviour
{


    //¿Que persigo?
    public Transform target;

    //how many times each second we will update our path
    public float updateRate = 2f;

    //Caching 
    private Seeker seeker;
    private Rigidbody2D rb;

    //calculador de ruta

    public Path path;

    // velocidad de IA por segundo

    public float speed = 300f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // the max distance from the AI to a waypoint for it to continue to the next waypoint
    // la distancia máxima desde la IA a un punto de ruta para que continúe hasta el próximo punto de referencia
    public float nextWaypointDistance = 3;

    //the waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            Debug.LogError("No player found-No jugador encontrado");
            return;
        }
        //start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());


    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            //TODO: isnert search player here
            yield return false;
        }
        //start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());

    }
    public void OnPathComplete(Path p)
    {
        Debug.Log("we got a path,  did it have error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        //Debug.Log("Hola");
        if (target == null)
        {
            //TODO: isnert search player here
            return;
        }

        //TODO: Always look at player
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;
        //Direcction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        //Debug.Log(dir.x + " " + dir.y + " " + dir.z);
        /*if (dir.y > )
        {

        }

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }



    }
}
*/
using Pathfinding;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAIStrangeDreams : MonoBehaviour
{
    //enemigo patroll
    public LayerMask enemyMask;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    //Mi velocidad, aunque ya establecida, no se donde y si estoy chocando. ESTO ES LO DE CHOCAR Y CAMBIAR DE DIRECCION
    public float velocity = 10f;
    public bool colliding;
    public Transform sightStart;
    public Transform sightEnd;
    public LayerMask detectWhat;

    //¿Que persigo?
    public Transform target;

    //how many times each second we will update our path
    public float updateRate = 2f;

    //Caching 
    private Seeker seeker;
    private Rigidbody2D rb;

    //calculador de ruta

    public Path path;

    // velocidad de IA por segundo
    public float speed = 10f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // the max distance from the AI to a waypoint for it to continue to the next waypoint
    // la distancia máxima desde la IA a un punto de ruta para que continúe hasta el próximo punto de referencia
    public float nextWaypointDistance = 3;

    //the waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start()
    {
        /*//enemigo
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;*/



        //Pathfinding
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            //Debug.LogError("No player found-No jugador encontrado");
            return;
        }
        //start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());


    }

    IEnumerator UpdatePath() //borrar return, meter lo de abajo en un else
    {
        if (target == null)
        {
            //TODO: isnert search player here
            //buscar matar coroutina=?
            yield return false;
        }
        //start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());

    }
    public void OnPathComplete(Path p)
    {
        //Debug.Log("we got a path,  did it have error?" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {
        //movimiento continuo a una direccion, de base establecido a la derecha le la pantalla
        if (target == null)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
        }



        //Si colisiona, mult por -1 su vel y direccion, lo que le hace cambiar la direccion y velocidad al sentido opuesto
        colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);

        if (colliding)
        {

            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocity *= -1;

        }
    }
    void FixedUpdate()
    {
        /*Vector2 LineCastPos = myTrans.position - myTrans.right * myWidth;
        bool isCrounded = Physics2D.Linecast(LineCastPos,LineCastPos + Vector2.down,enemyMask);
        //si no hay suelo girate
        if (!isCrounded)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;

        }
        //Siempre adelante
        Vector2 myVel = myBody.velocity;
        myVel.x = speed;
        myBody.velocity = myVel;*/




        //Pathfinding
        if (target == null)
        {
            //TODO: isnert search player here
            return;
        }

        //TODO: Always look at player
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
                return;
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;
        //Direcction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;
        //Debug.Log(dir.x + " ||| " + dir.y + " ||| " + dir.z);
        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (target == null)
        {
            Debug.Log(other.gameObject.name == "Player 1");
            if (other.gameObject.name == "Player 1")
            {
                target = other.gameObject.transform;
                seeker.StartPath(transform.position, target.position, OnPathComplete);

                StartCoroutine(UpdatePath());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (target != null)
        {
            if (other.gameObject.name == "Player 1")
            {
                target = null;
            }
        }
    }

    public class Jump : MonoBehaviour
    {
        private Rigidbody2D rb;

    }
}