using System;
using UnityEngine.Experimental.VFX;

namespace UnityEditor.Experimental.VFX
{

    class VFXBlockSetColorConstant : VFXBlockType
    {
        public VFXBlockSetColorConstant()
        {
            Name = "RGB Constant";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorRGBType>("Color"));

            Add(new VFXAttribute(CommonAttrib.Color, true));

            Source = @"
color = Color;";
        }
    }

    class VFXBlockSetColorAlphaConstant : VFXBlockType
    {
        public VFXBlockSetColorAlphaConstant()
        {
            Name = "RGBA Constant";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorRGBType>("Color"));
            Add(VFXProperty.Create<VFXFloatType>("Alpha"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Alpha, true));

            Source = @"
color = Color;
alpha = Alpha;";
        }
    }

    class VFXBlockSetColorRandomUniform : VFXBlockType
    {
        public VFXBlockSetColorRandomUniform()
        {
            Name = "RGB Random Uniform";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorRGBType>("FirstColor"));
            Add(VFXProperty.Create<VFXColorRGBType>("AltColor"));
            

            Add(new VFXAttribute(CommonAttrib.Color, true));

            Source = @"
color = lerp(FirstColor,AltColor,RAND);";
        }
    }

    class VFXBlockSetColorRandom : VFXBlockType
    {
        public VFXBlockSetColorRandom()
        {
            Name = "RGB Random Per-Component";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorRGBType>("FirstColor"));
            Add(VFXProperty.Create<VFXColorRGBType>("AltColor"));
            

            Add(new VFXAttribute(CommonAttrib.Color, true));

            Source = @"
color = lerp(FirstColor,AltColor,RAND3);";
        }
    }

    class VFXBlockSetColorRandomGradient : VFXBlockType
    {
        public VFXBlockSetColorRandomGradient()
        {
            Name = "RGBA Random from Gradient";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorGradientType>("Gradient"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Alpha, true));

            Source = @"
float4 rgba = SAMPLE(Gradient,RAND);
color = rgba.rgb;
alpha = rgba.a;"; 
        }
    }

    class VFXBlockSetAlphaRandom : VFXBlockType
    {
        public VFXBlockSetAlphaRandom()
        {
            Name = "Alpha Random";
            Icon = "Alpha";
            Category = "Color";

            Add(VFXProperty.Create<VFXFloatType>("MinAlpha"));
            Add(VFXProperty.Create<VFXFloatType>("MaxAlpha"));

            Add(new VFXAttribute(CommonAttrib.Alpha, true));

            Source = @"
alpha = lerp(MinAlpha,MaxAlpha,RAND);";
        }
    }

    class VFXBlockSetColorOverLifetime : VFXBlockType
    {
        public VFXBlockSetColorOverLifetime()
        {
            Name = "Over Life RGB (Lerp)";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorRGBType>("StartColor"));
            Add(VFXProperty.Create<VFXColorRGBType>("EndColor"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age / lifetime);
color = lerp(StartColor,EndColor,ratio);";
        }
    }

    class VFXBlockSetAlphaOverLifetime : VFXBlockType
    {

        public VFXBlockSetAlphaOverLifetime()
        {
            Name = "Over Life Alpha (Lerp)";
            Icon = "Alpha";
            Category = "Color";

            Add(new VFXProperty(new VFXFloatType(1.0f),"StartAlpha"));
            Add(new VFXProperty(new VFXFloatType(1.0f),"EndAlpha"));

            Add(new VFXAttribute(CommonAttrib.Alpha, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age / lifetime);
alpha = lerp(StartAlpha,EndAlpha,ratio);";
        }
    }

    class VFXBlockSetColorGradientOverLifetime : VFXBlockType
    {
        public VFXBlockSetColorGradientOverLifetime()
        {
            Name = "Over Life RGBA (Gradient)";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXColorGradientType>("Gradient"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Alpha, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age / lifetime);
float4 rgba = SAMPLE(Gradient,ratio);
color = rgba.rgb;
alpha = rgba.a;"; 
        }
    }

    class VFXBlockSetColorScale : VFXBlockType
    {
        public VFXBlockSetColorScale()
        {
            Name = "Scale RGB (Constant)";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXFloatType>("Scale"));

            Add(new VFXAttribute(CommonAttrib.Color, true));

            Source = @"
color *= Scale;"; 
        }
    }

    class VFXBlockSetColorScaleOverLife : VFXBlockType
    {
        public VFXBlockSetColorScaleOverLife()
        {
            Name = "Over Life Scale RGB (Constant)";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXCurveType>("ScaleCurve"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age / lifetime);
float scale = SAMPLE(ScaleCurve,ratio);
color *= scale;"; 
        }
    }

    class VFXBlockSetAlphaScale : VFXBlockType
    {
        public VFXBlockSetAlphaScale()
        {
            Name = "Scale Alpha (Constant)";
            Icon = "Alpha";
            Category = "Color";

            Add(VFXProperty.Create<VFXFloatType>("Scale"));

            Add(new VFXAttribute(CommonAttrib.Alpha, true));

            Source = @"
alpha *= Scale;";
        }
    }

    class VFXBlockSetAlphaCurveOverLifetime : VFXBlockType
    {
        public VFXBlockSetAlphaCurveOverLifetime()
        {
            Name = "Over Life Alpha (Curve)";
            Icon = "Alpha";
            Category = "Color";

            Add(VFXProperty.Create<VFXCurveType>("Curve"));

            Add(new VFXAttribute(CommonAttrib.Alpha, true));
            Add(new VFXAttribute(CommonAttrib.Age, false));
            Add(new VFXAttribute(CommonAttrib.Lifetime, false));

            Source = @"
float ratio = saturate(age / lifetime);
alpha = SAMPLE(Curve,ratio);";
        }
    }

    class VFXBlockColorFromTextureProjection : VFXBlockType
    {
        public VFXBlockColorFromTextureProjection()
        {
            Name = "RGBA Texture Projection";
            Icon = "Color";
            Category = "Color";

            Add(VFXProperty.Create<VFXTexture2DType>("ColorTexture"));
            Add(VFXProperty.Create<VFXTransformType>("Transform"));

            Add(new VFXAttribute(CommonAttrib.Color, true));
            Add(new VFXAttribute(CommonAttrib.Alpha, true));
            Add(new VFXAttribute(CommonAttrib.Position, false));      

            Source = @"
                float4x4 t = transpose(Transform);
                float3 pos = position - t[3].xyz;
                float3 side = t[0];
                float u = dot(side,pos) / dot(side,side);
                float3 up = t[2];
                float v = dot(up,pos) / dot(up,up);
                float4 rgba = SampleTexture(ColorTexture, float2(u,v)+0.5);
                color = rgba.rgb;
                alpha = rgba.a;";
        }
    }
}
