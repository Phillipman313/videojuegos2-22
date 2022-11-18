Shader "CursoJuegos/SineWaveShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Amplitude ("Amplitude", float) = 0
        _Modifier ("Modifier", float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        ZWrite On 
        Lighting On
        Fog {Mode Off}

        Pass{
            CGPROGRAM
     
            #pragma vertex vert
            #pragma fragment frag
            #pragma glsl

            uniform fixed4 _Color;
            uniform fixed _Modifier;
            uniform fixed _Amplitude;

            struct v2f{
                half4 pos : SV_POSITION;
                half4 other : COLOR;
            };

            struct appdata{
                half4 vertex: POSITION;
            };
            
            v2f vert (appdata v){
                v2f o;
                fixed xValue = v.vertex.x * 3.14159 * 10;
                fixed zValue = v.vertex.z * 3.14159 * 10;
                fixed distance = sqrt(xValue * xValue + zValue * zValue) + _Modifier;
                v.vertex.y = sin(distance) * _Amplitude;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.other = v.vertex;

                return o;
            }

            float4 frag (v2f IN): SV_TARGET{
                float4 newColor;
                newColor.r = _Color.x * (IN.other.y * 10 +0.5);
                newColor.g = _Color.y * (IN.other.y * 10+0.5);
                newColor.b = _Color.z * (IN.other.y * 10+0.5);


                //newColor.rgb = _Color.xyz * IN.other.xyz + 0.5;
                return newColor;
            }

            ENDCG
        }

    }
    FallBack "Diffuse"
}
