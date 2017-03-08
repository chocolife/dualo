﻿Shader "Custom/VRSurface" {
    Properties {
        _Color ("Color", Color) = (1,1,1,1)
        _Color2 ("Color2", Color) = (1,1,1,1)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200
         
        CGPROGRAM
        #pragma surface surf Lambert
 
        #pragma target 3.0
 
        struct Input {
            float3 worldPos;
        };
 
        fixed4 _Color;
        fixed4 _Color2;
 
        fixed3 rule(Input IN, float3 worldNormal, float period, float width) {
            float modX = abs(fmod(IN.worldPos.x, period));
            float modY = abs(fmod(IN.worldPos.y, period));
            float modZ = abs(fmod(IN.worldPos.z, period));
 
            float minBorder = width*.5f;
            float maxBorder = period - width*.5f;
 
            fixed factorX = 1-abs(dot(worldNormal, float3(1,0,0)));
            fixed factorY = 1-abs(dot(worldNormal, float3(0,1,0)));
            fixed factorZ = 1-abs(dot(worldNormal, float3(0,0,1)));
 
            fixed x = factorX * max(-1 * sign(minBorder - modX) * sign(modX - maxBorder), 0);
            fixed y = factorY * max(-1 * sign(minBorder - modY) * sign(modY - maxBorder), 0);
            fixed z = factorZ * max(-1 * sign(minBorder - modZ) * sign(modZ - maxBorder), 0);
            fixed v = saturate(x+y+z);
            return fixed3(v,v,v);
        }
 		
        fixed3 radar(Input IN, float period, float fade) {
            float distFromCam = length(IN.worldPos - _WorldSpaceCameraPos);
            float x = distFromCam / period - _Time.y / 4;
            float sawtooth = (x - floor(x)) * period;
            fixed v = saturate((sawtooth - (period - fade)) / fade) / (1+distFromCam);
            return fixed3(v,v,v);
        }
 
        void surf (Input IN, inout SurfaceOutput o) {
            float3 worldNormal = WorldNormalVector (IN, o.Normal);
            fixed3 thick = rule(IN, worldNormal, 1.0f, 0.04f);
            fixed3 thin = rule(IN, worldNormal, 0.2f, 0.02f);
            fixed3 strength = radar(IN, 8.0f, 7.0f);
            fixed3 ruleResult = _Color * (4.0f * thick * thick + 4.0f * thin * thin) * strength;
 
            fixed3 radarResult = _Color2 * radar(IN, 8.0f, 1.0f);
 
            o.Emission = ruleResult + radarResult;
            o.Alpha = 1;
        }
        ENDCG
    } 
    FallBack "Diffuse"
}