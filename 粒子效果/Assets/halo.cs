using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halo : MonoBehaviour {
    ParticleSystem particleSystem; 
    ParticleSystem.Particle[] particlesArray; 
    public int count = 5000; 
    public float size = 0.1f; 
    public float minRadius = 7.0f; 
    public float maxRadius = 13.0f; 
    public float speed = 0.5f; 
    public float range_m = 0.02f; // 游离范围
    public Gradient gradient; // 颜色
    CirclePosition[] circles; // 粒子极坐标位置
    public float time = 0; 

    class CirclePosition {
        public float radius = 0f, angle = 0f, time = 0f;
        public CirclePosition (float radius, float angle, float time) {
            this.radius = radius; 
            this.angle = angle; 
            this.time = time; 
        }
    }

    void Start () {
        // 初始化
        particlesArray = new ParticleSystem.Particle[count];
        circles = new CirclePosition[count];
        particleSystem = gameObject.GetComponent<ParticleSystem> ();
        particleSystem.maxParticles = count;
        particleSystem.startSize = size;
        particleSystem.Emit (count);
        particleSystem.GetParticles (particlesArray);
        
        float midRadius = (maxRadius + minRadius) / 2;
        float minRate = Random.Range (1.0f, midRadius / minRadius);
        float maxRate = Random.Range (midRadius / maxRadius, 1.0f);
        for (int i = 0; i < count; i++) {
            float radius = Random.Range (minRadius * minRate, maxRadius * maxRate);
            float angle = (float) i / count * 360f;
            float theta = angle / 180 * Mathf.PI;

            // 设置粒子位置
            circles[i] = new CirclePosition (radius, angle, (float) i / count * 360f);
            particlesArray[i].position = new Vector3 (radius * Mathf.Cos (theta), radius * Mathf.Sin (theta), 0);
        }
        particleSystem.SetParticles (particlesArray, particlesArray.Length);
    }

    void Update () {
        for (int i = 0; i < count; ++i) {
            circles[i].angle = (circles[i].angle - Random.Range (0.4f, 0.6f) + 360f) % 360f;
            float theta = circles[i].angle / 180 * Mathf.PI;
            int f = count - (int)(Mathf.Pow(time / 5, 3) * count);

            // 粒子半径变化
            circles[i].time += Time.deltaTime;
            circles[i].radius += Mathf.PingPong (circles[i].time / minRadius / maxRadius, range_m) - range_m / 2.0f;
            if (circles[i].radius < minRadius) circles[i].radius += Time.deltaTime;
            else if (circles[i].radius > maxRadius) circles[i].radius -= Time.deltaTime;

            particlesArray[i].position = new Vector3 (circles[i].radius * Mathf.Cos (theta), circles[i].radius * Mathf.Sin (theta), 0);
            
            //颜色
            if (i < f)
                particlesArray[i].startColor = gradient.Evaluate(0.5f);  
            else
            {
                float deep = circles[i].angle / 360f > 0.6f ? (circles[i].angle / 360f) : (circles[i].angle / 360f < 0.4f ? circles[i].angle / 360f : 0.4f);    // 不允许全透明
                particlesArray[i].startColor = gradient.Evaluate(deep);
            }
        }
        particleSystem.SetParticles (particlesArray, particlesArray.Length);
    }
}