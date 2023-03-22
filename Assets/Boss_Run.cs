using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D body;
    FrostController boss;

    public float speed = 2.5f;

    private void Start() {
        boss = body.GetComponent<FrostController>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        body = animator.GetComponent<Rigidbody2D>();
        // boss = animator.GetComponent<FrostController>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<FrostController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.DetectPlayer();

        Vector2 target = new Vector2(player.position.x, body.position.x);
        Vector2 newPos = Vector2.MoveTowards(body.position, target, speed * Time.fixedDeltaTime);
        body.MovePosition(newPos);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
