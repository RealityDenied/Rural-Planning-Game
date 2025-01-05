Shader "UI/blurtry"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 10)) = 1.0
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);
            float _BlurSize;

            Varyings vert(Attributes v)
            {
                Varyings o;
                o.positionHCS = TransformObjectToHClip(float4(v.positionOS, 1.0)); // Ensure correct type
                o.uv = v.uv;
                return o;
            }

            half4 frag(Varyings i) : SV_Target
            {
                half4 color = 0;
                int samples = 5; // Adjust for more blur iterations
                float2 texelSize = _BlurSize * _ScreenParams.zw;

                for (int x = -samples; x <= samples; x++)
                {
                    for (int y = -samples; y <= samples; y++)
                    {
                        color += SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv + float2(x, y) * texelSize);
                    }
                }

                return color / ((samples * 2 + 1) * (samples * 2 + 1));
            }
            ENDHLSL
        }
    }
}
