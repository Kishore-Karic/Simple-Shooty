Shader "Custom/CartoonTexture"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white" {}
        [HDR]
        _AmbientColor("Ambient Color", Color) = (0.4,0.4,0.4,1)
        [HDR]
        _SpecularColor("Specular Color", Color) = (0.9,0.9,0.9,1)
        _Glossiness("Glossiness", Float) = 10
        [HDR]
        _RimColor("Rim Color", Color) = (1,1,1,1)
        _RimAmount("Rim Amount", Range(0, 1)) = 0.422
        _RimThreshold("Rim Threshold", Range(0, 1)) = 0.635      
    }
    SubShader
    {
        Pass
        {
            Tags
            {
                "LightMode" = "ForwardBase"
                "PassFlags" = "OnlyDirectional"
            }

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            struct appdata
            {
                float4 vertex : POSITION;               
                float4 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : NORMAL;
                float2 uv : TEXCOORD0;
                float3 viewDir : TEXCOORD1; 
                // Macro found in Autolight.cginc. Declares a vector4
                // into the TEXCOORD2 semantic with varying precision 
                // depending on platform target.
                SHADOW_COORDS(2)
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);     
                o.viewDir = WorldSpaceViewDir(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                // Defined in Autolight.cginc. Assigns the above shadow coordinate
                // by transforming the vertex from world space to shadow-map space.
                TRANSFER_SHADOW(o)
                return o;
            }
            
            float4 _Color;
            float4 _AmbientColor;
            float4 _SpecularColor;

            float _Glossiness;      

            float4 _RimColor;
            float _RimAmount;
            float _RimThreshold;    

            float4 frag (v2f i) : SV_Target
            {
                float3 normal = normalize(i.worldNormal);
                float3 viewDir = normalize(i.viewDir);

                float NdotL = dot(_WorldSpaceLightPos0, normal);
                float shadow = SHADOW_ATTENUATION(i);
                // intensity
                float lightIntensity = smoothstep(0, 0.01, NdotL * shadow); 
                // main directional light's intensity and color.
                float4 light = lightIntensity * _LightColor0;

                // calculate specular reflection.
                float3 halfVector = normalize(_WorldSpaceLightPos0 + viewDir);
                float NdotH = dot(normal, halfVector);
               
                // glossiness values
                float specularIntensity = pow(NdotH * lightIntensity, _Glossiness * _Glossiness);
                float specularIntensitySmooth = smoothstep(0.005, 0.01, specularIntensity);
                float4 specular = specularIntensitySmooth * _SpecularColor;             

                // Rim lighting.
                float rimDot = 1 - dot(viewDir, normal);
                // rim appears on the lit side of the surface,
                // multiply it by NdotL, raised to a power to smoothly blend it.
                float rimIntensity = rimDot * pow(NdotL, _RimThreshold);
                rimIntensity = smoothstep(_RimAmount - 0.01, _RimAmount + 0.01, rimIntensity);
                float4 rim = rimIntensity * _RimColor;

                float4 sample = tex2D(_MainTex, i.uv);

                return (light + _AmbientColor + specular + rim) * _Color * sample;
            }
            ENDCG
        }

        UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
    }
}