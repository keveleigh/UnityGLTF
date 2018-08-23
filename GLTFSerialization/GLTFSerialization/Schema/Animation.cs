using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GLTF.Schema
{
	/// <summary>
	/// A keyframe animation.
	/// </summary>
	[DataContract]
	public class Animation : GLTFChildOfRootProperty
	{
		/// <summary>
		/// An array of channels, each of which targets an animation's sampler at a
		/// node's property. Different channels of the same animation can't have equal
		/// targets.
		/// </summary>
		[DataMember(Name = "channels")]
		public List<AnimationChannel> Channels;

		/// <summary>
		/// An array of samplers that combines input and output accessors with an
		/// interpolation algorithm to define a keyframe graph (but not its target).
		/// </summary>
		[DataMember(Name = "samplers")]
		public List<AnimationSampler> Samplers;

		public Animation()
		{
		}

		public Animation(Animation animation, GLTFRoot gltfRoot) : base(animation, gltfRoot)
		{
			Channels = new List<AnimationChannel>(animation.Channels.Count);
			foreach (AnimationChannel channel in animation.Channels)
			{
				Channels.Add(new AnimationChannel(channel, gltfRoot));
			}

			Samplers = new List<AnimationSampler>(animation.Samplers.Count);
			foreach (AnimationSampler sampler in animation.Samplers)
			{
				Samplers.Add(new AnimationSampler(sampler, gltfRoot));
			}
		}
	}
}
