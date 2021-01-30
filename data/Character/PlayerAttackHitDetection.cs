using System;
using System.Collections;
using System.Collections.Generic;
using Unigine;

[Component(PropertyGuid = "75809534017d3f035e315886534bd62d9903c1a8")]
public class PlayerAttackHitDetection : Component
{
	vec4 colour;

	void EnterCallback(Body body)
	{
		colour = body.Object.GetMaterialInherit(0).GetParameterFloat4("albedo_color");
		body.Object.GetMaterialInherit(0).SetParameterFloat4("albedo_color", vec4.RED);
	}	

	void LeaveCallback(Body body)
	{
		body.Object.GetMaterialInherit(0).SetParameterFloat4("albedo_color", colour);
	}

	PhysicalTrigger physicalTrigger;

	private void Init()
	{
		// write here code to be called on component initialization
		physicalTrigger = node as PhysicalTrigger;

		if (physicalTrigger != null)
		{
			physicalTrigger.AddEnterCallback(EnterCallback);
			physicalTrigger.AddLeaveCallback(LeaveCallback);
		}
	}
	
	private void Update()
	{
		// write here code to be called before updating each render frame
		Visualizer.RenderBoundSphere(node.WorldBoundSphere, mat4.IDENTITY, vec4.BLUE);
	}
}