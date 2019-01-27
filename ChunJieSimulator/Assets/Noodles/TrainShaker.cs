using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using Pixelplacement.TweenSystem;


public class TrainShaker : MonoBehaviour
{
    /*
    // Start is called before the first frame update
    public float shake_interval = 0.6f;
    private float clock = 0.0f;
    public Spline tap_track;
    public Transform tap;
    private float direction = 0; // <0 means moving left and >=0 moving right

    TweenBase tween;

    void Awake()
    {
        tween = Tween.Spline(this.tap_track, this.tap, 0.5f, 1, direction_judge(direction), 2, 0, Tween.EaseInOut, Tween.LoopType.PingPong);
    }

    void Start()
    {
        direction = Random.Range(-1.0f, 1.0f);

    }

    // Update is called once per frame

    void Update()
    { 

    }

    void OnGUI()
    {
        clock += Time.deltaTime;

        if (clock <= shake_interval) // Not yet to shake
        {
            ;
        }
        else // SHAKE NOW!
        {
            direction = Random.Range(-1.0f, 1.0f);
            CurveDetail curve = tap_track.GetCurve(tap_track.followers[0].percentage);
            tween = Tween.Spline(this.tap_track, this.tap, tap_track.followers[0].percentage, Mathf.Abs(direction)/direction, direction_judge(direction), 2, 0, Tween.EaseInOut, Tween.LoopType.PingPong);
            //tap_track.followers[0].percentage = curve.currentCurvePercentage;
            //Debug.Log(tap_track.followers[0].percentage);

            // Update percentage
            tap_track.followers[0].percentage = Mathf.Abs(direction) / direction * 0.2778f + tap_track.followers[0].percentage;
            if(tap_track.followers[0].percentage > 1)
            {
                tap_track.followers[0].percentage = 1;
            }
            if (tap_track.followers[0].percentage < -1)
            {
                tap_track.followers[0].percentage = -1;
            }

            Debug.Log(direction);
            clock = 0.0f;
        }
    }

    // Helper funcs
    bool direction_judge(float direction_float)
    {
        if (direction_float < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    */
    /*
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    public float direction = 1;
    private Quaternion startPos;
    void Start()
    {
        startPos = transform.rotation;
    }
    void Update()
    {
        Quaternion a = startPos;
        a.z += direction * (delta * Mathf.Sin(Time.time * speed));
        transform.rotation = a;
    }
    */
    public float shake_interval = 0.6f;
    private float clock = 0.0f;
    public Spline tap_track;
    public Transform tap;
    private float direction = 0; // <0 means moving left and >=0 moving right
    TweenBase tween;
    Vector3 _shakeIntensity = Vector3.one * 4.0f;
    Vector3 _cameraInitialPosition;

    void Awake()
    {
        _cameraInitialPosition = Camera.main.transform.position;
        tween = Tween.Position(this.tap, tap.position, tap.position + Vector3.left * 24, 2, 0, Tween.EaseLinear, Tween.LoopType.PingPong);
    }

    void OnGUI()
    {
        clock += Time.deltaTime;
        if (clock > shake_interval)
        {
            Tween.Shake(Camera.main.transform, _cameraInitialPosition, _shakeIntensity, .5f, 0);
            direction = Random.Range(-1.0f, 1.0f);
            if (tap.position.x < -12 && direction >= 0 && Random.Range(-1.0f, 1.0f) > -0.3f)
            {
                direction = -direction;
            }
            if (tap.position.x > 15 && direction < 0 && Random.Range(-1.0f, 1.0f) > -0.3f)
            {
                direction = -direction;
            }

            tween = Tween.Position(this.tap, tap.position, tap.position + Mathf.Abs(direction) / direction * Vector3.left * Random.Range(13.0f, 36.0f), 1, 0, Tween.EaseLinear, Tween.LoopType.PingPong);

            // Update percentage

            Debug.Log(direction);
            clock = 0.0f;
        }
    }
    // Helper funcs
    bool direction_judge(float direction_float)
    {
        if (direction_float < -0.1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
