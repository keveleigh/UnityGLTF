using System.Runtime.Serialization;

namespace GLTF.Schema
{
	/// <summary>
	/// Targets an animation's sampler at a node's property.
	/// </summary>
	[DataContract]
	public class AnimationChannel : GLTFProperty
	{
		/// <summary>
		/// The index of a sampler in this animation used to compute the value for the
		/// target, e.g., a node's translation, rotation, or scale (TRS).
		/// </summary>
		[DataMember(Name = "sampler")]
		public SamplerId Sampler;

		/// <summary>
		/// The index of the node and TRS property to target.
		/// </summary>
		[DataMember(Name = "target")]
		public AnimationChannelTarget Target;

		public AnimationChannel()
		{
		}

		public AnimationChannel(AnimationChannel animationChannel, GLTFRoot root) : base(animationChannel)
		{
			if (animationChannel == null) return;

			Sampler = new SamplerId(animationChannel.Sampler, root);
			Target = new AnimationChannelTarget(animationChannel.Target, root);
		}
	}
}
