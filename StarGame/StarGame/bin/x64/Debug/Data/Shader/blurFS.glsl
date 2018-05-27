#version 440 core

in vec2 UV;
in vec4 col;

out vec4 color;

uniform float blur;
uniform sampler2D tR;
uniform sampler2D tB;

void main(){
    vec2 nv = UV;
    nv.y = 1.0 - nv.y;
    
    vec3 fc = vec3(0,0,0);

    float bf = blur * 0.01;

    int x,y;
    x=0;
    y=0;
    int cc = 0;
    for(x=-3;x<3;x++)
    {
        for(y=-3;y<3;y++)
        {
            vec2 buv = nv;
            buv.x = buv.x + (x*bf);
            buv.y = buv.y + (y*bf);
            if(buv.x<0 || buv.x>1 || buv.y<0 || buv.y>1){
            }else{
            fc = fc + texture2D(tB,buv).rgb;
            cc++;
            }
        }
    }
    fc = fc / cc;
    //vec4 co = texture(tB,nv);
    vec4 icol = texture2D(tR,UV) * col;
    icol.a = 1;
    icol.rgb = icol.rgb*0.5 + fc*0.5;
    color = icol;
}