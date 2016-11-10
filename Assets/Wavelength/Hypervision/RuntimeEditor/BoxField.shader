Shader "PA/BoxField" {
	Properties{
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader{

		Tags{
		"Queue" = "Transparent"
		"RenderType" = "Transparent"
		"IgnoreProjector" = "True"
	}

		Pass{

		//use alpha blending
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM

		//use the vertex program defined in "ParticleField.cginc"
#pragma vertex vert
		//define the fragment program
#pragma fragment frag 
#pragma target 3.0

		//include the default Unity functions/variables etc
#include "UnityCG.cginc"	
		//include PA Particle Field		
#include "ParticleField.cginc"

		//include the pa particle features for this effect
#pragma shader_feature _ DIRECTIONAL_ON SPIN_ON
#pragma shader_feature _ WORLDSPACE_ON
#pragma shader_feature _ SHAPE_SPHERE SHAPE_CYLINDER

		struct v2f {
		float4 vertex : POSITION;
		fixed4 color : COLOR;
	};

	v2f vert(appdata_full v)
	{
		v2f o;
		//Initialize output using built in function
		UNITY_INITIALIZE_OUTPUT(v2f, o);

		//Apply PAParticleField to the input, store the particles pivot
		float3 pivotPosition = PAParticleField(v);

		float4 finalPosition = float4(v.vertex.xyz, 1);
		finalPosition.y += 0;
		finalPosition.z += 0;

		//pass on the color output from PAParticleField
		o.color = v.color;

		//position the vertex in viewspace depending on defined WORLDSPACE
		o.vertex = PAPositionVertex(finalPosition);

		//pass on the output
		return o;
	}

	fixed4 _Color;

	//the fragment program using custom v2f data struct
	fixed4 frag(v2f i) : COLOR{
		fixed4 c = fixed4(0.0,1.0,0.0,1.0); //color the pixel red
	c.r = _Color.r;
	c.g = _Color.g;
	c.b = _Color.b;
	c.a *= i.color.a; //take the alpha from v2fParticleField's color.a property
	return c;
	}

		ENDCG
	}
	}
}