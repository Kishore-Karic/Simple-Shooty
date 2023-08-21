Shader "Custom/AltitudeFog"
{
    Properties 
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _BaseColor ("Base Color", Color) = (1, 1, 1, 1)
        _FogColor ("Fog Color", Color) = (0.5, 0.5, 0.5, 1)
        _FogMaxHeight ("Fog Max Height", Float) = 0.0
        _FogMinHeight ("Fog Min Height", Float) = -1.0
    }
  
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        Cull Back
        ZWrite On
  
        CGPROGRAM
  
        #pragma surface surf Lambert finalcolor:finalcolor vertex:vert
  
        sampler2D _MainTex;
        float4 _BaseColor; 
        float4 _FogColor;
        float _FogMaxHeight;
        float _FogMinHeight;
  
        struct Input 
        {
            float2 uv_MainTex;
            float4 pos;
        };
  
        void vert (inout appdata_full v, out Input o) 
        {
            float4 hpos = UnityObjectToClipPos (v.vertex);
            o.pos = mul(unity_ObjectToWorld, v.vertex);
            o.uv_MainTex = v.texcoord.xy;
        }
  
        void surf (Input IN, inout SurfaceOutput o) 
        {
            o.Albedo = _BaseColor * tex2D (_MainTex, IN.uv_MainTex).rgb;
        }
  
        void finalcolor (Input IN, SurfaceOutput o, inout fixed4 color)
        {
            #ifndef UNITY_PASS_FORWARDADD
            float lerpValue = clamp((IN.pos.y - _FogMinHeight) / (_FogMaxHeight - _FogMinHeight), 0, 1);
            color = lerp (_FogColor, color, lerpValue);
            #endif
        }
  
        ENDCG
    }
  
    FallBack "Diffuse"
}