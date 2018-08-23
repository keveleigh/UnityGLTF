using GLTF.Extensions;
using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace GLTF.Schema
{
	/// <summary>
	/// The index of the node and TRS property that an animation channel targets.
	/// </summary>
	[DataContract]
	public class AnimationChannelTarget : GLTFProperty
	{
		/// <summary>
		/// The index of the node to target.
		/// </summary>
		[DataMember(Name = "node")]
		public NodeId Node;

		/// <summary>
		/// The name of the node's TRS property to modify.
		/// </summary>
		[DataMember(Name = "path")]
		public GLTFAnimationChannelPath Path;

		public static AnimationChannelTarget Deserialize(GLTFRoot root, JsonReader reader)
		{
			var animationChannelTarget = new AnimationChannelTarget();

			if (reader.Read() && reader.TokenType != JsonToken.StartObject)
			{
				throw new Exception("Animation channel target must be an object.");
			}

			while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
			{
				var curProp = reader.Value.ToString();

				switch (curProp)
				{
					case "path":
						animationChannelTarget.Path = reader.ReadStringEnum<GLTFAnimationChannelPath>();
						break;
				}
			}

			return animationChannelTarget;
		}

		public AnimationChannelTarget()
		{
		}

		public AnimationChannelTarget(AnimationChannelTarget channelTarget, GLTFRoot gltfRoot) : base(channelTarget)
		{
			if (channelTarget == null) return;

			Node = new NodeId(channelTarget.Node, gltfRoot);
			Path = channelTarget.Path;
		}
	}

	public enum GLTFAnimationChannelPath
	{
		translation,
		rotation,
		scale,
		weights
	}
}
